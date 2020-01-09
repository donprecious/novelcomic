using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using ReflectionIT.Mvc.Paging;
using Webnovel.Components;
using Webnovel.DtoModels;
using Webnovel.Entities;
using Webnovel.Enum;
using Webnovel.Helpers;
using Webnovel.Models;
using Webnovel.Repository;
using Webnovel.Services;
using X.PagedList;

namespace Webnovel.Controllers
{
	[Authorize]
	public class NovelController : Controller
	{
		private INovel _novel;

		private IAuthor _author;

		private UserManager<ApplicationUser> _userManager;

		private string userId;

        private INovelHistory _novelHistory;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly IRate _rate;
        private readonly INovelComment _comment;

        private readonly IPayment _payment;

        public NovelController(INovel novel, IAuthor author, UserManager<ApplicationUser> userManager,
            INovelHistory novelHistory, SignInManager<ApplicationUser> signInManager, IRate rate,
            INovelComment comment,
            IPayment payment
            )
        {
            _novel = novel;
            _author = author;
            _userManager = userManager;
            _novelHistory = novelHistory;
            _signInManager = signInManager;
            _rate = rate;
            _comment = comment;
            _payment = payment;
        }

        public async Task<IActionResult> Create()
		{
			userId = _userManager.GetUserId(User);
			ViewBag.Author = "";
			NovelVm i = new NovelVm();
			if (!(await _author.AuthorExist(userId)))
			{
				ViewBag.Author = "false";
			}
			else
			{
				ViewBag.Author = "true";
				i.AuthorId = (await _author.Get(userId)).Id;
			}
			return (IActionResult)(object)((Controller)this).View((object)i);
		}

		[HttpPost]
		public async Task<IActionResult> CreateAuthor(AuthorVm author)
		{
			author.UserId = _userManager.GetUserId(User);
			Webnovel.Entities.Author mapped = Mapper.Map<Webnovel.Entities.Author>((object)author);
			if (!string.IsNullOrEmpty(mapped.Title))
			{
				if (await _author.AuthorExist(userId))
				{
					return (IActionResult)(object)((Controller)this).Json((object)new
					{
						status = 401,
						message = "It seems user is already an Auhtor"
					});
				}
				await _author.Create(mapped);
				if (await _author.Save())
				{
					Mapper.Map<AuthorVm>((object)mapped);
					return (IActionResult)(object)((Controller)this).Json((object)new
					{
						status = 200,
						message = "Created Successfully",
						data = mapped
					});
				}
				return (IActionResult)(object)((Controller)this).Json((object)new
				{
					message = "Something went wrong, please try again later",
					status = 500
				});
			}
			return (IActionResult)(object)((Controller)this).Json((object)new
			{
				message = "Your Title is required",
				status = 500
			});
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(NovelVm m)
		{
			userId = _userManager.GetUserId(User);
			if (!(await _author.AuthorExist(userId)))
			{
				ViewBag.Author = "false";
				return (IActionResult)(object)((Controller)this).Json((object)new
				{
					staus = 401,
					message = "You are not an author Yet"
				});
			}
			if (ModelState.IsValid)
			{
				Webnovel.Entities.Novel mapped = Mapper.Map<Webnovel.Entities.Novel>((object)m);
				await _novel.CreateNovel(mapped);
				if (await _novel.Save())
				{
					NovelVm saved = Mapper.Map<NovelVm>((object)mapped);
					ICollection<string> nTags = m.NTags;
					List<NovelTag> novelTag = new List<NovelTag>();
					if (nTags != null)
					{
						foreach (string t in nTags)
						{
							if (!(await _novel.FindTag(t)))
							{
								await _novel.AddTag(new Tag
								{
									Name = t
								});
								await _novel.Save();
							}
							Tag tag = await _novel.GetTag(t);
							if (tag != null)
							{
								novelTag.Add(new NovelTag
								{
									NovelId = saved.Id,
									TagId = tag.Id
								});
								await _novel.Save();
							}
						}
					}
					await _novel.CreateSection(new NovelSection
					{
						Title = "First Section",
						NovelId = saved.Id
					});
					await _novel.Save();
					return (IActionResult)(object)((Controller)this).Json((object)new
					{
						status = 200,
						message = "Created successfull",
						data = saved
					});
				}
			}
            IEnumerable<ModelError> errors = ModelState.Values.SelectMany(v => v.Errors).ToList();
			return (IActionResult)(object)((Controller)this).Json((object)new
			{
				status = 500,
				errors = errors,
				message = "Check your entries"
			});
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

		public async Task<IActionResult> CoverPage(int id)
		{
			Webnovel.Entities.Novel novel = await _novel.GetNovel(id);
			if (novel != null)
			{
				CoverPageVm coverPageVm = new CoverPageVm
				{
					Id = novel.Id
				};
				return (IActionResult)(object)((Controller)this).View((object)coverPageVm);
			}
			return (IActionResult)(object)((Controller)this).View("Error404");
		}

		[HttpPost]
		public async Task<IActionResult> CoverPage(CoverPageVm m)
		{
			if (!(await _novel.FindNovel(m.Id)))
			{
				return (IActionResult)(object)((Controller)this).Json((object)new
				{
					status = 401,
					message = "novel not found"
				});
			}
			if (m.ImageData == null)
			{
				return (IActionResult)(object)((Controller)this).Json((object)new
				{
					status = 401,
					message = "No Image Found"
				});
			}
			Webnovel.Entities.Novel episode = await _novel.GetNovel(m.Id);
			if (await CloudinaryUpload.UploadToCloud(m.ImageData))
			{
				if (episode.CoverPageImageUrl != null)
				{
					await CloudinaryUpload.DeleteFromCloud(episode.CoverPageImageUrl);
				}
				episode.CoverPageImageUrl = CloudinaryUpload.uploadedPath;
				if (!(await _novel.Save()))
				{
					return (IActionResult)(object)((Controller)this).Json((object)new
					{
						status = 400,
						message = "Something Went Wrong While Updating"
					});
				}
				return (IActionResult)(object)((Controller)this).Json((object)new
				{
					status = 200,
					message = "Changes was Successful",
					data = episode
				});
			}
			return (IActionResult)(object)((Controller)this).Json((object)new
			{
				status = 400,
				message = "Something Went wrong"
			});
		}

		public async Task<IActionResult> NovelList()
		{
			userId = _userManager.GetUserId(User);
			Webnovel.Entities.Author author = await _author.Get(userId);
			if (author != null)
			{
				return (IActionResult)(object)((Controller)this).View((object)(await _novel.GetAuthorNovels(author.Id)));
			}
			return (IActionResult)(object)((Controller)this).View((object)(await _novel.GetAuthorNovels(0)));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateChapter(ChapterVm m)
		{
			if (!(await _novel.FindNovel(m.NovelId)))
			{
				return (IActionResult)(object)((Controller)this).Json((object)new
				{
					status = 401,
					message = "Novel Not Found"
				});
			}
			Chapter mapped = Mapper.Map<Chapter>((object)m);
			if (ModelState.IsValid)
			{
				await _novel.CreateChapter(mapped);
				if (await _novel.Save())
				{
					ChapterVm data = Mapper.Map<ChapterVm>((object)mapped);
					return (IActionResult)(object)((Controller)this).Json((object)new
					{
						status = 200,
						message = "Created Successfully",
						data = data
					});
				}
			}
            IEnumerable<ModelError> errors = ModelState.Values.SelectMany(v => v.Errors).ToList();
			return (IActionResult)(object)((Controller)this).Json((object)new
			{
				status = 400,
				errors = errors,
				message = "Check your entries"
			});
		}

		public async Task<IActionResult> ManageChapters(int id)
		{
			Webnovel.Entities.Novel novel = await _novel.GetNovel(id);
			if (novel == null)
			{
				return (IActionResult)(object)((Controller)this).View("Error404");
			}
			return (IActionResult)(object)((Controller)this).View((object)novel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddSection(NovelSectionVm m)
		{
			if (!(await _novel.FindNovel(m.NovelId)))
			{
				return (IActionResult)(object)((Controller)this).Json((object)new
				{
					status = 401,
					message = "Novel Not Found"
				});
			}
			NovelSection mapped = Mapper.Map<NovelSection>((object)m);
			if (ModelState.IsValid)
			{
				await _novel.CreateSection(mapped);
				if (await _novel.Save())
				{
					NovelSectionVm data = Mapper.Map<NovelSectionVm>((object)mapped);
					return (IActionResult)(object)((Controller)this).Json((object)new
					{
						status = 200,
						message = "Created Successfully",
						data = data
					});
				}
			}
            IEnumerable<ModelError> errors = ModelState.Values.SelectMany(v => v.Errors).ToList();
			return (IActionResult)(object)((Controller)this).Json((object)new
			{
				status = 400,
				errors = errors,
				message = "Check your entries"
			});
		}

		[HttpPost]
		public async Task<IActionResult> EditChapterSection(ChapterVm m)
		{
			if (!(await _novel.FindNovelChapter(m.Id)))
			{
				return (IActionResult)(object)((Controller)this).Json((object)new
				{
					status = 401,
					message = "Chapter Not Found"
				});
			}
			ChapterVm mapped = Mapper.Map<ChapterVm>((object)(await _novel.GetNovelChapter(m.Id)));
			mapped.Content = m.Content;
			await _novel.EditNovelChapter(mapped);
			if (await _novel.Save())
			{
				return (IActionResult)(object)((Controller)this).Json((object)new
				{
					status = 200,
					message = "Created Successfully",
					data = mapped
				});
			}
            IEnumerable<ModelError> errors = ModelState.Values.SelectMany(v => v.Errors).ToList();
			return (IActionResult)(object)((Controller)this).Json((object)new
			{
				status = 400,
				errors = errors,
				message = "Check your entries"
			});
		}

		public async Task<IActionResult> AddSectionView(int id)
		{
			return (IActionResult)(object)((Controller)this).ViewComponent("SectionChapter", (object)new
			{
				novelId = id
			});
		}

		public async Task<IActionResult> SavedNovels()
		{
			userId = _userManager.GetUserId(User);
			return (IActionResult)(object)((Controller)this).View((object)(await _novel.SavedNovel(userId)));
		}

		public IActionResult DeleteSaveNovel(int id)
		{
			userId = _userManager.GetUserId(User);
			Task task = _novel.DeleteSavedNovel(id, userId);
			return (IActionResult)(object)((ControllerBase)this).RedirectToAction("SavedNovels");
		}

		public async Task<IActionResult> ReadNovel(int id, int? chapterId = null)
		{
			Webnovel.Entities.Novel comic = await _novel.GetNovel(id);
			userId = _userManager.GetUserId(User);
			if (comic == null)
			{
				return (IActionResult)(object)((Controller)this).View("Error404");
			}
			if (!chapterId.HasValue)
			{
				Chapter chapter = comic.Chapters.FirstOrDefault();
				if (comic.Chapters == null)
				{
					await _novel.AddToLibrary(new NovelLibrary
					{
						NovelId = id,
						UserId = userId
					});
					await _novel.Save();
					ViewBag.chapterId = Convert.ToInt32(chapterId);
				}
				else if (await _novel.CheckLibrary(id))
				{
					//ViewBag.chapterId = chapter.Id;
				}
				else
				{
					    
				}
			}
           
            return RedirectToAction("ReadChapters", new {novelId = id, chapterId = chapterId});
        }

        public async Task<IActionResult> ReadChapter(int novelId, int? chapterId = null)
		{
            userId = _userManager.GetUserId(User);
         //   var chapterHistory = await _novelHistory.GetHistories(userId,novelId);
                 if (chapterId != null)
                 {
                     var checkHistory = await _novelHistory.CheckHistory(userId, (int) chapterId);
                     if (!checkHistory)
                     {
                         // add history 
                         await _novelHistory.AddHistory(new NovelChapterHistory()
                         {
                             UserId = userId,
                             ChapterId = (int) chapterId,
                             DateAdded = DateTime.UtcNow,
                             LastOpened = DateTime.UtcNow,
                             NovelId = novelId
                         });
                         await    _novelHistory.Save();
                     }
                 }

                 var lastViewed = await _novelHistory.GetLastHistory(userId, novelId);
                 if (lastViewed == null)
                 {
                     // add new history meaning no history  
                     var chapter = (await _novel.GetNovel(novelId)).Chapters.FirstOrDefault();
                     if (chapter != null)
                     {
                         await _novelHistory.AddHistory(new NovelChapterHistory()
                         {

                             UserId = userId,
                             ChapterId = chapter.Id,
                             DateAdded = DateTime.UtcNow,
                             LastOpened = DateTime.UtcNow,
                             NovelId = novelId
                         }); 
                         await    _novelHistory.Save();
                     }
                  
                     return View(chapter);
                 }
                 else
                 {
                     //get the novel first chapter 
                     var chapter = (await _novel.GetNovel(novelId)).Chapters.FirstOrDefault();
                     //add to history just in case something went wrong 
                     await _novelHistory.AddHistory(new NovelChapterHistory()
                     {
                         UserId = userId,
                         ChapterId = (int) chapter.Id,
                         DateAdded = DateTime.UtcNow,
                         LastOpened = DateTime.UtcNow,
                         NovelId = novelId
                     });
                     await _novelHistory.Save();
                     return View(chapter);
                 }
         
		}

        public async Task<IActionResult> ReadChapters(int novelId, int? page, int? chapterId = null)
        {
            int id = novelId;
            Webnovel.Entities.Novel novel = await _novel.GetNovel(id);
            ViewBag.NovelId = novelId;
            var pageNumber = page ?? 1;
            var chapters = (await _novel.GetNovelChaptersAsIQueryable(id));
            //var model = await PagingList.CreateAsync(chapters, 1, page);
            var model = chapters.ToPagedList( pageNumber, 1);
            userId = _userManager.GetUserId(User);
            chapterId =   model.FirstOrDefault().Id;
            if (model.IsFirstPage)
            {
                ViewBag.isFirst = true;
                ViewBag.hasPaid = true;
            }
            else
            {
                //check if user has paid 
                var hasPaid = await _novel.HasPaidForChapter(userId, (int) chapterId);
                var hasSubScription = await _payment.UserHasActiveSubscription(userId);
                if (hasPaid)
                {
                    ViewBag.hasPaid = true;
                }
                if (hasSubScription)
                {
                    ViewBag.hasPaid = true;
                }
             
                if (!hasPaid && !hasSubScription)
                {
                    ViewBag.hasPaid = false;
                    model.FirstOrDefault().Content = "";
                }
            }
            // get next page chapter 
            // and calculate the amount it will cost
            if (model.HasNextPage)
            {
                pageNumber += 1; 
                var nextChapter =  chapters.ToPagedList( pageNumber, 1).FirstOrDefault();
                var nextContent = nextChapter.Content == null ? " " : nextChapter.Content;
                var words = StringProcessor.CountWordsWithoutHtml(nextContent);
                var cowriesSpent = AppUtilities.CalculateCowriesToSpendOnWords(words);
                ViewBag.CowriesToSpentOnNext = cowriesSpent;
            }

            var content = model.FirstOrDefault().Content == null ? " " : model.FirstOrDefault().Content;
            ViewBag.CowriesToSpentOnCurrent = AppUtilities.CalculateCowriesToSpendOnWords(StringProcessor.CountWordsWithoutHtml(content)) ;;
          
            if (chapterId != null)
            {
                await _novelHistory.AddUniqueHistory(new NovelChapterHistory()
                {
                    UserId = userId,
                    ChapterId = (int)chapterId,
                    NovelId = novelId,
                    DateAdded = DateTime.UtcNow,
                    LastOpened = DateTime.Now
                });
            }
            return View(model);

        }

        public async Task<IActionResult> PayforChapter(int chapterId, double amount)
        {
            var chapter = await _novel.GetNovelChapter(chapterId);
            userId = _userManager.GetUserId(User);

            if (chapter == null) return Json(new { status=400, message="Chapter not found" }); 
            //get cost 
            var costOfContent =
                AppUtilities.CalculateCowriesToSpendOnWords(StringProcessor.CountWordsWithoutHtml(chapter.Content));
            if (amount < costOfContent)
            {
                return Json(new {status = "404", message = "Sorry, cowries is not enough to purchase this content"});
            }
            //deduct 
            var hasPaid = await _novel.HasPaidForChapter(userId, chapterId);
            var hasSub = await _payment.UserHasActiveSubscription(userId);
            if(hasSub)  return Json(new {status = "200", message = "You have unlimited access to this content, enjoy"});
            if (!hasPaid)
            {
                await _payment.AddOrUpdateUserCowries(new UserCowries()
                {
                    UserId = userId,
                    Cowries = -costOfContent
                });
             await   _payment.Save();
                await _novel.AddPaidChapterHistory(new PaidChapterHistory()
                {
                    UserId = userId,
                    DateTime = DateTime.UtcNow,
                    SpentInUsd = AppUtilities.CalculateUsd(costOfContent),
                    CowriesUsed = costOfContent,
                    ChapterId = chapterId,
                });
                await _novel.Save();
                return Json(new {status = "200", message = "Success! Payment Successful, Enjoy your content"});
            }
            else
            {
                return Json(new {status = "402", message = "Wow, It seems you have already paid for this content"});
            }
        }
		public async Task<IActionResult> Library()
		{
			userId = _userManager.GetUserId(User);
			return (IActionResult)(object)((Controller)this).View((object)(await _novel.GetLibraries(userId)));
		}

       

		//public async Task<IActionResult> ReadChapter(int id)
		//{
		//	userId = _userManager.GetUserId(User);
		//	return (IActionResult)(object)((Controller)this).ViewComponent(typeof(ReadChapterViewComponent), (object)new
		//	{
		//		chapterId = id,
		//		userId = userId
		//	});
		//}
         
		public async Task<IActionResult> EditChapterView(int id)
		{
			return (IActionResult)(object)((Controller)this).ViewComponent("EditChapter", (object)new
			{
				chapterId = id
			});
		}

		public async Task<IActionResult> DisplayChapterView(int id)
		{
			return (IActionResult)(object)((Controller)this).ViewComponent("DisplayChapter", (object)new
			{
				chapterId = id
			});
		}

		public async Task<IActionResult> ViewSection(int id)
        {
            return ViewComponent("ViewSection", new {Id = id});
            //return (IActionResult)(object)((Controller)this).PartialView("_ViewSection", (object)(await _novel.GetNovelSection(id)));
        }

		[HttpPost]
		public async Task<IActionResult> Publish(Chapter chapter)
		{
			Chapter chapter2 = await _novel.GetNovelChapter(chapter.Id);
			if (chapter2 == null)
			{
				return (IActionResult)(object)((Controller)this).Json((object)new
				{
					status = 400,
					message = "chapter Not Found"
				});
			}
			int num = StringProcessor.CountWordsWithoutHtml(chapter2.Content);
			if (num < 500)
			{
				return (IActionResult)(object)((Controller)this).Json((object)new
				{
					status = 400,
					message = "Sorry, Your Content should have a minimum of 500 words"
				});
			}
            //publish if today 
			if (chapter.DatePublished.Value.ToShortDateString() == DateTime.UtcNow.ToShortDateString())
			{
				chapter2.isPublished = true;
			}
			chapter2.DatePublished = chapter.DatePublished;
			chapter2.TimeZone = chapter.TimeZone;
			await _novel.UpdateChapter(chapter2);
			if (await _novel.Save())
			{
				return (IActionResult)(object)((Controller)this).Json((object)new
				{
					status = 200,
					message = "Published Successfully"
				});
			}
			return (IActionResult)(object)((Controller)this).Json((object)new
			{
				status = 400,
				message = "Something Went Wrong"
			});
		}

		public async Task<IActionResult> RemoveFromLibrary(int id)
		{
			userId = _userManager.GetUserId(User);
			await _novel.RemoveFromLibrary(id, userId);
			return (IActionResult)(object)((ControllerBase)this).RedirectToAction("Library");
		}

        public async Task<IActionResult> AddToLibrary(int id)
        {
            userId = _userManager.GetUserId(User); 
      
            await _novel.AddToLibrary(new NovelLibrary
            {
                UserId = userId,
                NovelId = id,

            });
            var save = await _novel.Save();
            if (save)
            {
                return Ok("Added to Library");
            }

            return BadRequest("Something went Wrong");

        }

		public async Task<IActionResult> Detail(int id)
		{
			Webnovel.Entities.Novel novel = await _novel.GetNovel(id);
			if (novel == null)
			{
				return (IActionResult)(object)((Controller)this).View("Error404");
			}
			return (IActionResult)(object)((Controller)this).View((object)novel);
		}

		public async Task<IActionResult> EditChapterDetail(int id)
		{
			return (IActionResult)(object)((Controller)this).PartialView("_EditChapterDetail", (object)(await _novel.GetNovelChapter(id)));
		}

		[HttpPost]
		public async Task<IActionResult> EditChapterDetail(Chapter chapter)
		{
			await _novel.EditNovelChapter(chapter);
			if (await _novel.Save())
			{
				return (IActionResult)(object)((Controller)this).Json((object)new
				{
					status = 200,
					message = "Edit was successful"
				});
			}
			return (IActionResult)(object)((Controller)this).Json((object)new
			{
				status = 400,
				message = "Something went wrong"
			});
		}

        
		public async Task<IActionResult> EditSection(int id)
		{
			return (IActionResult)(object)((Controller)this).PartialView("_EditSection", (object)(await _novel.GetNovelSection(id)));
		}

		[HttpPost]
		public async Task<IActionResult> EditSection(NovelSection novelSection)
		{
			await _novel.EditNovelSection(novelSection);
			if (await _novel.Save())
			{
				return (IActionResult)(object)((Controller)this).Json((object)new
				{
					status = 200,
					message = "Edit was successful"
				});
			}
			return (IActionResult)(object)((Controller)this).Json((object)new
			{
				status = 400,
				message = "Something went wrong"
			});
		}

		public async Task<IActionResult> DeleteChapter(int id)
		{
			Chapter chapter = await _novel.GetNovelChapter(id);
			await _novel.DeleteNovelChapter(chapter);
			if (await _novel.Save())
			{
				return (IActionResult)(object)((Controller)this).Json((object)new
				{
					status = 200,
					message = "Delete  was successful"
				});
			}
			return (IActionResult)(object)((Controller)this).Json((object)new
			{
				status = 400,
				message = "Unable to Delete"
			});
		}



		public async Task<IActionResult> DeleteSection(int id)
		{
			await _novel.DeleteNovelSection(id);
			if (await _novel.Save())
			{
				return (IActionResult)(object)((Controller)this).Json((object)new
				{
					status = 200,
					message = "delete was successful"
				});
			}
			return (IActionResult)(object)((Controller)this).Json((object)new
			{
				status = 400,
				message = "Unable to Delete"
			});
		}

        public async Task<ActionResult> ChangeStatus(ContentStatus status, int novelId)
        {
         var save = (await  _novel.ChangeStatus(status, novelId));
        
          if (save)
          {
              return Json(new
              {
                  status = 200, message = "Status Updated"
              });
          }
          return Json(new
          {
              status = 400, message = "Status Failed"
          });
        }

        public async Task<IActionResult> SaveRating(List<NovelRating> rating, string description)
        {
            var rate = rating.FirstOrDefault();
          

            if (rate != null)
            {
                if (!string.IsNullOrEmpty(description))
                {
                    var comment = new Entities.NovelComment()
                    {
                        UserId = rate.UserId,
                        Comment = description,
                        DateTime = DateTime.UtcNow,

                        NovelId = rate.NovelId
                    };
                    await _novel.AddNovelComment(comment); 
                    await _novel.Save();  
                    foreach (var i in rating)
                    {
                        i.CommentId = comment.Id;
                        await _rate.CreateNovelRate(i);
                       var s = await _rate.Save();
                    }
                   
                    return Json(new
                    {
                        status = 200, message = "Comment / Rating Saved"
                    });
                }
               
              
            }
            return Json(new
            {
                status = 500, message = "Failed to save"
            });
        }


        public async Task<IActionResult> ReportNovel(NovelReport report)
        {
            if (report.Message == null)
            {
                 return Json(new
                {
                    status = 500, message = "Content must be present"
                });
            }

          await  _novel.AddNovelReport(report);
          await _novel.Save();
          return Json(new
          {
              status = 200, message = "Complain Sent"
          });
        }

        [AllowAnonymous]
        public async Task<IActionResult> GetComment(int novelId, int page =1, int count = 3)
        {
            var reviews = await _comment.List(novelId);
            
            var mapped = Mapper.Map<IEnumerable<NovelCommentDto> >(reviews);
            var model = mapped.AsQueryable().ToPagedList(page,count);
            var pageData = new PaginationModel()
            {
                Count = model.Count,
                FirstItemOnPage = model.FirstItemOnPage,
                HasNextPage = model.HasNextPage,
                HasPreviousPage = model.HasPreviousPage,
                IsFirstPage = model.IsFirstPage,
                IsLastPage = model.IsLastPage,
                PageCount = model.PageCount,
                LastItemOnPage = model.LastItemOnPage,
                PageNumber = model.PageNumber,
                PageSize =  model.PageSize,
            };
            return Ok(new
            {
                data = model,
                page = pageData
            });
        }
    }
}
