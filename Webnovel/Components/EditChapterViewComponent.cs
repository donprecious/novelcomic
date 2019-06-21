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
    [ViewComponent(Name = "EditChapter")]
    public class EditChapterViewComponent : ViewComponent
    {
        private INovel _novel;
  
        public EditChapterViewComponent(INovel novel)
        {
                  _novel = novel;
        }
        public async Task<IViewComponentResult> InvokeAsync( int chapterId)
        {
            var novel = await _novel.GetNovelChapter(chapterId);
            return View("EditChapter", novel);
        }
    }
}
