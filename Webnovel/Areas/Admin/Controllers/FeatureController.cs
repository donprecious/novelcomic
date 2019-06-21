using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Webnovel.Models;
using Webnovel.Repository;

namespace Webnovel.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureController : Controller
    {
        private ICategory _category;
        public FeatureController(ICategory category)
        {
            _category = category;
        }
        public async Task<IActionResult> AddCategory()
        {
            return View(new CategoryVm());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCategory(CategoryVm m)
        {
            if (ModelState.IsValid)
            {
                var map = Mapper.Map<Entities.Category>(m);
              await  _category.Create(map);
              if (await _category.Save()) return RedirectToAction("AddCategory");

            }
            return View();
        }
        public async Task<IActionResult> Categories()
        {
            
            return View();
        }
    }
}