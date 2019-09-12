using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webnovel.Models;

namespace Webnovel.Components
{
	[ViewComponent(Name = "AddEpisode")]
	public class AddEpisodeViewComponent : ViewComponent
	{
		public AddEpisodeViewComponent()
		
		{
		}

		public async Task<IViewComponentResult> InvokeAsync(int comicId)
		{
			EpisodeVm episodeVm = new EpisodeVm
			{
				ComicId = comicId
			};
			return (IViewComponentResult)(object)((ViewComponent)this).View<EpisodeVm>("AddEpisode", episodeVm);
		}
	}
}
