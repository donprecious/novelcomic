using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Webnovel.Entities;
using Webnovel.Models;
using Webnovel.Repository;

namespace Webnovel.Components
{
	[ViewComponent(Name = "SectionChapter")]
	public class SectionChapterViewComponent : ViewComponent
	{
		private INovel _novel;

		private UserManager<ApplicationUser> _userManager;

		public SectionChapterViewComponent(INovel novel, UserManager<ApplicationUser> userManager)
			
		{
			_novel = novel;
			_userManager = userManager;
		}

		public async Task<IViewComponentResult> InvokeAsync(int novelId)
		{
			return (IViewComponentResult)(object)((ViewComponent)this).View<ICollection<NovelSection>>("_SectionChapter", await _novel.GetNovelSections(novelId));
		}
	}
}
