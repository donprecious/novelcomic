using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Webnovel.Entities;
using Webnovel.Enum;
using Webnovel.Models;
using Webnovel.Repository;
using Category = Webnovel.Entities.Category;

namespace Webnovel.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureController : Controller
    {
        private ICategory _category;
        private IPayment _payment;
        public FeatureController(ICategory category, IPayment payment)
        {
            _category = category;
            _payment = payment;
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
             var categories = await    _category.List();
            return View(categories);
        } 

        public async Task<IActionResult> EditCategory(int id)
        {
            var category = await _category.GetCategory(id);
            return View(category);
        } 

        [HttpPost]
        public async Task<IActionResult> EditCategory( Category category)
        {
             await _category.Edit(category);
             await _category.Save();
             return RedirectToAction("Categories");
        }



        public async Task<IActionResult> DeleteCategory(int id)
        {
            var hasBeenUsed = await _category.HasBeenUsed(id);
            if (hasBeenUsed)
            {
               await _category.EditStatusCategory(id, EntityVisibilityStatus.Hidden);
                return Json(new {status = 200, message = "Cant Delete this Category, But has Been Hidden from Users"});

            }
            else
            {
            await _category.Delete(id);
                if (await _category.Save())
                {
                    return Json(new {status = 200, message = "Deleted Successfully!"});

                }
                else
                {
                    return Json(new {status = 500, message = "Cant DeleteSomething went wrong"});

                }


            }
        } 
        public async Task<IActionResult> UnHideCategory(int id)
        {
           
             var v =    await _category.EditStatusCategory(id, EntityVisibilityStatus.Visible);
             if (v)
             {
                 return Json(new {status = 200, message = "Category Visible to users now"});

             }

                return Json(new {status = 500, message = "Something went Wrong"});

        }
        public async Task<IActionResult> Subscriptions()
        {
            var sub = await _payment.GetSubcriptions();
            return View(sub);
        }

        public async Task<IActionResult> CreateSubscriptions()
        {
            
            return View(new SubscriptionVm());
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSubscriptions(SubscriptionVm m)
        {
            if (ModelState.IsValid)
            {
                var sub = Mapper.Map<Subscription>(m);
                await _payment.CreateSubscription(sub);
                if (await _payment.Save())
                {
                    return RedirectToAction( nameof(Subscriptions));
                }
            }
            return View(m);
        }
    }
}