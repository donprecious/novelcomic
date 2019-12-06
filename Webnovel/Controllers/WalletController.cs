using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
//using Refit;
using Webnovel.Entities;
using Webnovel.Helpers;
using Webnovel.Models;
using Webnovel.Repository;
using Microsoft.AspNetCore.Authorization;

namespace Webnovel.Controllers
{
    
    [Authorize]
	public class WalletController : Controller
	{
        private readonly IPayment _payment;
        private readonly UserManager<ApplicationUser> _userManager;

        public WalletController(IPayment payment, UserManager<ApplicationUser> userManager)
        {
            _payment = payment;
            _userManager = userManager;
        }

        public string UserId()
        {
            return _userManager.GetUserId(User);
        }
		public IActionResult FundWallet()
		{

			return (IActionResult)(object)((Controller)this).View();
		}

        public IActionResult Subscription()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubScription()
        {
            return View();
        }

        public async Task<IActionResult> VerifyPayAsYouGoPayment(string reference)
        {
            var payment =await  _payment.RavePaymentVerification(reference);
            if (payment != null)
            {
                if (payment.status.ToLower() == "success")
                {
                    var hasHistory = await _payment.PaymentReferenceExist(payment.data.txref);
                    //save transaction 
                    if (!hasHistory)
                    {
                         await _payment.AddPayment(new PaymentHistory()
                        {
                            Id =  payment.data.txref, 
                            UserId = UserId(),
                            AmountUsd = payment.data.amount,
                            PaymentGateWay = "FLUTTER_WAVE",
                            ReferenceNumber = payment.data.txref,
                            TxtDateTime = DateTime.UtcNow,
                            AdditionalDetail = "Paid for cowries"
                        });
                         if (await _payment.Save())
                         {
                             //purchased cowries history 
                             await _payment.AddCowriesPurchasedHistory(new CowriesPurchasedHistory()
                             {
                                 UserId = UserId(),
                                 DatePurchased = DateTime.UtcNow,
                                 PaymentHistoryId = payment.data.txref,
                                 Quantity = AppUtilities.CalculateCowries(payment.data.amount),
                             });
                             if (await _payment.Save())
                             {
                                 var updateBal = _payment.AddOrUpdateUserCowries(new UserCowries()
                                 {
                                     UserId = UserId(),
                                     Cowries = AppUtilities.CalculateCowries(payment.data.amount)
                                 });
                                 ViewBag.Message = "<h2>Payment Made  SuccessFully, Account Credited with token </h2> " +
                                                   "<br/>" +
                                                   "<h2>You have Add "+ AppUtilities.CalculateCowries(payment.data.amount)+  " cowries to your wallet</h3>";
                                 return View();
                                 //return Json(new {status = 200 , message= "Payment Made  SuccessFully, Account Credited with token" });
                             }

                         };
                        
                

                    }
                    ViewBag.Message = "<h2>Payment Made  SuccessFully, Account Credited with token </h2> " +
                                      "<br/>" +
                                      "<h2>You have Add "+ AppUtilities.CalculateCowries(payment.data.amount)+  " cowries to your wallet</h3>";
                    return View();
     
                }
            }

            ViewBag.Message = "<h2>Something Went Wrong.  </h2> " +
                              "<br/>";
                    return View();

        }

        public async Task<IActionResult> FreeSubscription(int id)
        {
            var hasFree = await _payment.HasFreeSubscription(UserId());
            var getSubscription = (await _payment.GetSubcriptions()).Where(a => a.Id == id).FirstOrDefault();
            if (getSubscription == null) return Json(new {status = 401, message ="nothing is found"}); 
            if(getSubscription.Amount >=1 ) return Json(new {status = 400, message ="Bad Request, Something is not reight"});
            if (!hasFree)
            {
                var uid = Guid.NewGuid();
                //create a free subscription for the user 
                await _payment.AddPayment(new PaymentHistory()
                {
                    UserId = UserId(),
                    AdditionalDetail = "Free Subscription Enabled for User",
                    PaymentGateWay = "Free_Subscription_Service",
                    AmountUsd = getSubscription.Amount,
                    Id = uid.ToString(),
                    ReferenceNumber = uid.ToString()
                });
                if (await _payment.Save())
                {
                    await  _payment.AddSubsriptionPaymentHistory(new SubscriptionPaidHistory()
                    {
                        UserId = UserId(),
                        Amount = getSubscription.Amount,
                        DatePurchased = DateTime.UtcNow,
                        Description = "Free Subscription ",
                        DueDate = DateTime.UtcNow.AddDays(getSubscription.Days),
                        SubscriptionId = getSubscription.Id,
                        PaymentHistoryId = uid.ToString()
                    });
                   await _payment.Save();
                   await _payment.AddOrUpdateUserSubscription(new UserSubscription()
                   {
                       UserId = UserId(),
                       Amount = getSubscription.Amount,
                       Description = "Free Plan Subscription",
                       SubscriptionId = getSubscription.Id,
                       DueDate = DateTime.UtcNow.AddDays(getSubscription.Days),
                       
                   });
                   await _payment.Save();
                   return Json(new {status = 200, message ="Free Subscription has been enabled"}); 
                };
           
            }
            else
            {
                return Json(new {status = 200, message ="You have already opted in for free subscription, please choose another subscription plan"}); 
            }
            return Json(new {status = 401, message ="Opps something went wrong, or contact support to give you assistance"}); 
        }  

         public async Task<IActionResult> VerifyPaidSubscription(string reference, int subId)
        {
            var payment =await  _payment.RavePaymentVerification(reference);
            var subscription = await _payment.GetSubcriptions(subId);
            var today = DateTime.UtcNow;
            if (payment != null)
            {
                if (payment.status.ToLower() == "success")
                {
                    var hasHistory = await _payment.PaymentReferenceExist(payment.data.txref);
                    //save transaction 
                    if (!hasHistory)
                    {

                        if ( !(payment.data.amount>= subscription.Amount))
                        {
                            // gi 
                            await _payment.AddPayment(new PaymentHistory()
                            {
                                Id =  payment.data.txref, 
                                UserId = UserId(),
                                AmountUsd = payment.data.amount,
                                PaymentGateWay = "FLUTTER_WAVE",
                                ReferenceNumber = payment.data.txref,
                                TxtDateTime = DateTime.UtcNow,
                                AdditionalDetail = "User FUND his wallet with " +  payment.data.amount
                            });
                           await _payment.Save(); 
                           // fund User wallet and return user to his wallet
                           await _payment.AddFundWalletHistory(new WalletFundHistory()
                           {
                               UserId = UserId(),
                               Amount = payment.data.amount,
                               DateFunded = today,
                               Description = "Wallet funded as a result of user trying to pay for subscription",
                               PaymentHistoryId = payment.data.txref,

                           });
                           if (await _payment.Save())
                           {
                               await _payment.FundWallet(new UserWallet()
                               {
                                   UserId = UserId(),
                                   Amount = payment.data.amount,
                               });
                               return Json(new {status = 200 , message= "Payment Made  SuccessFully, Account Credited with token", returnUrl=Url.Action("ReaderProfile","Reader")});

                           }
                        }
                        else
                        {
                         await _payment.AddPayment(new PaymentHistory()
                        {
                            Id =  payment.data.txref, 
                            UserId = UserId(),
                            AmountUsd = payment.data.amount,
                            PaymentGateWay = "FLUTTER_WAVE",
                            ReferenceNumber = payment.data.txref,
                            TxtDateTime = DateTime.UtcNow,
                            AdditionalDetail = "Paid for subscription " +  subscription.Title
                        });
                         if (await _payment.Save())
                         {
                             //purchased cowries history 
                         
                             await _payment.AddSubsriptionPaymentHistory(new SubscriptionPaidHistory()
                             {
                                 UserId = UserId(),
                                 DatePurchased = DateTime.UtcNow,
                                 PaymentHistoryId = payment.data.txref,
                                 Amount =payment.data.amount,
                                 Description = "Paid for subscription #" + subscription.Id  +" for "+payment.data.currency+""+payment.data.amount,
                                 DueDate = today.AddDays(subscription.Days),
                                 SubscriptionId = subscription.Id

                             });
                             if (await _payment.Save())
                             {
                                 var updateBal = await _payment.AddOrUpdateUserSubscription(new UserSubscription()
                                 {
                                     UserId = UserId(),
                                     Description = "Paid for subscription #" + subscription.Id  +" for "+payment.data.currency+""+payment.data.amount,
                                     DueDate = today.AddDays(subscription.Days),
                                     Amount = payment.data.amount,
                                     SubscriptionId = subscription.Id
                                 });
                                 await _payment.Save();
                              
                                 return Json(new {status = 200 , message= "Payment Made  SuccessFully, Account Credited with token", returnUrl=Url.Action("ReaderProfile","Reader")});
                             }

                         };
                        
                
                        }
                    }
                    ViewBag.Message = "<h2>Payment Made  SuccessFully, Account Credited with token </h2> " +
                                      "<br/>" +
                                      "<h2>You have Add "+ AppUtilities.CalculateCowries(payment.data.amount)+  " cowries to your wallet</h3>";
                    return Json(new {status = 200 , message= "Payment Made  SuccessFully, Account Funded", returnUrl=Url.Action("ReaderProfile","Reader")});
                    
                }
            }
            // revile what happened to administrator
            return Json(new {status = 400 , message= "Something went wrong along the way contact support"});


        }


	}
}
