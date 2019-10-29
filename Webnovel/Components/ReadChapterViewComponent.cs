using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webnovel.Entities;
using Webnovel.Repository;

namespace Webnovel.Components
{
	[ViewComponent(Name = "ReadChapter")]
	public class ReadChapterViewComponent : ViewComponent
	{
		private INovel _novel;

      
        public ReadChapterViewComponent(INovel novel)
		{
			_novel = novel;
		}

		public async Task<IViewComponentResult> InvokeAsync(int chapterId, string userId)
		{
			Chapter novel = await _novel.GetNovelChapter(chapterId);
			if (!(await _novel.CheckLibrary(chapterId)))
			{
				await _novel.AddToLibrary(new NovelLibrary
				{
				
					NovelId = novel.NovelId,
					UserId = userId
				});
				await _novel.Save();
			}
			return (IViewComponentResult)(object)((ViewComponent)this).View<Chapter>("ReadChapter", novel);
		}
	}
}
