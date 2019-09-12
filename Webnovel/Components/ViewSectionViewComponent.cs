using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webnovel.Entities;
using Webnovel.Models;
using Webnovel.Repository;

namespace Webnovel.Components
{
	[ViewComponent(Name = "ViewSection")]
	public class ViewSectionViewComponent : ViewComponent
	{
		private INovel _novel;

		private UserManager<ApplicationUser> _userManager;

		public ViewSectionViewComponent(INovel novel, UserManager<ApplicationUser> userManager)
			
		{
			_novel = novel;
			_userManager = userManager;
		}

		public async Task<IViewComponentResult> InvokeAsync(int Id)
		{
			return (IViewComponentResult)(object)((ViewComponent)this).View<NovelSection>("_ViewSections", await _novel.GetNovelSection(Id));
		}
	}
}
