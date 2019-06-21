using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webnovel.Repository;

namespace Webnovel.Areas.Admin.Componets
{
    [ViewComponent(Name = "Category")]
    public class CategoryViewComponent : ViewComponent
    {
        private ICategory _category;
        public CategoryViewComponent(ICategory category)
        {
            _category = category;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var c = await _category.List(); 
            return View("_Categories",c);
        }
    }
}
