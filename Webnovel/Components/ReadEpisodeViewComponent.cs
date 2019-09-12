using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webnovel.Entities;
using Webnovel.Repository;

namespace Webnovel.Components
{
	[ViewComponent(Name = "ReadEpisode")]
	public class ReadEpisodeViewComponent : ViewComponent
	{
		private IComic _comic;

		public ReadEpisodeViewComponent(IComic comic)
			
		{
			_comic = comic;
		}

		public async Task<IViewComponentResult> InvokeAsync(int episodeId, string userId)
		{
			Episode novel = await _comic.GetEpisode(episodeId);
			if (!(await _comic.CheckLibrary(episodeId)))
			{
				await _comic.AddToLibrary(new ComicLibrary
				{
					ComicId = novel.ComicId,
					EpisodeId = episodeId,
					UserId = userId
				});
				await _comic.Save();
			}
			return (IViewComponentResult)(object)((ViewComponent)this).View<Episode>("ReadEpisode", novel);
		}
	}
}
