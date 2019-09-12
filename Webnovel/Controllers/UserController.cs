using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Webnovel.Controllers
{
    [Authorize]
	public class UserController : Controller
	{
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

		public UserController()
			
		{
		}
	}
}
