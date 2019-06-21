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
    [ViewComponent(Name = "SectionChapter")]
    public class SectionChapterViewComponent : ViewComponent
    {
        private INovel _novel;
        private UserManager<ApplicationUser> _userManager;
    
        public SectionChapterViewComponent(INovel novel, UserManager<ApplicationUser> userManager)
        {
            _novel = novel;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(int novelId)
        {
            var section = await _novel.GetNovelSections(novelId);
            //var c = await _category.List();
            return View("_SectionChapter", section);
        }
    }
}
