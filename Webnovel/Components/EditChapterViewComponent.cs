using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webnovel.Entities;
using Webnovel.Repository;

namespace Webnovel.Components
{
	[ViewComponent(Name = "EditChapter")]
	public class EditChapterViewComponent : ViewComponent
	{
		private INovel _novel;

		public EditChapterViewComponent(INovel novel)
        {
			_novel = novel;
		}

		public async Task<IViewComponentResult> InvokeAsync(int chapterId)
		{
			return (IViewComponentResult)(object)((ViewComponent)this).View<Chapter>("EditChapter", await _novel.GetNovelChapter(chapterId));
		}
	}
}
