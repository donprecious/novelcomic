using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webnovel.Entities;
using Webnovel.Repository;

namespace Webnovel.Components
{
	[ViewComponent(Name = "DisplayEpisode")]
	public class DisplayEpisodeViewComponent : ViewComponent
	{
		private IComic _comic;

		public DisplayEpisodeViewComponent(IComic comic)
		
		{
			_comic = comic;
		}

		public async Task<IViewComponentResult> InvokeAsync(int epicId)
		{
			return (IViewComponentResult)(object)((ViewComponent)this).View<Episode>("DisplayEpisode", await _comic.GetEpisode(epicId));
		}
	}
}
