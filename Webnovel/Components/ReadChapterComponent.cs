using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webnovel.Repository;

namespace Webnovel.Components
{
    [ViewComponent(Name = "ReadChapter")]
    public class ReadChapterViewComponent : ViewComponent
    {
        private INovel _novel;

        public ReadChapterViewComponent(INovel novel)
        {
            _novel = novel;
        }
        public async Task<IViewComponentResult> InvokeAsync(int novelId)
        {
            var novel = await _novel.GetNovelChapter(novelId);
            return View("ReadChapter", novel);
        }
    }
}
