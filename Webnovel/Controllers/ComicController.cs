using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webnovel.Components;
using Webnovel.Entities;
using Webnovel.Models;
using Webnovel.Repository;
using Webnovel.Services;

namespace Webnovel.Controllers
{
	[Authorize]
	public class ComicController : Controller
	{
		private UserManager<ApplicationUser> _userManager;

		private string userId;

		private IComic _comic;

		private IAuthor _author;

		public ComicController(UserManager<ApplicationUser> userManager, IComic comic, IAuthor author)
			
		{
			_comic = comic;
			_userManager = userManager;
			_author = author;
		}

		public async Task<IActionResult> Create()
		{
			userId = _userManager.GetUserId(User);
			ViewBag.Author = "";
			ComicVm i = new ComicVm();
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
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(ComicVm comic)
		{
			Webnovel.Entities.Comic mapped = Mapper.Map<Webnovel.Entities.Comic>((object)comic);
			if (ModelState.IsValid)
			{
				await _comic.CreateComic(mapped);
				if (await _comic.Save())
				{
					ComicVm data = Mapper.Map<ComicVm>((object)mapped);
                    ICollection<string> nTags = comic.NTags;
                    List<ComicTag> novelTag = new List<ComicTag>();
                    if (nTags != null)
                    {
                        foreach (string t in nTags)
                        {
                            if (!(await _comic.FindTag(t)))
                            {
                                await _comic.AddTag(new Tag
                                {
                                    Name = t
                                });
                                await _comic.Save();
                            }
                            Tag tag = await _comic.GetTag(t);
                            if (tag != null)
                            {
                                novelTag.Add(new ComicTag
                                {
                                    ComicId = data.Id,
                                    TagId = tag.Id
                                });
                                await _comic.Save();
                            }
                        }
                    }
                    //create scene 
                  await  _comic.CreateComicScene(new ComicScene()
                    {
                        ComicId = data.Id,
                        Title = "First Scence"
                    });
                  await _comic.Save();
                    return (IActionResult)(object)((Controller)this).Json((object)new
					{
						status = 200,
						message = "Check your entries",
						data = data
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

		public async Task<IActionResult> CoverPage(int id)
		{
			Webnovel.Entities.Comic comic = await _comic.GetComic(id);
			if (comic != null)
			{
				CoverPageVm coverPageVm = new CoverPageVm
				{
					Id = comic.Id
				};
				return (IActionResult)(object)((Controller)this).View((object)coverPageVm);
			}
			return (IActionResult)(object)((Controller)this).View("Error404");
		}

		[HttpPost]
		public async Task<IActionResult> CoverPage(CoverPageVm m)
		{
			if (ModelState.IsValid)
			{
				Webnovel.Entities.Comic comic = await _comic.GetComic(m.Id);
				if (comic == null)
				{
					return (IActionResult)(object)((Controller)this).Json((object)new
					{
						status = 401,
						message = "The Comic You are tring to update does not exist"
					});
				}
				if (!(await CloudinaryUpload.UploadToCloud(m.ImageData)))
				{
					return (IActionResult)(object)((Controller)this).Json((object)new
					{
						status = 500,
						message = "Something went wrong cant upload image now"
					});
				}
				if (comic.CoverPageImageUrl != null)
				{
					await CloudinaryUpload.DeleteFromCloud(comic.CoverPageImageUrl);
				}
				ComicVm comicVm = new ComicVm
				{
					Id = comic.Id,
					CategoryId = comic.CategoryId,
					AuthorId = comic.AuthorId,
					Title = comic.Title,
					Description = comic.Description,
					CoverPageImageUrl = CloudinaryUpload.uploadedPath
				};
				Mapper.Map<ComicVm, Webnovel.Entities.Comic>(comicVm, comic);
				if (await _comic.Save())
				{
					return (IActionResult)(object)((Controller)this).Json((object)new
					{
						status = 200,
						data = m,
						message = "Comic Was Successful"
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

		public async Task<IActionResult> Manage(int id)
		{
			Webnovel.Entities.Comic comic = await _comic.GetComic(id);
			if (comic == null)
			{
				return (IActionResult)(object)((Controller)this).View("Error404");
			}
			return (IActionResult)(object)((Controller)this).View((object)comic);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddSceneAsync(ComicSceneVm m)
		{
			if (!(await _comic.FindComic(m.ComicId)))
			{
				return (IActionResult)(object)((Controller)this).Json((object)new
				{
					status = 401,
					message = "Novel Not Found"
				});
			}
			ComicScene mapped = Mapper.Map<ComicScene>((object)m);
			if (ModelState.IsValid)
			{
				await _comic.CreateComicScene(mapped);
				if (await _comic.Save())
				{
					ComicSceneVm data = Mapper.Map<ComicSceneVm>((object)mapped);
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
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddEpisodeAsync(EpisodeVm m)
		{
			if (!(await _comic.FindComic(m.ComicId)))
			{
				return (IActionResult)(object)((Controller)this).Json((object)new
				{
					status = 401,
					message = "Novel Not Found"
				});
			}
			Episode mapped = Mapper.Map<Episode>((object)m);
			if (ModelState.IsValid)
			{
				await _comic.CreateEpisode(mapped);
				if (await _comic.Save())
				{
					EpisodeVm data = Mapper.Map<EpisodeVm>((object)mapped);
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

		public async Task<IActionResult> List()
		{
			userId = _userManager.GetUserId(User);
			Webnovel.Entities.Author author = await _author.Get(userId);
			if (author != null)
			{
				return (IActionResult)(object)((Controller)this).View((object)(await _comic.GetAuthorComics(author.Id)));
			}
			return (IActionResult)(object)((Controller)this).View((object)(await _comic.GetAuthorComics(0)));
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

		[HttpPost]
		public async Task<IActionResult> ChangePicture(int episodeId, string imgData)
		{
			if (!(await _comic.FindEpisode(episodeId)))
			{
				return (IActionResult)(object)((Controller)this).Json((object)new
				{
					status = 401,
					message = "Episode not found"
				});
			}
			if (imgData == null)
			{
				return (IActionResult)(object)((Controller)this).Json((object)new
				{
					status = 401,
					message = "No Image Found"
				});
			}
			Episode episode = await _comic.GetEpisode(episodeId);
			if (await CloudinaryUpload.UploadToCloud(imgData))
			{
				episode.ImageUrl = CloudinaryUpload.uploadedPath;
				if (!(await _comic.Save()))
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

		public async Task<IActionResult> SavedComics()
		{
			userId = _userManager.GetUserId(User);
			return (IActionResult)(object)((Controller)this).View((object)(await _comic.SavedComic(userId)));
		}

		public IActionResult DeleteSaveComic(int id)
		{
			userId = _userManager.GetUserId(User);
			Task task = _comic.DeleteSavedComic(id, userId);
			return (IActionResult)(object)((ControllerBase)this).RedirectToAction("SavedComics");
		}

		public async Task<IActionResult> Library()
		{
			userId = _userManager.GetUserId(User);
			return (IActionResult)(object)((Controller)this).View((object)(await _comic.GetLibrary(userId)));
		}

		public async Task<IActionResult> ReadComic(int id, int? chapterId = null)
		{
			userId = _userManager.GetUserId(User);
			Webnovel.Entities.Comic comic = await _comic.GetComic(id);
			if (!chapterId.HasValue)
			{
				Episode chapter = comic.Episodes.FirstOrDefault();
				if (comic.Episodes == null)
				{
					await _comic.AddToLibrary(new ComicLibrary
					{
						EpisodeId = Convert.ToInt32(chapterId),
						ComicId = id,
						UserId = userId
					});
					await _comic.Save();
					ViewBag.chapterId = Convert.ToInt32(chapterId);
				}
				else if (await _comic.CheckLibrary(chapter.Id))
				{
					ViewBag.chapterId = chapter.Id;
				}
				else
				{
					await _comic.AddToLibrary(new ComicLibrary
					{
						ComicId = id,
						EpisodeId = chapter.Id,
						UserId = userId
					});
					await _comic.Save();
					ViewBag.chapterId = chapter.Id;
				}
			}
			return (IActionResult)(object)((Controller)this).View((object)comic);
		}

		public async Task<IActionResult> DisplayEpisode(int id)
		{
			return (IActionResult)(object)((Controller)this).ViewComponent(typeof(DisplayEpisodeViewComponent), (object)new
			{
				epicId = id
			});
		}

        public async Task<IActionResult> SceneList(int id)
        {
            return ViewComponent(typeof(SceneListViewComponent), new { comicId = id });
        }
		public async Task<IActionResult> ReadEpisode(int id)
		{
			userId = _userManager.GetUserId(User);
			return (IActionResult)(object)((Controller)this).ViewComponent(typeof(ReadEpisodeViewComponent), (object)new
			{
				episodeId = id,
				userId = userId
			});
		}

        public async Task<IActionResult> ShowAllEpisode(int id)
        {
            return  ViewComponent(typeof(AllEpisodeViewComponent), new {comicId = id});
        }

        [HttpPost]
        public async Task<IActionResult> SaveEpisodes(int comicId, List<string> pictures)
        {
            // first save all pictures  and create episodes 
            //next take update the episode prefrence numbers using the last prefrencse number  
                await _comic.AddEpisodes(comicId, pictures); 
             //if(!await _comic.Save()) return Json(new {stats=400, message="Unable to save comic please try again later"});
            return Json(new { stats = 200, message = "Comic Saved Successfully" });
        }
        [HttpPost]
        public async Task<IActionResult> SortEpisodes(List<int> episodes)
        {
            await _comic.SortEpisodes(episodes);
            return Json(new { stats = 200, message = "Sorting Complete" });
        }
        public IActionResult RemoveFromLibrary(int id)
		{
            userId = _userManager.GetUserId(User);
			_comic.RemoveFromLibrary(id, userId);
			return (IActionResult)(object)((ControllerBase)this).RedirectToAction("Library");
		}
	}
}
