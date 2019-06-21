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
    [ViewComponent(Name = "AddAnimation")]
    public class AddAnimationViewComponent : ViewComponent
    {
      
        public AddAnimationViewComponent()
        {
             
        
        }

   

        public async Task<IViewComponentResult> InvokeAsync(int animationId)
        {

            var m = new AnimationEpisodeVm()
            {
               AnimationId = animationId
            };

            return View("AddAnimationScene", m);
        }
    }
}
