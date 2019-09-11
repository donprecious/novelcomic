using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Webnovel.Entities;
using Webnovel.Models;
using Webnovel.Repository;

namespace Webnovel.Controllers
{
    public class HomeController : Controller
    {
        private string userId;
        private IComic _comic;
        private INovel _novel;
        private UserManager<ApplicationUser> _userManager;

        public HomeController(UserManager<ApplicationUser> userManager, IComic comic, INovel novel)
        {
            _comic = comic;
            _novel = novel;
            _userManager = userManager;
        }
        public IActionResult Index()
        {  
            return RedirectToAction("ComingSoon");
        }
        public IActionResult Home()
        {
            return View("Index");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        } 

        public IActionResult ComingSoon()
        {
            return View();
        }

        public async Task<IActionResult> Comics(int? categoryId=null)
        {
            var comics = await _comic.GetAllComics();
            if (categoryId != null)
            {
       
                comics = comics.Where(a => a.CategoryId == categoryId).ToList();
                return View(comics.Where(a => a.CoverPageImageUrl != null).ToList());
            }
           
            return View(comics.Where(a=>a.CoverPageImageUrl != null ).ToList());
        }

        public async Task<IActionResult> AuthorComics(int authorId)
        {
            var comics = await _comic.GetAllComics();
            comics = comics.Where(a => a.Author.Id  == authorId).ToList();
            return View( "Comics",comics.Where(a => a.CoverPageImageUrl != null).ToList());
        }

        public async Task<IActionResult> Comic(int id)
        {
            var get = await _comic.GetComic(id);
            if (get == null) return View("Error404");
            return View(get);

        }

        [Authorize]
        public async Task<IActionResult> SaveComic(int comicId)
        {
            userId = _userManager.GetUserId(User);
            var savedComics = await _comic.SavedComic(userId);
            var find = savedComics.Where(a => a.ComicId == comicId).FirstOrDefault();
            if (find == null)
            {
                var comicLi = new ComicSaved()
                {
                    ComicId = comicId,
                    UserId = userId,
                    DateTime = DateTime.UtcNow
                };
               await _comic.AddToSave(comicLi);
               if (await _comic.Save())
               {
                   ViewBag.Messages = "Comic saved and added to Library";
               };
            }
            return RedirectToAction("SavedConfirmed");
        }

        public async Task<IActionResult> Novels(int? categoryId = null)
        {
            var comics = await _novel.GetAllNovels();
            if (categoryId != null)
            {

                comics = comics.Where(a => a.CategoryId == categoryId).ToList();
                return View(comics.Where(a => a.CoverPageImageUrl != null).ToList());
            }

            return View(comics.Where(a => a.CoverPageImageUrl != null).ToList());
        }

        public async Task<IActionResult> AuthorNovels(int authorId)
        {
            var comics = await _novel.GetAllNovels();
            comics = comics.Where(a => a.Author.Id == authorId).ToList();
            return View("Comics",  comics.Where(a=>a.CoverPageImageUrl != null ).ToList());
        }

        public async Task<IActionResult> Novel(int id)
        {
            var get = await _novel.GetNovel(id);
            if (get == null) return View("Error404");
            return View(get);

        }

        [Authorize]
        public async Task<IActionResult> SaveNovel(int id)
        {
            userId = _userManager.GetUserId(User);
            var savedComics = await _novel.SavedNovel(userId);
            var find = savedComics.Where(a => a.NovelId == id).FirstOrDefault();
            if (find == null)
            {
                var comicLi = new NovelSaved()
                {
                    NovelId =  id,
                    UserId = userId,
                    DateTime = DateTime.UtcNow
                };
                await _novel.AddToSave(comicLi);
                if (await _novel.Save())
                {
                    ViewBag.Messages = "Comic saved and added to Library";
                };
            }
            return RedirectToAction("SavedConfirmed");
        }
        public IActionResult SavedConfirmed()
        {
            return View();
        }
    }
}
