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
    [ViewComponent(Name = "AddChapter")]
    public class AddChapterViewComponent: ViewComponent
    {
        private INovel _novel;
  
        public AddChapterViewComponent(INovel novel)
        {
                  _novel = novel;
        }

   

        public async Task<IViewComponentResult> InvokeAsync(int novelId)
        {

            var m = new ChapterVm()
            {
                NovelId = novelId, 
            };

            return View("AddChapter", m);
        }
    }
}
