using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webnovel.Models;
using Webnovel.Repository;

namespace Webnovel.Components
{
	[ViewComponent(Name = "AddChapter")]
	public class AddChapterViewComponent : ViewComponent
	{
		private INovel _novel;

		public AddChapterViewComponent(INovel novel)
		
		{
			_novel = novel;
		}

		public async Task<IViewComponentResult> InvokeAsync(int novelId)
		{
			ChapterVm chapterVm = new ChapterVm
			{
				NovelId = novelId
			};
			return (IViewComponentResult)(object)((ViewComponent)this).View<ChapterVm>("AddChapter", chapterVm);
		}
	}
}
