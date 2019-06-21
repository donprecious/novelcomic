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
    [ViewComponent(Name = "EditEpisode")]
    public class EditEpisodeViewComponent : ViewComponent
    {
        private IComic _comic;
  
        public EditEpisodeViewComponent(IComic comic)
        {
            _comic = comic;
        }
        public async Task<IViewComponentResult> InvokeAsync( int comicId)
        {
            var novel = await _comic.GetComic(comicId);
            return View("EditEpisode", novel);
        }
    }
}
