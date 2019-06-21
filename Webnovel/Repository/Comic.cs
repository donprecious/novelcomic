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
          await  _context.Comics.AddAsync(comic);
        }

        public async Task<List<Entities.Comic>> GetAllComics()
        {
            throw new NotImplementedException();
        }

        public async Task<Entities.Comic> GetComic(int comicId)
        {
           return await _context.Comics.FindAsync(comicId);

        }

        public async Task<List<Entities.Comic>> GetAuthorComics(int id)
        {
         return   await _context.Comics.Where(a=>a.AuthorId == id).ToListAsync();
        }

        public async Task DeleteComic(int id)
        {
            throw new NotImplementedException();
        }

        public async Task EditComic(Entities.Comic comic)
        {
            //_context.Comics.Update(comic);
            //_context.Entry(comic).State = EntityState.Modified;

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

        public async Task<bool> Save()
        {
            return ((await _context.SaveChangesAsync()) >= 0);
        }
    }
}
