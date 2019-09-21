using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Webnovel.Data;
using Webnovel.Entities;
using Webnovel.Models;

namespace Webnovel.Repository
{
	public class Comic : IComic
	{
		private ApplicationDbContext _context;

		public Comic(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task CreateComic(Webnovel.Entities.Comic comic)
		{
			comic.DateCreated = DateTime.UtcNow;
			await _context.Comics.AddAsync(comic, default(CancellationToken));
		}

		public async Task<List<Webnovel.Entities.Comic>> GetAllComics()
		{
			return await EntityFrameworkQueryableExtensions.ToListAsync<Webnovel.Entities.Comic>((IQueryable<Webnovel.Entities.Comic>)_context.Comics, default(CancellationToken));
		}

		public async Task<Webnovel.Entities.Comic> GetComic(int comicId)
		{
			return await EntityFrameworkQueryableExtensions.SingleOrDefaultAsync<Webnovel.Entities.Comic>(((IQueryable<Webnovel.Entities.Comic>)EntityFrameworkQueryableExtensions.Include<Webnovel.Entities.Comic, ICollection<ComicScene>>((IQueryable<Webnovel.Entities.Comic>)EntityFrameworkQueryableExtensions.Include<Webnovel.Entities.Comic, ICollection<Episode>>((IQueryable<Webnovel.Entities.Comic>)EntityFrameworkQueryableExtensions.Include<Webnovel.Entities.Comic, Webnovel.Entities.Category>((IQueryable<Webnovel.Entities.Comic>)EntityFrameworkQueryableExtensions.Include<Webnovel.Entities.Comic, Webnovel.Entities.Author>((IQueryable<Webnovel.Entities.Comic>)_context.Comics, (Expression<Func<Webnovel.Entities.Comic, Webnovel.Entities.Author>>)((Webnovel.Entities.Comic a) => a.Author)), (Expression<Func<Webnovel.Entities.Comic, Webnovel.Entities.Category>>)((Webnovel.Entities.Comic a) => a.Category)), (Expression<Func<Webnovel.Entities.Comic, ICollection<Episode>>>)((Webnovel.Entities.Comic a) => a.Episodes)), (Expression<Func<Webnovel.Entities.Comic, ICollection<ComicScene>>>)((Webnovel.Entities.Comic a) => a.ComicScenes))).Where((Webnovel.Entities.Comic a) => a.Id == comicId), default(CancellationToken));
		}

		public async Task AddUpdateToLibrary(ComicLibrary comicLibrary)
		{
			ComicLibrary comicLibrary2 = await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync<ComicLibrary>(((IQueryable<ComicLibrary>)_context.ComicLibraries).Where((ComicLibrary a) => a.ComicId == comicLibrary.ComicId && a.UserId == comicLibrary.UserId), default(CancellationToken));
			if (comicLibrary2 == null)
			{
				_context.ComicLibraries.Add(comicLibrary);
			}
			else
			{
				comicLibrary2.LastViewedId = comicLibrary.LastViewedId;
			}
		}

		public async Task<IEnumerable<ComicLibrary>> GetLibrary(string userId)
		{
			return await EntityFrameworkQueryableExtensions.ToListAsync<ComicLibrary>((IQueryable<ComicLibrary>)EntityFrameworkQueryableExtensions.Include<ComicLibrary, ICollection<Episode>>((IQueryable<ComicLibrary>)EntityFrameworkQueryableExtensions.Include<ComicLibrary, Webnovel.Entities.Comic>(((IQueryable<ComicLibrary>)_context.ComicLibraries).Where((ComicLibrary a) => a.UserId == userId), (Expression<Func<ComicLibrary, Webnovel.Entities.Comic>>)((ComicLibrary a) => a.Comic)), (Expression<Func<ComicLibrary, ICollection<Episode>>>)((ComicLibrary a) => a.Comic.Episodes)), default(CancellationToken));
		}

		public async Task AddToLibrary(ComicLibrary comicLibrary)
		{
			await _context.ComicLibraries.AddAsync(comicLibrary, default(CancellationToken));
		}


		public async Task UpdateLibraryLastViewed(int id, int episodeId)
        {
          var f =  _context.ComicLibraries.Find(id);
          f.LastViewedId = episodeId;
          _context.Entry(f).State = EntityState.Modified;
        }

		public async Task RemoveFromLibrary(int id, string userid)
		{
			List<ComicLibrary> list = await EntityFrameworkQueryableExtensions.ToListAsync<ComicLibrary>(((IQueryable<ComicLibrary>)_context.ComicLibraries).Where((ComicLibrary a) => a.ComicId == id && a.UserId == userid), default(CancellationToken));
			_context.ComicLibraries.RemoveRange((IEnumerable<ComicLibrary>)list);
		}

		public async Task<bool> CheckLibrary(int chapterId)
		{
			return ((IQueryable<ComicLibrary>)_context.ComicLibraries).Any((ComicLibrary a) => a.EpisodeId == chapterId);
		}

		public async Task<List<Webnovel.Entities.Comic>> GetAuthorComics(int id)
		{
			return await EntityFrameworkQueryableExtensions.ToListAsync<Webnovel.Entities.Comic>(((IQueryable<Webnovel.Entities.Comic>)_context.Comics).Where((Webnovel.Entities.Comic a) => a.AuthorId == id), default(CancellationToken));
		}

		public async Task DeleteComic(int id)
		{
			DbSet<Webnovel.Entities.Comic> comics = _context.Comics;
			comics.Remove(await _context.Comics.FindAsync(new object[1]
			{
				id
			}));
		}

		public async Task EditComic(Webnovel.Entities.Comic comic)
		{
		}

		public async Task<bool> FindComic(int comicId)
		{
			return await EntityFrameworkQueryableExtensions.AnyAsync<Webnovel.Entities.Comic>((IQueryable<Webnovel.Entities.Comic>)_context.Comics, (Expression<Func<Webnovel.Entities.Comic, bool>>)((Webnovel.Entities.Comic a) => a.Id == comicId), default(CancellationToken));
		}

		public async Task CreateComicScene(ComicScene comicScene)
		{
			await _context.ComicScenes.AddAsync(comicScene, default(CancellationToken));
		}

		public async Task<ICollection<ComicScene>> GetComicScenes(int comicId)
		{
			return await EntityFrameworkQueryableExtensions.ToListAsync<ComicScene>((IQueryable<ComicScene>)EntityFrameworkQueryableExtensions.Include<ComicScene, ICollection<Episode>>(((IQueryable<ComicScene>)_context.ComicScenes).Where((ComicScene a) => a.ComicId == comicId), (Expression<Func<ComicScene, ICollection<Episode>>>)((ComicScene a) => a.Episodes)), default(CancellationToken));
		}


		public async Task<ComicScene> GetComicScene(int sectionId)
        {
          return  await _context.ComicScenes.Include(a => a.Comic).Include(a => a.Episodes).Where(a => a.Id == sectionId).SingleOrDefaultAsync();
        }

		
		public async Task EditComicScene(ComicScene comicScene)
        {
            _context.Entry(comicScene).State = EntityState.Modified;
        }

        public async Task DeleteComicScene()
        {
            throw new NotImplementedException();
        }


        public async Task CreateEpisode(Episode episode)
		{
			await _context.Episodes.AddAsync(episode, default(CancellationToken));
		}

		public async Task<bool> FindEpisode(int episodeId)
		{
			return await EntityFrameworkQueryableExtensions.AnyAsync<Episode>((IQueryable<Episode>)_context.Episodes, (Expression<Func<Episode, bool>>)((Episode a) => a.Id == episodeId), default(CancellationToken));
		}

	
		public async Task<IEnumerable<Episode>> GetEpisodes(int comicId)
        {
            return await _context.Episodes.Where(a=>a.ComicId== comicId).ToListAsync();
        }

		public async Task<Episode> GetEpisode(int episodeId)
		{
			return await EntityFrameworkQueryableExtensions.SingleOrDefaultAsync<Episode>(((IQueryable<Episode>)_context.Episodes).Where((Episode a) => a.Id == episodeId), default(CancellationToken));
		}


		public async Task EditEpisode(EpisodeVm episode)
        {
            _context.Entry(episode).State = EntityState.Modified; 
        }

	
		public async Task DeleteEpisode(Episode episode)
        {
            _context.Episodes.Remove(episode);
        }

		public async Task AddToSave(ComicSaved comicLibrary)
		{
			await _context.ComicSaveds.AddAsync(comicLibrary, default(CancellationToken));
		}

		public async Task DeleteSavedComic(int comicId, string userId)
		{
			List<ComicSaved> list = await EntityFrameworkQueryableExtensions.ToListAsync<ComicSaved>(((IQueryable<ComicSaved>)_context.ComicSaveds).Where((ComicSaved a) => a.ComicId == comicId && a.UserId == userId), default(CancellationToken));
			_context.ComicSaveds.RemoveRange((IEnumerable<ComicSaved>)list);
		}

		public async Task<IEnumerable<ComicSaved>> SavedComic(string userId)
		{
			return await EntityFrameworkQueryableExtensions.ToListAsync<ComicSaved>((IQueryable<ComicSaved>)EntityFrameworkQueryableExtensions.Include<ComicSaved, ApplicationUser>((IQueryable<ComicSaved>)EntityFrameworkQueryableExtensions.Include<ComicSaved, Webnovel.Entities.Comic>(((IQueryable<ComicSaved>)_context.ComicSaveds).Where((ComicSaved a) => a.UserId == userId), (Expression<Func<ComicSaved, Webnovel.Entities.Comic>>)((ComicSaved a) => a.Comic)), (Expression<Func<ComicSaved, ApplicationUser>>)((ComicSaved a) => a.User)), default(CancellationToken));
		}

		public async Task AddTag(Tag tag)
		{
			await _context.Tags.AddAsync(tag, default(CancellationToken));
		}

		public async Task RemoveTag(Tag tag)
		{
			_context.Tags.Remove(tag);
		}

		public async Task AddComicTag(ComicTag tag)
		{
			await _context.ComicTags.AddAsync(tag, default(CancellationToken));
		}

		public async Task RemoveComicTag(ComicTag tag)
		{
			_context.ComicTags.Remove(tag);
		}

        public async Task<bool> FindTag(string tag)
        {
            return await _context.Tags.AnyAsync(a => a.Name == tag);
        }
        public async Task<Tag> GetTag(string tag)
        {
            return await _context.Tags.Where(a => a.Name == tag).FirstOrDefaultAsync();
        }
        public async Task<ICollection<Tag>> GetTags()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task AddEpisodes(int comicId, List<string> pictures)
        {
            var episodes = new List<Episode>();
            var scence = await GetComicScenes(comicId);
            var sceneId = 0;
            if (scence != null)
            {
                sceneId = scence.FirstOrDefault().Id;
            }
            else
            {
                //create a new scence  
                var x = await _context.ComicScenes.AddAsync(new ComicScene()
                {
                    ComicId = comicId,
                    Title = "Default"
                });
             await  _context.SaveChangesAsync();
             sceneId = x.Entity.Id;
            }
            foreach (var i in pictures)
            {
                //episodes.Add(new Episode()
                //{
                //    ImageUrl = i 
                //}); 
                _context.Episodes.Add(new Episode()
                {
                    ImageUrl = i, 
                    ComicId = comicId,
                    ComicSceneId = sceneId
                });
            await  _context.SaveChangesAsync();
            }
            //await _context.Episodes.AddRangeAsync(episodes);
        }

        public async Task SortEpisodes( List<int> episodes)
        {
            // get current episodes  
            var order = 1;
        
            //var epics = await _context.Episodes.Where(a => a.ComicId == comicId).ToListAsync();
            foreach (var i in episodes)
            {
                var epics = await _context.Episodes.FindAsync(i);
                if (epics != null)
                {
                    epics.Preference = order;
                    order += 1;
                    _context.Entry(epics).State = EntityState.Modified;
                  await  _context.SaveChangesAsync();
                }
               
            }
          
           
        }
        public async Task<bool> Save()
		{
			return await((DbContext)_context).SaveChangesAsync(default(CancellationToken)) >= 0;
		}

    
    }
}
