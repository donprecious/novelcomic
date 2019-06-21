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
    [ViewComponent(Name = "DisplayEpisode")]
    public class DisplayEpisodeViewComponent : ViewComponent
    {
        private IComic _comic;
  
        public DisplayEpisodeViewComponent(IComic comic)
        {
            _comic = comic;
        }

   

        public async Task<IViewComponentResult> InvokeAsync( int epicId)
        {
            var novel = await _comic.GetEpisode(epicId);
            return View("DisplayEpisode", novel);
        }
    }
}
