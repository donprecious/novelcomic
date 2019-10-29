using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Webnovel.Models;
using Webnovel.Repository;

namespace Webnovel.Controllers
{
    [Authorize]
	public class ReaderController : Controller
    {
        private INovel _novel;
        private IComic _comic;
        private string userId;

        private INovelHistory _novelHistory;
        private IComicHistory _comicHistory;

        private UserManager<ApplicationUser> _userManager;
        public ReaderController(INovel novel, IComic comic,
            INovelHistory novelHistory,
            IComicHistory comicHistory,
            UserManager<ApplicationUser>  userManager)
        {
            _novel = novel;
            _userManager = userManager;
            _comic = comic;
            _novelHistory = novelHistory;
            _comicHistory = comicHistory;
        }
            
        
		public async Task<IActionResult> Index()
        {
            ViewBag.novelLibCount = (await _novel.GetLibraries(userId)).Count();
            ViewBag.comicLibCount = (await _comic.GetLibrary(userId)).Count();

            return (IActionResult)(object)((Controller)this).View();
		}

	

        public IActionResult ReaderProfile()
        {
            return View();
        }

        public async Task<IActionResult> GetContentHistory()
        {
            userId = _userManager.GetUserId(User);
            var inovelHistory = await _novelHistory.GetHistories(userId);
            var distinctHistory = inovelHistory.Select((a) => new
            {
                userId = a.UserId,
                novelId = a.NovelId
            }).Distinct();
            var lastOpenedNovel = inovelHistory.OrderByDescending(a=>a.LastOpened).FirstOrDefault();
            var historyVm = new List<ContentHistoryVm>();
            foreach (var i in  distinctHistory)
            {
                var his = (await _novelHistory.GetHistories(i.userId, i.novelId));
                var novel = await _novel.GetNovel(i.novelId);
                if (lastOpenedNovel != null)
                    historyVm.Add(new ContentHistoryVm()
                    {
                        Title = novel.Title,
                        ContentId = i.novelId,
                        ContentType = "Novel",
                        LastOpened = lastOpenedNovel?.DateAdded.ToString("D"),
                        LastDateOpened = lastOpenedNovel.LastOpened,
                        OpenTimes = his.Count,
                        Progress = his.Count.ToString() + "/" + novel.Chapters.Count().ToString(),
                        TotalSubContent = novel.Chapters.Count()
                    });
            }

            var comicHistory = await _comicHistory.GetComicHistoryTask(userId);
            var distinctComicHistory = comicHistory.Select((a) => new
                {
                    userId = a.UserId,
                    comicId = a.ComicId
                }
            ).Distinct();
            var lastOpenedComic = comicHistory.OrderByDescending(a=>a.LastOpened).FirstOrDefault();

            foreach (var i in  distinctComicHistory)
            {
                var his = (await _comicHistory.GetComicHistoryTask(i.userId, i.comicId));
                var comic = await _comic.GetComic(i.comicId);

                if (lastOpenedComic != null)
                    historyVm.Add(new ContentHistoryVm()
                    {
                        Title = comic.Title,
                        ContentId = i.comicId,
                        ContentType = "Comic",
                        LastOpened = lastOpenedComic?.DateAdded.ToString("D"),
                        LastDateOpened = lastOpenedComic.LastOpened,
                        OpenTimes = his.Count,
                        Progress = his.Count.ToString() + "/" + comic.Episodes.Count().ToString(),
                        TotalSubContent = comic.Episodes.Count()
                    });
            }

            return Json(historyVm.OrderBy(a=>a.LastDateOpened).ToList());
        }

       
	}


}
