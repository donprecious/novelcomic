using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Webnovel.Entities;
using Webnovel.Models;
using Webnovel.Repository;

namespace Webnovel.Components
{
    [ViewComponent(Name = "AddScene")]
    public class AddSceneViewComponent : ViewComponent
    {
       
        public AddSceneViewComponent()
        {
            
        }

       
        public async Task<IViewComponentResult> InvokeAsync(int comicId)
        {

            var m = new ComicSceneVm()
            {
                ComicId = comicId
            };

            return View("AddScene", m);
        }
    }
}
