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
    [ViewComponent(Name = "DisplayChapter")]
    public class DisplayChapterViewComponent : ViewComponent
    {
        private INovel _novel;
  
        public DisplayChapterViewComponent(INovel novel)
        {
                  _novel = novel;
        }

   

        public async Task<IViewComponentResult> InvokeAsync( int chapterId)
        {
            var novel = await _novel.GetNovelChapter(chapterId);
            return View("DisplayChapter", novel);
        }
    }
}
