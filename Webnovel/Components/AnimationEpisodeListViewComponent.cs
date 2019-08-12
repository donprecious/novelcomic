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
            var scene = await _animation.GetAnimationEpisodes(animationId);
            //var c = await _category.List();
            return View("AnimationEpisodeList", scene);
        }
    }
}
