using Microsoft.AspNetCore.Mvc;

namespace Webnovel.Controllers
{
	public class ReaderController : Controller
	{
		public IActionResult Index()
		{
			return (IActionResult)(object)((Controller)this).View();
		}

		public ReaderController()
			
		{
		}
	}
}
