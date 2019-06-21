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
    [ViewComponent(Name = "AddSection")]
    public class AddSectionViewComponent : ViewComponent
    {
        private INovel _novel;
        private UserManager<ApplicationUser> _userManager;
        public AddSectionViewComponent(INovel novel, UserManager<ApplicationUser> userManager)
        {
            _novel = novel;
            _userManager = userManager;
        }

       
        public async Task<IViewComponentResult> InvokeAsync(int novelId)
        {

            var m = new NovelSectionVm()
            {
                NovelId = novelId
            };

            return View("AddSection", m);
        }
    }
}
