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
    [ViewComponent(Name = "SceneList")]
    public class SceneListViewComponent : ViewComponent
    {
        private IComic _comic;
  
    
        public SceneListViewComponent(IComic comic)
        {
            _comic = comic;
  
        }

        public async Task<IViewComponentResult> InvokeAsync(int comicId)
        {
            var scene = await _comic.GetComicScenes(comicId);
            //var c = await _category.List();
            return View("SceneList", scene);
        }
    }
}
