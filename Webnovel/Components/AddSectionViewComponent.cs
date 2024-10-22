using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webnovel.Models;
using Webnovel.Repository;

namespace Webnovel.Components
{
	[ViewComponent(Name = "AddSection")]
	public class AddSectionViewComponent : ViewComponent
	{
		private INovel _novel;

		private UserManager<ApplicationUser> _userManager;

		public AddSectionViewComponent(INovel novel, UserManager<ApplicationUser> userManager)
		
		{
			_novel = novel;
			_userManager = userManager;
		}

		public async Task<IViewComponentResult> InvokeAsync(int novelId)
		{
			NovelSectionVm novelSectionVm = new NovelSectionVm
			{
				NovelId = novelId
			};
			return (IViewComponentResult)(object)((ViewComponent)this).View<NovelSectionVm>("AddSection", novelSectionVm);
		}
	}
}
