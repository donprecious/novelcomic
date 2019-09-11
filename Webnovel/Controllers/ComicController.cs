using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Webnovel.Components;
using Webnovel.Entities;
using Webnovel.Models;
using Webnovel.Repository;
using Webnovel.Services;

namespace Webnovel.Controllers
{
    [Authorize]
    public class ComicController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private string userId;
        private IComic _comic;
        private IAuthor _author;

        public ComicController(UserManager<ApplicationUser> userManager, IComic comic, IAuthor author)
        {
            _comic = comic;
            _userManager = userManager;
            _author = author;
        }

        public async Task<IActionResult> Create()
        {
            userId = _userManager.GetUserId(User);
            ViewBag.Author = "";
            var m = new ComicVm()
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

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ComicVm comic)
        {
            var mapped = Mapper.Map<Entities.Comic>(comic);
            if (ModelState.IsValid)
            {
                await _comic.CreateComic(mapped);
                if (await _comic.Save())
                {
                    var saved = Mapper.Map<ComicVm>(mapped);
                    return Json(new {status = 200, message = "Check your entries", data = saved});

                }

            }


            IEnumerable<ModelError> errors = ModelState.Values.SelectMany(v => v.Errors).ToList();
            return Json(new {status = 500, errors = errors, message = "Check your entries"});

        }


        public async Task<IActionResult> CoverPage(int id)
        {
            var comic = await _comic.GetComic(id);
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
            if (ModelState.IsValid)
            {
                var comic = await _comic.GetComic(m.Id);

                if (comic == null)
                {
                    return Json(new {status = 401, message = "The Comic You are tring to update does not exist"});
                }

                //try upload picture  
                //  var base64Image = m.ImageData.Split(',')[1];
                var upload = await CloudinaryUpload.UploadToCloud(m.ImageData);
                if (upload)
                {
                    if (comic.CoverPageImageUrl != null)
                    {
                        await CloudinaryUpload.DeleteFromCloud(comic.CoverPageImageUrl);
                    }

                    var mr = new ComicVm
                    {
                        Id = comic.Id,
                        CategoryId = comic.CategoryId,
                        AuthorId = comic.AuthorId,
                        Title = comic.Title,
                        Description = comic.Description,
                        CoverPageImageUrl = CloudinaryUpload.uploadedPath
                    };
                    //   var mapped = Mapper.Map<Entities.Comic>(mr);
                    //  await _comic.EditComic(mapped);
                    Mapper.Map(mr, comic);
                    if (await _comic.Save())
                    {
                        return Json(new {status = 200, data = m, message = "Comic Was Successful"});
                    }
                }
                else
                {
                    return Json(new {status = 500, message = "Something went wrong cant upload image now"});

                }


            }

            IEnumerable<ModelError> errors = ModelState.Values.SelectMany(v => v.Errors).ToList();
            return Json(new {status = 500, errors = errors, message = "Check your entries"});
        }

        public async Task<IActionResult> Manage(int id)
        {
            var novel = await _comic.GetComic(id);
            if (novel == null) return View("Error404");
            return View(novel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSceneAsync(ComicSceneVm m)
        {
            if (!await _comic.FindComic(m.ComicId)) return Json(new {status = 401, message = "Novel Not Found"});
            var mapped = Mapper.Map<ComicScene>(m);
            if (ModelState.IsValid)
            {
                await _comic.CreateComicScene(mapped);
                if (await _comic.Save())
                {
                    var savedData = Mapper.Map<ComicSceneVm>(mapped);
                    return Json(new {status = 200, message = "Created Successfully", data = savedData});
                }

            }

            IEnumerable<ModelError> errors = ModelState.Values.SelectMany(v => v.Errors).ToList();
            return Json(new {status = 400, errors = errors, message = "Check your entries"});
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEpisodeAsync(EpisodeVm m)
        {
            if (!await _comic.FindComic(m.ComicId)) return Json(new {status = 401, message = "Novel Not Found"});
            var mapped = Mapper.Map<Episode>(m);
            if (ModelState.IsValid)
            {
                await _comic.CreateEpisode(mapped);
                if (await _comic.Save())
                {
                    var savedData = Mapper.Map<EpisodeVm>(mapped);
                    return Json(new {status = 200, message = "Created Successfully", data = savedData});
                }

            }

            IEnumerable<ModelError> errors = ModelState.Values.SelectMany(v => v.Errors).ToList();
            return Json(new {status = 400, errors = errors, message = "Check your entries"});

        }

        public async Task<IActionResult> List()
        {
            userId = _userManager.GetUserId(User);
            var author = await _author.Get(userId);
            if (author != null)
            {
                var list = await _comic.GetAuthorComics(author.Id);
                return View(list);
            }

            var nolist = await _comic.GetAuthorComics(0);
            return View(nolist);
        }

        public async Task<IActionResult> DeleteComicAsync(int id)
        {
            if (!await _comic.FindComic(id)) return Json(new {status = 401, message = "novel not found"});
            await _comic.DeleteComic(id);
            if (await _comic.Save()) return Json(new {status = 200, message = "Deleted Successfully"});

            return Json(new {status = 400, message = "novel not found"});
        }

        [HttpPost]
        public async Task<IActionResult> ChangePicture(int episodeId, string imgData)
        {
            if (!await _comic.FindEpisode(episodeId)) return Json(new {status = 401, message = "Episode not found"});
            if (imgData == null) return Json(new { status = 401, message = "No Image Found" });

            var episode = await _comic.GetEpisode(episodeId);
            var upload = await CloudinaryUpload.UploadToCloud(imgData);
            if (upload)
            {
                episode.ImageUrl = CloudinaryUpload.uploadedPath;
                if (!await _comic.Save())
                    return Json(new {status = 400, message = "Something Went Wrong While Updating"});
                return Json(new {status = 200, message = "Changes was Successful", data = episode});
            }

            return Json(new {status = 400, message = "Something Went wrong"});

        }

        public async Task<IActionResult> SavedComics()
        {
            userId = _userManager.GetUserId(User);
            var comics = await _comic.SavedComic(userId);
            return View( comics);
        }

        public IActionResult DeleteSaveComic(int id)
        {
            userId = _userManager.GetUserId(User);
            var del = _comic.DeleteSavedComic(id, userId);
            return RedirectToAction("SavedComics");
        }
        public IActionResult Library()
        {
            return View();
        }
        public async Task<IActionResult> ReadComic(int id)
        {
            userId = _userManager.GetUserId(User);
            int lastViewId = 0;


            var comic = await _comic.GetComic(id);
            if (comic == null) return View("NotFound");
            // check if libary has value ;  
            var lib = await _comic.GetLibrary(userId);
            var comicLib = lib.Where(a => a.ComicId == id).FirstOrDefault();
            if (comicLib != null)
            {

                // get first chapter  
                //var chap = comic.Episodes.FirstOrDefault();
                //if (chap != null)
                //{
                lastViewId = comicLib.LastViewedId;
                ViewBag.EpisodeId = lastViewId;
                //}
            }
            else
            {
               
       
                var epic = comic.Episodes.FirstOrDefault();
                if (epic != null)
                {
                    lastViewId = epic.Id;
                    ViewBag.EpisodeId = lastViewId;
                }

            }


            return View(comic);
        } 
        public async Task<IActionResult> DisplayEpisode(int id)
        {
            return ViewComponent(typeof(DisplayEpisodeViewComponent), new { epicId = id});
        }
        public async Task<IActionResult> ReadEpisode(int id)
        {
            return ViewComponent(typeof(ReadEpisodeViewComponent), new { episodeId = id });
        }
    }
}