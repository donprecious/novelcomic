using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webnovel.Models;

namespace Webnovel.Components
{
	[ViewComponent(Name = "AddScene")]
	public class AddSceneViewComponent : ViewComponent
	{
		public AddSceneViewComponent()
		{
		}

		public async Task<IViewComponentResult> InvokeAsync(int comicId)
		{
			ComicSceneVm comicSceneVm = new ComicSceneVm
			{
				ComicId = comicId
			};
			return (IViewComponentResult)(object)((ViewComponent)this).View<ComicSceneVm>("AddScene", comicSceneVm);
		}
	}
}
