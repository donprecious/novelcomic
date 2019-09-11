using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Webnovel.Entities;
using Webnovel.Models;
using Webnovel.Repository;
using Webnovel.Services;
using Novel = Webnovel.Entities.Novel;

namespace Webnovel.Controllers
{

    [Authorize]
    public class NovelController : Controller
    {
        private INovel _novel;
        private IAuthor _author;
        private UserManager<ApplicationUser> _userManager;
        private string userId;
        public NovelController(INovel novel, IAuthor author, UserManager<ApplicationUser> userManager)
        {
            _novel = novel;
            _author = author;
            _userManager = userManager;
        }
        public async Task<IActionResult> Create()
        {
            userId = _userManager.GetUserId(User);
            ViewBag.Author = "";
            var m = new NovelVm()
            {
               
            };
            if (await _author.AuthorExist(userId))
            {
                ViewBag.Author = "true";
                var author = await _author.Get(userId);
                m.AuthorId = author.Id;
            }
            else
            {
                ViewBag.Author = "false";
            }
            return View(m);
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateAuthor( AuthorVm author)
        {
            
            author.UserId = _userManager.GetUserId(User);
            var mapped = Mapper.Map<Entities.Author>(author);
            if (! string.IsNullOrEmpty(mapped.Title))
            {
               
                if (await _author.AuthorExist(userId))
                {
                    return Json(new {status = 401, message = "It seems user is already an Auhtor"});
                }
              
                await _author.Create(mapped);
                if (await _author.Save())
                {
                    var saved = Mapper.Map<AuthorVm>(mapped);
                    return Json(new {status = 200, message = "Created Successfully", data=mapped});
                }
            }
            else
            {
                return Json(new { message = "Your Title is required",  status = 500 });
            }

            //var errors = ModelState.Values.Where(i => i.Errors.Count > 0);
           //IEnumerable<ModelError> errors = ModelState.Values.SelectMany(v => v.Errors).ToList();
           return Json( new{message = "Something went wrong, please try again later", status = 500} );
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NovelVm m)
        {

            userId = _userManager.GetUserId(User);

            if (!await _author.AuthorExist(userId))
            {
                // Redirect to Author
                ViewBag.Author = "false";
                return Json(new { staus = 401, message = "You are not an author Yet" });
            }
            if (ModelState.IsValid)
            {
               
                var mapped = Mapper.Map<Novel>(m);
                await _novel.CreateNovel(mapped);
                if (await _novel.Save())
                {
                    var saved = Mapper.Map<NovelVm>(mapped);

                    return Json( new{status = 200, message = "Created successfull", data=saved });
                }
            }
            IEnumerable<ModelError> errors = ModelState.Values.SelectMany(v => v.Errors).ToList();
            return Json(new {status = 500, errors = errors, message ="Check your entries"});
        }


        public async Task<IActionResult> DeleteNovel(int id)
        {
            if (!await _novel.FindNovel(id)) return Json(new {status = 401, message = "novel not found"});
            await _novel.DeleteNovel(id);
            if (await _novel.Save()) return Json(new {status = 200, message = "Deleted Successfully"});

          return Json(new { status = 400, message = "novel not found" });

        }

        public async Task<IActionResult> CoverPage(int id)
        {
            var comic = await _novel.GetNovel(id);
            if (comic != null)
            {
                var m = new CoverPageVm()
                {
                    Id = comic.Id
                };

                return View(m);
            }

            return View("Error404");
        } 


        [HttpPost]
        public async Task<IActionResult> CoverPage(CoverPageVm m)
        {
            if (!await _novel.FindNovel(m.Id)) return Json(new { status = 401, message = "novel not found" });
            if (m.ImageData == null) return Json(new { status = 401, message = "No Image Found" });

            var episode = await _novel.GetNovel(m.Id);
            var upload = await CloudinaryUpload.UploadToCloud(m.ImageData);
            if (upload)
            {
                if (episode.CoverPageImageUrl != null)
                {
                    await CloudinaryUpload.DeleteFromCloud(episode.CoverPageImageUrl);
                }
             
                episode.CoverPageImageUrl = CloudinaryUpload.uploadedPath;
                if (!await _novel.Save())
                    return Json(new { status = 400, message = "Something Went Wrong While Updating" });
                return Json(new { status = 200, message = "Changes was Successful", data = episode });
            }

            return Json(new { status = 400, message = "Something Went wrong" });

        }


        public async Task<IActionResult> NovelList()
        {
            userId = _userManager.GetUserId(User);
            var author = await _author.Get(userId);
            if (author != null)
            {
                var list = await _novel.GetAuthorNovels(author.Id);
                return View(list);
            }
                var nolist = await _novel.GetAuthorNovels(0);
            ;
            return View(nolist);
        }
     
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateChapter(ChapterVm m)
        {
            if (!await _novel.FindNovel(m.NovelId)) return Json(new {status = 401, message = "Novel Not Found"});
            var mapped = Mapper.Map<Chapter>(m);
            if (ModelState.IsValid)
            {
                await _novel.CreateChapter(mapped);
                if (await _novel.Save())
                {
                    var savedData = Mapper.Map<ChapterVm>(mapped);
                    return Json(new {status = 200, message = "Created Successfully", data = savedData});
                }

            }

            IEnumerable<ModelError> errors = ModelState.Values.SelectMany(v => v.Errors).ToList();
            return Json(new { status = 400, errors = errors, message = "Check your entries" });
        }

        public async  Task<IActionResult> ManageChapters(int id)
        {
            var novel = await _novel.GetNovel(id);
            if (novel == null) return View("Error404");
            return View(novel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSection(NovelSectionVm m)
        {
            if (!await _novel.FindNovel(m.NovelId)) return Json(new {status = 401, message = "Novel Not Found"});
            var mapped = Mapper.Map<NovelSection>(m);
            if (ModelState.IsValid)
            {
                await _novel.CreateSection(mapped);
                if (await _novel.Save())
                {
                    var savedData = Mapper.Map<NovelSectionVm>(mapped);
                    return Json(new {status = 200, message = "Created Successfully", data = savedData});
                }


            }

            IEnumerable<ModelError> errors = ModelState.Values.SelectMany(v => v.Errors).ToList();
            return Json(new { status = 400, errors = errors, message = "Check your entries" });
        }

        
        [HttpPost]
        public async Task<IActionResult> EditChapterSection(ChapterVm m)
        {
            if (!await _novel.FindNovelChapter(m.Id)) return Json(new { status = 401, message = "Chapter Not Found" });

            var novel = await _novel.GetNovelChapter(m.Id);
            var mapped = Mapper.Map<ChapterVm>(novel);
            mapped.Content = m.Content;
            //if (ModelState.IsValid)
            //{
              
                await _novel.EditNovelChapter(mapped);
                if (await _novel.Save())
                {
                    //var savedData = Mapper.Map<NovelSectionVm>(mapped);
                    return Json(new { status = 200, message = "Created Successfully", data = mapped });
                }
            //}

            IEnumerable<ModelError> errors = ModelState.Values.SelectMany(v => v.Errors).ToList();
            return Json(new { status = 400, errors = errors, message = "Check your entries" });
        }

        public async Task<IActionResult> AddSectionView(int id)
        {
            return ViewComponent("SectionChapter", new {novelId = id});
        }

        public async Task<IActionResult> EditChapterView(int id)
        {
            return ViewComponent("EditChapter", new { chapterId = id });
        }
        public async Task<IActionResult> DisplayChapterView(int id)
        {
            return ViewComponent("DisplayChapter", new { chapterId = id });
        }

    }
}