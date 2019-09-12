using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webnovel.Entities;
using Webnovel.Repository;

namespace Webnovel.Components
{
	[ViewComponent(Name = "DisplayAnimationEpisode")]
	public class DisplayAnimationEpisodeViewComponent : ViewComponent
	{
		private IAnimation _animation;

		public DisplayAnimationEpisodeViewComponent(IAnimation animation)

		{
			_animation = animation;
		}

		public async Task<IViewComponentResult> InvokeAsync(int animationEpisodeId)
		{
			return (IViewComponentResult)(object)((ViewComponent)this).View<AnimationEpisode>("DisplayAnimationEpisode", await _animation.GetAnimationEpisode(animationEpisodeId));
		}
	}
}
