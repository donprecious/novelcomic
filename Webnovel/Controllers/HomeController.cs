using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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

		private IAnimation _animation;

		private UserManager<ApplicationUser> _userManager;

		public HomeController(UserManager<ApplicationUser> userManager, IComic comic, INovel novel, IAnimation animation)
			
		{
			_comic = comic;
			_novel = novel;
			_userManager = userManager;
			_animation = animation;
		}

		public IActionResult Index()
		{
			return (IActionResult)(object)((ControllerBase)this).RedirectToAction("Welcome");
		}

		public IActionResult Home()
		{
			return (IActionResult)(object)((Controller)this).View("Index");
		}

		public IActionResult Welcome()
		{
			return (IActionResult)(object)((Controller)this).View();
		}

		public IActionResult About()
		{
			//((Controller)this).get_ViewData().set_Item("Message", (object)"Your application description page.");
			return (IActionResult)(object)((Controller)this).View();
		}

		public IActionResult Contact()
		{
			//((Controller)this).get_ViewData().set_Item("Message", (object)"Your contact page.");
			return (IActionResult)(object)((Controller)this).View();
		}

		public IActionResult Error()
        {
            return View("Error404");
        }

		public IActionResult ComingSoon()
		{
			return (IActionResult)(object)((Controller)this).View();
		}

		public async Task<IActionResult> Comics(int? categoryId = null)
		{
			List<Webnovel.Entities.Comic> source = await _comic.GetAllComics();
			if (categoryId.HasValue)
			{
				source = source.Where((Webnovel.Entities.Comic a) => a.CategoryId == categoryId).ToList();
				return (IActionResult)(object)((Controller)this).View((object)source.Where((Webnovel.Entities.Comic a) => a.CoverPageImageUrl != null).ToList());
			}
			return (IActionResult)(object)((Controller)this).View((object)source.Where((Webnovel.Entities.Comic a) => a.CoverPageImageUrl != null).ToList());
		}

		public async Task<IActionResult> AuthorComics(int authorId)
		{
			List<Webnovel.Entities.Comic> source = (await _comic.GetAllComics()).Where((Webnovel.Entities.Comic a) => a.Author.Id == authorId).ToList();
			return (IActionResult)(object)((Controller)this).View("Comics", (object)source.Where((Webnovel.Entities.Comic a) => a.CoverPageImageUrl != null).ToList());
		}

		public async Task<IActionResult> Comic(int id)
		{
			Webnovel.Entities.Comic comic = await _comic.GetComic(id);
			if (comic == null)
			{
				return (IActionResult)(object)((Controller)this).View("Error404");
			}
			return (IActionResult)(object)((Controller)this).View((object)comic);
		}

		[Authorize]
		public async Task<IActionResult> SaveComic(int comicId)
		{
			userId = _userManager.GetUserId(User);
			ComicSaved comicSaved = (await _comic.SavedComic(userId)).Where((ComicSaved a) => a.ComicId == comicId).FirstOrDefault();
			if (comicSaved == null)
			{
				ComicSaved comicSaved2 = new ComicSaved
				{
					ComicId = comicId,
					UserId = userId,
					DateTime = DateTime.UtcNow
				};
				await _comic.AddToSave(comicSaved2);
				if (await _comic.Save())
				{
					ViewBag.Messages = "Comic saved and added to Library";
				}
			}
			return (IActionResult)(object)((ControllerBase)this).RedirectToAction("SavedConfirmed");
		}

		public async Task<IActionResult> AuthorAnimation(int authorId)
		{
			List<Webnovel.Entities.Animation> source = (await _animation.GetAllAnimations()).Where((Webnovel.Entities.Animation a) => a.Author.Id == authorId).ToList();
			return (IActionResult)(object)((Controller)this).View("Comics", (object)source.Where((Webnovel.Entities.Animation a) => a.CoverPageImageUrl != null).ToList());
		}

		public async Task<IActionResult> Animation(int id)
		{
			Webnovel.Entities.Animation animation = await _animation.GetAnimation(id);
			if (animation == null)
			{
				return (IActionResult)(object)((Controller)this).View("Error404");
			}
			return (IActionResult)(object)((Controller)this).View((object)animation);
		}

		[Authorize]
		public async Task<IActionResult> SaveAnimation(int id)
		{
			userId = _userManager.GetUserId(User);
			AnimationSaved animationSaved = (await _animation.SavedAnimation(userId)).Where((AnimationSaved a) => a.AnimationId == id).FirstOrDefault();
			if (animationSaved == null)
			{
				AnimationSaved comicLi = new AnimationSaved
				{
					AnimationId = id,
					UserId = userId,
					DateTime = DateTime.UtcNow
				};
				await _animation.AddToSave(comicLi);
				if (await _animation.Save())
				{
					ViewBag.Messages = "Animations saved and added to Library";
				}
			}
			return (IActionResult)(object)((ControllerBase)this).RedirectToAction("SavedConfirmed");
		}

		public async Task<IActionResult> Animations(int? categoryId = null)
		{
			List<Webnovel.Entities.Animation> source = await _animation.GetAllAnimations();
			if (categoryId.HasValue)
			{
				source = source.Where((Webnovel.Entities.Animation a) => a.CategoryId == categoryId).ToList();
				return (IActionResult)(object)((Controller)this).View((object)source.Where((Webnovel.Entities.Animation a) => a.CoverPageImageUrl != null).ToList());
			}
			return (IActionResult)(object)((Controller)this).View((object)source.Where((Webnovel.Entities.Animation a) => a.CoverPageImageUrl != null).ToList());
		}

		public async Task<IActionResult> AuthorNovels(int authorId)
		{
			List<Webnovel.Entities.Novel> source = (await _novel.GetAllNovels()).Where((Webnovel.Entities.Novel a) => a.Author.Id == authorId).ToList();
			return (IActionResult)(object)((Controller)this).View("Comics", (object)source.Where((Webnovel.Entities.Novel a) => a.CoverPageImageUrl != null).ToList());
		}

		public async Task<IActionResult> Novel(int id)
		{
			Webnovel.Entities.Novel novel = await _novel.GetNovel(id);
			if (novel == null)
			{
				return (IActionResult)(object)((Controller)this).View("Error404");
			}
			return (IActionResult)(object)((Controller)this).View((object)novel);
		}

		public async Task<IActionResult> Novels(int? categoryId = null)
		{
			List<Webnovel.Entities.Novel> source = await _novel.GetAllNovels();
			if (categoryId.HasValue)
			{
				source = source.Where((Webnovel.Entities.Novel a) => a.CategoryId == categoryId).ToList();
				return (IActionResult)(object)((Controller)this).View((object)source.Where((Webnovel.Entities.Novel a) => a.CoverPageImageUrl != null).ToList());
			}
			return (IActionResult)(object)((Controller)this).View((object)source.Where((Webnovel.Entities.Novel a) => a.CoverPageImageUrl != null).ToList());
		}

		[Authorize]
		public async Task<IActionResult> SaveNovel(int NovelId)
		{
			userId = _userManager.GetUserId(User);
			NovelSaved novelSaved = (await _novel.SavedNovel(userId)).Where((NovelSaved a) => a.NovelId == NovelId).FirstOrDefault();
			if (novelSaved == null)
			{
				NovelSaved comicLibrary = new NovelSaved
				{
					NovelId = NovelId,
					UserId = userId,
					DateTime = DateTime.UtcNow
				};
				await _novel.AddToSave(comicLibrary);
				if (await _novel.Save())
				{
					ViewBag.Messages = "Comic saved and added to Library";
				}
			}
			return (IActionResult)(object)((ControllerBase)this).RedirectToAction("SavedConfirmed");
		}

		public IActionResult SavedConfirmed()
		{
			return (IActionResult)(object)((Controller)this).View();
		}
	}
}
