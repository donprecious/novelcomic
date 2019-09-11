using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webnovel.Repository;

namespace Webnovel.Components
{
    [ViewComponent(Name = "ReadEpisode")]
    public class ReadEpisodeViewComponent : ViewComponent
    {
        private IComic _comic;

        public ReadEpisodeViewComponent(IComic comic)
        {
            _comic = comic;
        }
        public async Task<IViewComponentResult> InvokeAsync(int episodeId)
        {
            var novel = await _comic.GetEpisode(episodeId);
            return View("ReadEpisode", novel);
        }
    }
}
