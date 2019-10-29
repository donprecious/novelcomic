using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Webnovel.Entities;
using Webnovel.Repository;

namespace Webnovel.Components
{
	[ViewComponent(Name = "AnimationList")]
	public class AnimationEpisodeListViewComponent : ViewComponent
	{
		private IAnimation _animation;

		public AnimationEpisodeListViewComponent(IAnimation animation)
			
		{
			_animation = animation;
		}

		public async Task<IViewComponentResult> InvokeAsync(int animationId)
		{
			return (IViewComponentResult)(object)((ViewComponent)this).View<ICollection<AnimationEpisode>>("AnimationEpisodeList", await _animation.GetAnimationEpisodes(animationId));
		}
	}
}
