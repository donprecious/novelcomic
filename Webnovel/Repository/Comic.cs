using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Webnovel.Data;
using Webnovel.Entities;
using Webnovel.Models;

namespace Webnovel.Repository
{
    public class Comic: IComic
    {
        private ApplicationDbContext _context;
        public Comic(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateComic(Entities.Comic comic)
        {
            comic.DateCreated = DateTime.UtcNow;
          await  _context.Comics.AddAsync(comic);
        }

        public async Task<List<Entities.Comic>> GetAllComics()
        {
            return await _context.Comics.ToListAsync();
        }

        public async Task<Entities.Comic> GetComic(int comicId)
        {
           return await _context.Comics
               .Include(a=>a.Author).
               Include(a=>a.Category)
               .Include(a =>a.Episodes)
               .Include(a=>a.ComicScenes).
               Where(a=>a.Id == comicId).SingleOrDefaultAsync();

        }

        public async Task AddUpdateToLibrary(ComicLibrary comicLibrary)
        {
            // check if comic is in user Libary 

            var lib = await _context.ComicLibraries
                .Where(a => a.ComicId == comicLibrary.ComicId && a.UserId == comicLibrary.UserId).FirstOrDefaultAsync();
            if (lib == null)
            {
                _context.ComicLibraries.Add(comicLibrary);
            }
            else
            {
                //update last views 
                lib.LastViewedId = comicLibrary.LastViewedId;
            }

        }

        public async Task<IEnumerable<Entities.ComicLibrary>> GetLibrary(string userId)
        {
            var lib = await _context.ComicLibraries.Where(a => a.UserId == userId)
                .Include(a=>a.Comic)
                .Include(a=>a.Comic.Episodes)

                .ToListAsync();
            return lib; 
        }


        public async Task<List<Entities.Comic>> GetAuthorComics(int id)
        {
         return   await _context.Comics.Where(a=>a.AuthorId == id).ToListAsync();
        } 

        public async Task DeleteComic(int id)
        {
            _context.Comics.Remove(await _context.Comics.FindAsync(id));
        }

        public async Task EditComic(Entities.Comic comic)
        {
         
        }

        public async Task<bool> FindComic(int comicId)
        {
            return await _context.Comics.AnyAsync(a => a.Id == comicId);
        }

        public async Task CreateComicScene(ComicScene comicScene)
        {
          await  _context.ComicScenes.AddAsync(comicScene);
        }

        public async Task<ICollection<ComicScene>> GetComicScenes(int comicId)
        {
            return await _context.ComicScenes.Where(a => a.ComicId == comicId)
                .Include(a=>a.Episodes)
                .ToListAsync();
        }

        public async Task GetComicScene(int sectionId)
        {
            throw new NotImplementedException();
        }

        public async Task EditComicScene(ComicScene comicScene)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteComicScene()
        {
            throw new NotImplementedException();
        }

        public async Task CreateEpisode(Episode episode)
        {
            await _context.Episodes.AddAsync(episode);
        }

        public async Task<bool> FindEpisode(int episodeId)
        {
            return await _context.Episodes.AnyAsync(a => a.Id == episodeId);
        }

        public async Task GetEpisodes(int novelId)
        {
            throw new NotImplementedException();
        }

        public async Task<Episode> GetEpisode(int episodeId)
        {
            return await _context.Episodes.Where(a => a.Id == episodeId).SingleOrDefaultAsync();
        }

        public async Task EditEpisode(EpisodeVm episode)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteEpisode(Episode episode)
        {
            throw new NotImplementedException();
        }

        public async Task AddToSave(ComicSaved comicLibrary)
        {
         await _context.ComicSaveds.AddAsync(comicLibrary);
        }
        public async Task DeleteSavedComic(int comicId, string userId)
        {
            var find = await _context.ComicSaveds.Where(a => a.ComicId == comicId && a.UserId == userId).ToListAsync();
        _context.ComicSaveds.RemoveRange(find);
        }
        public async Task< IEnumerable<ComicSaved>> SavedComic(string userId)
        {
            return await _context.ComicSaveds.Where(a => a.UserId == userId)
                .Include(a=>a.Comic)
                .Include(a=>a.User)
                
                .ToListAsync();
        } 


        public async Task<bool> Save()
        {
            return ((await _context.SaveChangesAsync()) >= 0);
        }
    }
}
