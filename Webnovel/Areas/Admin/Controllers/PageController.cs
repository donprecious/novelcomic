using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webnovel.Repository;


namespace Webnovel.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PageController : Controller
    {
        private IPage _page;

       
        public PageController(IPage page)
        {
            _page = page;
        }
        public async Task<IActionResult> Index()
        {
            var pages = await _page.GetPages();

            return View(pages);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Entities.Page page)
        {
            return View(page);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var page = await _page.GetPage(id);
            return View(page);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Entities.Page  page)
        {
            await _page.EditPage(page);
            var save = await _page.Save();
            return RedirectToAction("Detail", new {Id = page.Id});
           // return View(page);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var page = await _page.GetPage(id);
            return View(page);
        }
    }
}