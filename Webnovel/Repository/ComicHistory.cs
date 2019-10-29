using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Webnovel.Data;

namespace Webnovel.Repository
{
    public class ComicHistory :IComicHistory
    {
        
        private ApplicationDbContext _context;

        public ComicHistory(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddUniqueHistory(Entities.ComicHistory history)
        {
            var histories = await _context.ComicHistory
                .Where(a => a.UserId == history.UserId && a.EpisodeId == history.EpisodeId)
                .FirstOrDefaultAsync();
            if (histories == null)
            {
                //no record add 
             await   _context.ComicHistory.AddAsync(history);
             await Save();
            }
            else
            {
                // update last viewed 
                histories.LastOpened = history.LastOpened;
                _context.Entry(histories).State = EntityState.Modified;
              await  Save();
            }
        }

        public async Task<ICollection<Entities.ComicHistory>> GetComicHistoryTask(string userId)
        {
            var his = await _context.ComicHistory.Where(a => a.UserId == userId)
                .Include(a => a.Comic)
                .ToListAsync();
                ;
                return his;
        }
        public async Task<ICollection<Entities.ComicHistory>> GetComicHistoryTask(string userId, int comicId)
        {
            var his = await _context.ComicHistory.Where(a => a.UserId == userId && a.ComicId == comicId)
                .Include(a => a.Comic)
                .ToListAsync();
            ;
            return his;
        }
        public async Task<bool> Save()
        {
            return await((DbContext)_context).SaveChangesAsync(default(CancellationToken)) >= 0;
        }
    }
}
