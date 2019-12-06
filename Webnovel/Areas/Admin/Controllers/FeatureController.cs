using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Webnovel.Entities;
using Webnovel.Models;
using Webnovel.Repository;

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
             var categories =     _category.List();
            return View(categories);
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