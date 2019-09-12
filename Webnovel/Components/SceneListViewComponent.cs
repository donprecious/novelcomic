using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Webnovel.Entities;
using Webnovel.Repository;

namespace Webnovel.Components
{
	[ViewComponent(Name = "SceneList")]
	public class SceneListViewComponent : ViewComponent
	{
		private IComic _comic;

		public SceneListViewComponent(IComic comic)
			
		{
			_comic = comic;
		}

		public async Task<IViewComponentResult> InvokeAsync(int comicId)
		{
			return (IViewComponentResult)(object)((ViewComponent)this).View<ICollection<ComicScene>>("SceneList", await _comic.GetComicScenes(comicId));
		}
	}
}
