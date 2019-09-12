using Microsoft.AspNetCore.Mvc;

namespace Webnovel.Controllers
{
	public class WalletController : Controller
	{
		public IActionResult FundWallet()
		{
			return (IActionResult)(object)((Controller)this).View();
		}

		public WalletController()
			
		{
		}
	}
}
