using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Webnovel.Entities;
using Webnovel.Helpers;
using Webnovel.Models;
using Webnovel.Repository;
using X.PagedList;
using Referral = Webnovel.Entities.Referral;

namespace Webnovel.Controllers
{
	public class HomeController : Controller
	{
		private string userId;

		private IComic _comic;

		private INovel _novel;

		private IAnimation _animation;

		private UserManager<ApplicationUser> _userManager;

        private IUser _user;

        private IReferral _referral;
        private SignInManager<ApplicationUser> _signInManager;
        private IHttpContextAccessor _accessor;
        private readonly IPage _page;

        public async Task<ApplicationUser> GetUser()
        {
            return await _userManager.GetUserAsync(User);
        }
        public HomeController(UserManager<ApplicationUser> userManager, IComic comic, INovel novel, 
            IAnimation animation, IUser user, IReferral referral, 
            SignInManager<ApplicationUser> signInManager, IHttpContextAccessor accessor
            ,IPage page
            )
			
		{
			_comic = comic;
			_novel = novel;
			_userManager = userManager;
			_animation = animation;
            _user = user;
            _referral = referral;
            _signInManager = signInManager;
            _accessor = accessor;
            _page = page;
        }

		public IActionResult Index()
        {
   
            return View();
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
			List<Webnovel.Entities.Comic> source = await _comic.GetAllComics(true,true);
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
            ViewBag.PageUrl =    Url.Action("Novel", "Home",
                new{Id = id},
                protocol: Request.Scheme);
            if (_signInManager.IsSignedIn(User))
            {
                userId = _userManager.GetUserId(User);

                await _comic.AddViewer(new ComicViewer()
                {
                    BrowserAgent = Request.Headers["User-Agent"].ToString(),
                    IpAddress = _accessor.HttpContext.Connection.RemoteIpAddress.ToString(),
                    Date = DateTime.UtcNow,
                    UserId = userId,
                    ComicId = id,
                });
                await _comic.Save();
            }
            else
            {
                await _comic.AddViewer(new ComicViewer()
                {
                    BrowserAgent = Request.Headers["User-Agent"].ToString(),
                    IpAddress = _accessor.HttpContext.Connection.RemoteIpAddress.ToString(),
                    Date = DateTime.UtcNow,
                    ComicId = id,
                });
                await _comic.Save();
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
           ViewBag.PageUrl =    Url.Action("Novel", "Home",
                new{Id = id},
                protocol: Request.Scheme);
            if (_signInManager.IsSignedIn(User))
            {
                userId = _userManager.GetUserId(User);

                await _novel.AddViewer(new NovelViewer()
                                {
                                    BrowserAgent = Request.Headers["User-Agent"].ToString(),
                                    IpAddress = _accessor.HttpContext.Connection.RemoteIpAddress.ToString(),
                                    Date = DateTime.UtcNow,
                                    UserId = userId,
                                    NovelId = id,
                                });
                await _novel.Save();
            }
            else
            {
                await _novel.AddViewer(new NovelViewer()
                {
                    BrowserAgent = Request.Headers["User-Agent"].ToString(),
                    IpAddress = _accessor.HttpContext.Connection.RemoteIpAddress.ToString(),
                    Date = DateTime.UtcNow,
                    NovelId = id,
                });
                await _novel.Save();
            }
			return (IActionResult)(object)((Controller)this).View((object)novel);
		}

		public async Task<IActionResult> Novels(int page =1, int pageCount = 20, int? categoryId = null)
		{
			List<Webnovel.Entities.Novel> source = await _novel.GetAllNovels(false,true);
            var model = source.AsQueryable().ToPagedList(page, pageCount);
			if (categoryId.HasValue)
			{
				source = source.Where((Webnovel.Entities.Novel a) => a.CategoryId == categoryId).ToList();
                return View(model);
            }

            return View(model);
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

        public async Task<IActionResult> ReferralSignup()
        {
            var referal = await _referral.GetReferral(_userManager.GetUserId(User));
            if (referal != null)
            {
                if (referal.Status != "PENDING")
                {
                    return RedirectToAction("ReferralHub", "User");
                }
            }
            if (User.Identity.IsAuthenticated)
            {
                var useremail = User.Identity.Name;
                var user = await _user.GetUserByEmail(useremail);
                var referalVm = new ReferralVm
                {
                    UserId = user.Id,
                    DateOfBirth = Convert.ToDateTime(user.DateOfBirth),
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Gender = user.Gender,
                    Phone = user.PhoneNumber,

                }; 
                return View(referalVm);
            }

            return View();
        }

    
        [HttpPost]
        public async Task<IActionResult> ReferralSignup(ReferralVm m)
        {
            if (ModelState.IsValid)
            {
                var referral = new Referral
                {
                    UserId = m.UserId,
                    AdditonalInformation = m.AdditonalInformation,
                    CountryId = m.CountryId,
                    Date = DateTime.UtcNow,
                    InformationFrom = m.InformationFrom,
                    MinimumReferral = m.MinimumReferral,
                    Occupation = m.Occupation,
                    ProgramType = m.ProgramType,
                    Status = "PENDING"
                };
              await  _referral.Create(referral); 
              if (await _referral.Save())
              {
                  // update user information 
                  //get user 
                  var user = await _user.GetUser(m.UserId);
                  if (user != null)
                  {
                      user.FirstName = m.FirstName;
                      user.LastName = m.LastName;
                      user.Gender = m.Gender;
                      user.DateOfBirth = m.DateOfBirth;
                  var update =  await _user.UpdateUser(user);
                  }
                  return Json(new { status = 200, message = "Request submitted" });
              }

            }
            return Json(new { status = 400, message = "Failed to submit" });

        }

        public IActionResult Referral(int referralId)
        {
            return Redirect(Url.Action("Register", "Account", new {referralId = referralId}));
        }

        [Authorize]
        public async Task<IActionResult> Barn(int page =1)
        {
            var user = await GetUser();
           
            var userId = user.Id;
            var libary = ( await _novel.GetLibraries(userId));
            var novelLib = libary.AsQueryable().ToPagedList(page, 20);
            var comics = await _comic.GetLibrary(userId);
            var comicLib = comics.AsQueryable().ToPagedList(page, 20);

            var barn = new BarnVm
            {
                Comics = comicLib,
                Novels = novelLib
            };
            return View(barn);
        }

        public async Task<IActionResult> Page(int id)
        {
            var page = await _page.GetPage(id);
            return View(page);
        }

        [Authorize]
        public async Task<IActionResult> BasicReferral()
        {
            var user = await GetUser();
            var referrals = await _referral.GetNormalReferredUsersReferredBy(user.Id);
            var today = DateTime.UtcNow;
            var thisMonthDateBegins = new DateTime(today.Year, today.Month, 1);
            var thisWeekBegins = Utilities.GetStartOfWeek(today, today.DayOfWeek);
            ViewBag.ThisMonthReferral = referrals.Count(a => a.DateRegistered >= thisMonthDateBegins);

            ViewBag.MonthEarning = referrals.Count(a => a.DateRegistered >= thisMonthDateBegins) * 50;
            ViewBag.WeekEarning =  referrals.Count(a => a.DateRegistered >= thisWeekBegins) * 50;

            ViewBag.ReferralUrl = user.BasicReferralLink;
            return View(referrals);
        }
         
        [Authorize]
        public async Task<IActionResult> GenerateBasicReferralLink()
        {
            var user = await GetUser();
            var link = await _referral.GenerateBasicReferralUrl(user.Id);
            return Ok(link);
        }

        [Authorize]
        public async Task<IActionResult> Profile()
        {
            return View();
        }
    }
}
