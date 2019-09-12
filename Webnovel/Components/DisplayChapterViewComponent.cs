using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webnovel.Entities;
using Webnovel.Repository;

namespace Webnovel.Components
{
	[ViewComponent(Name = "DisplayChapter")]
	public class DisplayChapterViewComponent : ViewComponent
	{
		private INovel _novel;

		public DisplayChapterViewComponent(INovel novel)

		{
			_novel = novel;
		}

		public async Task<IViewComponentResult> InvokeAsync(int chapterId)
		{
			return (IViewComponentResult)(object)((ViewComponent)this).View<Chapter>("DisplayChapter", await _novel.GetNovelChapter(chapterId));
		}
	}
}
