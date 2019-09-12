using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webnovel.Models;

namespace Webnovel.Components
{
	[ViewComponent(Name = "AddAnimation")]
	public class AddAnimationViewComponent : ViewComponent
	{
		public AddAnimationViewComponent()
		
		{
		}

		public async Task<IViewComponentResult> InvokeAsync(int animationId)
		{
			AnimationEpisodeVm animationEpisodeVm = new AnimationEpisodeVm
			{
				AnimationId = animationId
			};
			return (IViewComponentResult)(object)((ViewComponent)this).View<AnimationEpisodeVm>("AddAnimationScene", animationEpisodeVm);
		}
	}
}
