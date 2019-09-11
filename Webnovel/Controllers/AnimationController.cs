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
    public class AnimationController : Controller
    {

        private UserManager<ApplicationUser> _userManager;
        private string userId;
        private IAnimation _animation;
        private IAuthor _author;

        public AnimationController(UserManager<ApplicationUser> userManager, IAnimation animation, IAuthor author)
        {
            _animation = animation;
            _userManager = userManager;
            _author = author;
        }

        public async Task<IActionResult> Index()
        {
            userId = _userManager.GetUserId(User);
            var author = await _author.Get(userId);
            var list = await _animation.GetAuthorAnimations(author.Id);
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            userId = _userManager.GetUserId(User);
            ViewBag.Author = "";
            var m = new AnimationVm();
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
        public async Task<IActionResult> Create(AnimationVm animation)
        {
            var mapped = Mapper.Map<Entities.Animation>(animation);
            if (ModelState.IsValid)
            {
                await _animation.CreateAnimation(mapped);
                if (await _animation.Save())
                {
                    var saved = Mapper.Map<AnimationVm>(mapped);
                    return Json(new { status = 200, message = "Check your entries", data = saved });

                }

            }


            IEnumerable<ModelError> errors = ModelState.Values.SelectMany(v => v.Errors).ToList();
            return Json(new { status = 500, errors = errors, message = "Check your entries" });

        }


        public async Task<IActionResult> CoverPage(int id)
        {
            var animation = await _animation.GetAnimation(id);
            if (animation!= null)
            {
                var m = new AnimationCoverPageVm()
                {
                    Id = animation.Id
                };

                return View(m);
            }

            return View("Error404");
        }

        [HttpPost]
        public async Task<IActionResult> CoverPage(AnimationCoverPageVm m)
        {
            if (ModelState.IsValid)
            {
                var comic = await _animation.GetAnimation(m.Id);

                if (comic == null)
                {
                    return Json(new { status = 401, message = "The Animation You are tring to update does not exist" });
                }

                //try upload picture  
                //  var base64Image = m.ImageData.Split(',')[1];
                var upload = await CloudinaryUpload.UploadToCloud(m.ImageData);
                if (upload)
                {
                    var mr = new ComicVm
                    {
                        Id = comic.Id,
                        CategoryId = comic.CategoryId,
                        AuthorId = comic.AuthorId,
                        Title = comic.Title,
                        Description = comic.Description,
                        CoverPageImageUrl = CloudinaryUpload.uploadedPath
                    };
                  
                    Mapper.Map(mr, comic);
                    if (await _animation.Save())
                    {
                        return Json(new { status = 200, data = m, message = "Comic Was Successful" });
                    }
                }
                else
                {
                    return Json(new { status = 500, message = "Something went wrong cant upload image now" });

                }


            }

            IEnumerable<ModelError> errors = ModelState.Values.SelectMany(v => v.Errors).ToList();
            return Json(new { status = 500, errors = errors, message = "Check your entries" });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEpisodeAsync(AnimationEpisodeVm m)
        {
            if (!await _animation.FindAnimation(m.AnimationId)) return Json(new { status = 401, message = "Novel Not Found" });
            var mapped = Mapper.Map<AnimationEpisode>(m);
            if (ModelState.IsValid)
            {
                await _animation.CreateAnimationEpisode(mapped);
                if (await _animation.Save())
                {
                    var savedData = Mapper.Map<AnimationEpisodeVm>(mapped);
                    return Json(new { status = 200, message = "Created Successfully", data = savedData });
                }

            }

            IEnumerable<ModelError> errors = ModelState.Values.SelectMany(v => v.Errors).ToList();
            return Json(new { status = 400, errors = errors, message = "Check your entries" });

        }

        public async Task<IActionResult> Manage(int id)
        {

            var item = await _animation.GetAnimation(id);
            if (item == null) return View("Error404");
            return View(item);
        }

        public async Task<IActionResult> DeleteAnimationAsync(int id)
        {
            if (!await _animation.FindAnimation(id)) return Json(new {status = 401, message = "Item not found"});
            await _animation.DeleteAnimation(id);
            if (await _animation.Save())
            { 

                //Delete Cloud Image Url
                return Json(new {status = 200, message = "Deleted Successfully"});
            }
            return Json(new { status = 400, message = "Animation not found" });
        }

        public IActionResult DisplayEpisode(int id)
        {
            //var episode = _animation.GetAnimationEpisodes(animationEpisodeId);
            return ViewComponent("DisplayAnimationEpisode", new { animationEpisodeId  = id});
        }
       
        
    }
}