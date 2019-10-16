using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Refit;
using Webnovel.Models;
using Webnovel.Repository;
using Webnovel.Services;

namespace Webnovel.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private IComic _comic;
        private INovel _novel;
        private IAnimation _animation;
        private IReferral _referral;
        public DashboardController(IComic comic, INovel novel, IAnimation animation, IReferral referral)
        {
            _comic = comic;
            _animation = animation;
            _novel = novel;
            _referral = referral;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();

        } 

        public IActionResult Contents()
        {
            return View();
        } 

        public IActionResult Settings()
        {
            return View();
        }

        public async Task<IActionResult> DeleteNovel(int id)
        {
            if (!(await _novel.FindNovel(id)))
            {
                return (IActionResult)(object)((Controller)this).Json((object)new
                {
                    status = 401,
                    message = "novel not found"
                });
            }
            await _novel.DeleteNovel(id);
            if (await _novel.Save())
            {
                return (IActionResult)(object)((Controller)this).Json((object)new
                {
                    status = 200,
                    message = "Deleted Successfully"
                });
            }
            return (IActionResult)(object)((Controller)this).Json((object)new
            {
                status = 400,
                message = "novel not found"
            });
        }

        public async Task<IActionResult> DeleteComicAsync(int id)
        {
            if (!(await _comic.FindComic(id)))
            {
                return (IActionResult)(object)((Controller)this).Json((object)new
                {
                    status = 401,
                    message = "novel not found"
                });
            }
            await _comic.DeleteComic(id);
            if (await _comic.Save())
            {
                return (IActionResult)(object)((Controller)this).Json((object)new
                {
                    status = 200,
                    message = "Deleted Successfully"
                });
            }
            return (IActionResult)(object)((Controller)this).Json((object)new
            {
                status = 400,
                message = "novel not found"
            });
        } 

        public async Task<IActionResult> DeleteAnimationAsync(int id)
        {
            if (!(await _animation.FindAnimation(id)))
            {
                return (IActionResult)(object)((Controller)this).Json((object)new
                {
                    status = 401,
                    message = "Item not found"
                });
            }
            await _animation.DeleteAnimation(id);
            if (await _animation.Save())
            {
                return (IActionResult)(object)((Controller)this).Json((object)new
                {
                    status = 200,
                    message = "Deleted Successfully"
                });
            }
            return (IActionResult)(object)((Controller)this).Json((object)new
            {
                status = 400,
                message = "Animation not found"
            });
        }

        public IActionResult Referrals()
        {

            return View();
        }

        public async Task<IActionResult> Referral(int id)
        {
            var user = await _referral.GetReferral(id);
            return View(user);
        }

        public async Task<IActionResult> ApproveReferral(int id)
        {
            var referral = await _referral.GetReferral(id);
            if (referral != null)
            {
                try
                {
                    var shortUrl = await RestService.For<IBitly>("https://api-ssl.bitly.com/v4/").ShortUrl(new CreateLink()
                    {
                        long_url = "http://alkebulania.com/account/register/?referralId=" + referral.Id,
                    
                        tags = new List<string>()
                        {
                            "alkebulania", "Novel", "Comics", "Animations", referral.User.FirstName, referral.User.LastName
                        },
                        title = "alkebulania " + referral.User.Email + "- Sign up link"
                    });
                    if (shortUrl != null)
                    {
                        referral.ShortUrl = shortUrl.link;
                        referral.Status = "Approved"; 

                    }
                    await  _referral.Update(referral);  
                }
                catch (ValidationApiException validationException)
                {
                    // handle validation here by using validationException.Content, 
                    // which is type of ProblemDetails according to RFC 7807
                    Console.WriteLine(validationException);
                }
                catch (ApiException exception)
                {
                    // other exception handling
                    Console.WriteLine(exception);
                }
                
            }
          
           
            return Redirect(Url.Action("Referral", new {id = id}));
        }

        public async  Task<IActionResult> DeleteReferral(int id)
        {
            var delete = await _referral.DeleteReferal(id);
            if (delete)
            {
                return Json(new {
                    status = 200, message = "Deleted Successfully !"}); 

            } return Json(new {
                status = 400, message = "Failed to delete !"
            });
        }
    }
    
}