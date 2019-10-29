using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
			userId = userId = _userManager.GetUserId(User);
            Webnovel.Entities.Author author = await _author.Get(userId);
            if (author != null)
            {
                var list = await _animation.GetAuthorAnimations(author.Id);
                return View(list);
            }
            var nolist = await _animation.GetAuthorAnimations(0);
            return View(nolist);
        }

		public async Task<IActionResult> Create()
		{
			userId =  _userManager.GetUserId(User);
			ViewBag.Author = "";
			AnimationVm i = new AnimationVm();
			if (!(await _author.AuthorExist(userId)))
			{
				ViewBag.Author = "false";
			}
			else
			{
				ViewBag.Author = "true";
				i.AuthorId = (await _author.Get(userId)).Id;
			}
			return (IActionResult)(object)((Controller)this).View((object)i);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(AnimationVm animation)
		{
			Webnovel.Entities.Animation mapped = Mapper.Map<Webnovel.Entities.Animation>((object)animation);
			if (ModelState.IsValid)
			{
				await _animation.CreateAnimation(mapped);
				if (await _animation.Save())
				{
					AnimationVm data = Mapper.Map<AnimationVm>((object)mapped);
					return (IActionResult)(object)((Controller)this).Json((object)new
					{
						status = 200,
						message = "Check your entries",
						data = data
					});
				}
			}
            IEnumerable<ModelError> errors = ModelState.Values.SelectMany(v => v.Errors).ToList();
			return (IActionResult)(object)((Controller)this).Json((object)new
			{
				status = 500,
				errors = errors,
				message = "Check your entries"
			});
		}

		public async Task<IActionResult> CoverPage(int id)
		{
			Webnovel.Entities.Animation animation = await _animation.GetAnimation(id);
			if (animation != null)
			{
				AnimationCoverPageVm animationCoverPageVm = new AnimationCoverPageVm
				{
					Id = animation.Id
				};
				return (IActionResult)(object)((Controller)this).View((object)animationCoverPageVm);
			}
			return (IActionResult)(object)((Controller)this).View("Error404");
		}

		[HttpPost]
		public async Task<IActionResult> CoverPage(AnimationCoverPageVm m)
		{
			if (ModelState.IsValid)
			{
				Webnovel.Entities.Animation comic = await _animation.GetAnimation(m.Id);
				if (comic == null)
				{
					return (IActionResult)(object)((Controller)this).Json((object)new
					{
						status = 401,
						message = "The Animation You are tring to update does not exist"
					});
				}
				if (!(await CloudinaryUpload.UploadToCloud(m.ImageData)))
				{
					return (IActionResult)(object)((Controller)this).Json((object)new
					{
						status = 500,
						message = "Something went wrong cant upload image now"
					});
				}
				AnimationVm animationVm = new AnimationVm
				{
					Id = comic.Id,
					CategoryId = comic.CategoryId,
					AuthorId = comic.AuthorId,
					Title = comic.Title,
					Description = comic.Description,
					CoverPageImageUrl = CloudinaryUpload.uploadedPath
				};
				Mapper.Map<AnimationVm, Webnovel.Entities.Animation>(animationVm, comic);
				if (await _animation.Save())
				{
					return (IActionResult)(object)((Controller)this).Json((object)new
					{
						status = 200,
						data = m,
						message = "Comic Was Successful"
					});
				}
			}
            IEnumerable<ModelError> errors = ModelState.Values.SelectMany(v => v.Errors).ToList();
			return (IActionResult)(object)((Controller)this).Json((object)new
			{
				status = 500,
				errors = errors,
				message = "Check your entries"
			});
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddEpisodeAsync(AnimationEpisodeVm m)
		{
			if (!(await _animation.FindAnimation(m.AnimationId)))
			{
				return (IActionResult)(object)((Controller)this).Json((object)new
				{
					status = 401,
					message = "Novel Not Found"
				});
			}
			AnimationEpisode mapped = Mapper.Map<AnimationEpisode>((object)m);
			if (ModelState.IsValid)
			{
				await _animation.CreateAnimationEpisode(mapped);
				if (await _animation.Save())
				{
					AnimationEpisodeVm data = Mapper.Map<AnimationEpisodeVm>((object)mapped);
					return (IActionResult)(object)((Controller)this).Json((object)new
					{
						status = 200,
						message = "Created Successfully",
						data = data
					});
				}
			}
            IEnumerable<ModelError> errors = ModelState.Values.SelectMany(v => v.Errors).ToList();
			return (IActionResult)(object)((Controller)this).Json((object)new
			{
				status = 400,
				errors = errors,
				message = "Check your entries"
			});
		}

		public async Task<IActionResult> Manage(int id)
		{
			Webnovel.Entities.Animation animation = await _animation.GetAnimation(id);
			if (animation == null)
			{
				return (IActionResult)(object)((Controller)this).View("Error404");
			}
			return (IActionResult)(object)((Controller)this).View((object)animation);
		}

		public async Task<IActionResult> DeleteAnimationAsync(int id)
		{
			if (!(await _animation.FindAnimation(id)))
			{
				return (IActionResult)(object)((Controller)this).Json((object)new
				{
					status = 401,
					message = "Item not found"
				});
			}
			await _animation.DeleteAnimation(id);
			if (await _animation.Save())
			{
				return (IActionResult)(object)((Controller)this).Json((object)new
				{
					status = 200,
					message = "Deleted Successfully"
				});
			}
			return (IActionResult)(object)((Controller)this).Json((object)new
			{
				status = 400,
				message = "Animation not found"
			});
		}

		public IActionResult DisplayEpisode(int id)
		{
			return (IActionResult)(object)((Controller)this).ViewComponent("DisplayAnimationEpisode", (object)new
			{
				animationEpisodeId = id
			});
		}

		public IActionResult Watch(int id)
		{
			Task<Webnovel.Entities.Animation> animation = _animation.GetAnimation(id);
			return (IActionResult)(object)((Controller)this).View();
		}

		public async Task<IActionResult> Library()
		{
			userId =  _userManager.GetUserId(User);
			return (IActionResult)(object)((Controller)this).View((object)(await _animation.GetLibraries(userId)));
		}
	}
}
