using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Webnovel.Models;
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

   

        public async Task<IViewComponentResult> InvokeAsync( int animationEpisodeId)
        {
            var novel = await _animation.GetAnimationEpisode(animationEpisodeId);
            return View("DisplayAnimationEpisode", novel);
        }
    }
}
