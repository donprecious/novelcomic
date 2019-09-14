using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webnovel.Data;
using Webnovel.Models;

namespace Webnovel.Controllers
{
    [Authorize]
	public class UserController : Controller
	{
        private UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _context;

        private string userId;
        public UserController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;


        }
        public ActionResult Dashboard()
		{
			return View();
		}

		public ActionResult Index()
		{
			return (ActionResult)(object)((ControllerBase)this).RedirectToAction("Dashboard");
		}

		public ActionResult CreateContent()
		{
			return View();
		}

		public ActionResult Details(int id)
		{
			return View();
		}

		public ActionResult Create()
		{
			return View();
		}

     
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return (ActionResult)(object)((ControllerBase)this).RedirectToAction("Dashboard");
			}
			catch
			{
				return View();
			}
		}

		public ActionResult Edit(int id)
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return (ActionResult)(object)((ControllerBase)this).RedirectToAction("Dashboard");
			}
			catch
			{
				return View();
			}
		}

		public ActionResult Delete(int id)
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return (ActionResult)(object)((ControllerBase)this).RedirectToAction("Dashboard");
			}
			catch
			{
				return View();
			}
		}

		public ActionResult Switch()
		{
			return View();
		}

		public IActionResult UnderConstructionPage()
		{
			return (IActionResult)(object)((Controller)this).View();
		}

        public async  Task<IActionResult> CreatorProfile()
        {
            userId = _userManager.GetUserId(User);
            var user = await _context.Users.Where(a => a.Id == userId).SingleAsync();
            return View("Profile", user);
        } 

        [HttpPost]
        public async Task<IActionResult> ChangeProfilePicture(string picture)
        {
            if (picture == null) return Json(new{message="picture is not found", status=400});
            userId = _userManager.GetUserId(User);
            var user = await _context.Users.Where(a => a.Id == userId).SingleAsync();
            user.ProfileImage = picture;
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Json(new { message = "Picture changes successfully", status = 200 });
        }

    }
}
