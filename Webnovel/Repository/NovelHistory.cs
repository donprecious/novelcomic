using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Webnovel.Data;
using Webnovel.Entities;

namespace Webnovel.Repository
{
    public class NovelHistory :INovelHistory
    {

        private ApplicationDbContext _context;

        public NovelHistory(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<NovelChapterHistory>> GetHistories(string userId, int novelId)
        {
            var history = await _context.NovelChapterHistories.Where(a => a.UserId == userId && a.NovelId == novelId)
                .Include(a => a.Chapter)
                .Include(a => a.User).ToListAsync();
            return history;
        }

        public async Task<bool> CheckHistory(string userId, int chapterId)
        {
            return await _context.NovelChapterHistories.AnyAsync(a => a.UserId == userId && a.ChapterId == chapterId );
        }

        public async Task<NovelChapterHistory> GetLastHistory(string userId, int novelId)
        {
            var last = await _context.NovelChapterHistories
                .Where(a => a.UserId == userId && a.NovelId == novelId)
                .Include(a=>a.User)
                .Include(a=>a.Chapter)
                .OrderByDescending(a=>a.LastOpened)
                .FirstOrDefaultAsync();
            return last;
        }

        public async Task AddHistory(NovelChapterHistory chapterHistory)
        {
            await _context.NovelChapterHistories.AddAsync(chapterHistory);
        } 

        public async Task<bool> Save()
        {
            return await((DbContext)_context).SaveChangesAsync(default(CancellationToken)) >= 0;
        }
    }
}
