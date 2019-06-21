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
    [ViewComponent(Name = "AddEpisode")]
    public class AddEpisodeViewComponent : ViewComponent
    {
      
        public AddEpisodeViewComponent()
        {
             
        
        }

   

        public async Task<IViewComponentResult> InvokeAsync(int comicId)
        {

            var m = new EpisodeVm()
            {
               ComicId = comicId
            };

            return View("AddEpisode", m);
        }
    }
}
