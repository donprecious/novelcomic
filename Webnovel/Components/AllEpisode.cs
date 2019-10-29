using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webnovel.Repository;

namespace Webnovel.Components
{
    [ViewComponent(Name = "AllEpisode")]
    public class AllEpisodeViewComponent: ViewComponent
    {
        private IComic _comic;
        public AllEpisodeViewComponent(IComic comic)

        {
            _comic = comic;
        }

        public async Task<IViewComponentResult> InvokeAsync(int comicId)
        {
            var epics = await _comic.GetEpisodes(comicId);
            return View("AllEpisode", epics.OrderBy(a=>a.Preference));
        }
    }
}
