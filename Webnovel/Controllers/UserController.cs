using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webnovel.Data;
using Webnovel.Models;
using Webnovel.Repository;
using Author = Webnovel.Entities.Author;

namespace Webnovel.Controllers
{
    [Authorize]
	public class UserController : Controller
	{
        private UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _context;
        private IReferral _referral;

        private string userId;
        public UserController(UserManager<ApplicationUser> userManager, ApplicationDbContext context, IReferral referral)
        {
            _userManager = userManager;
            _context = context;
            _referral = referral;

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

        
        public async Task<ActionResult> EditProfile()
        {
            userId = _userManager.GetUserId(User);
            var user = await _context.Users.Where(a => a.Id == userId).SingleAsync();
            return PartialView("_EditProfile", user);
        }

        [HttpPost]
        public ActionResult EditAuthorProfile(EditUserVm user)
        {
            //get user  
            var findUser = _context.Users.SingleOrDefault(a => a.Id == user.UserId);
            var author = _context.Authors.FirstOrDefault(a => a.UserId == user.UserId);
            findUser.FirstName = user.FirstName;
            findUser.LastName = user.LastName;
            findUser.PhoneNumber = user.Phone;
            _context.Entry(findUser).State = EntityState.Modified;
            _context.SaveChanges();
            //check author 
            if (author != null)
            {
                 // check for title 
                 if (user.AuthorTitle != null || string.IsNullOrEmpty(user.AuthorTitle))
                 {
                     author.Title = user.AuthorTitle;
                     _context.Entry(author).State = EntityState.Modified;
                     _context.SaveChanges();
                 }
            }
            else
            {
                //create new person 
                if (user.AuthorTitle != null || string.IsNullOrEmpty(user.AuthorTitle))
                {
                    _context.Authors.Add(new Author()
                    {
                        UserId = user.UserId,
                        Title = user.AuthorTitle,
                    });
                    _context.SaveChanges();
                }
            }
           return Json(new { status = 200, message = "Changes Saved Successfully" });
        }

        public async Task<ActionResult> ReferralHub()
        {
            var referral = (await _referral.GetReferral(_userManager.GetUserId(User)));
            if (referral != null)
            {
                ViewBag.referralId = referral.Id;

            }
            var refers = await _referral.Refers(_userManager.GetUserId(User));
            return View(refers);
        }
    }
}
