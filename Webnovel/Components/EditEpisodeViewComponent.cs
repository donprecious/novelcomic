using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webnovel.Entities;
using Webnovel.Repository;

namespace Webnovel.Components
{
	[ViewComponent(Name = "EditEpisode")]
	public class EditEpisodeViewComponent : ViewComponent
	{
		private IComic _comic;

		public EditEpisodeViewComponent(IComic comic)
		
		{
			_comic = comic;
		}

		public async Task<IViewComponentResult> InvokeAsync(int comicId)
		{
			return (IViewComponentResult)(object)((ViewComponent)this).View<Webnovel.Entities.Comic>("EditEpisode", await _comic.GetComic(comicId));
		}
	}
}
