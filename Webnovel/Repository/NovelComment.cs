using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Webnovel.Data;
using Webnovel.Entities;

namespace Webnovel.Repository
{
    public class NovelComment : INovelComment
    {
        private ApplicationDbContext _context;
        public NovelComment(ApplicationDbContext context)
        {
            _context = context;
        } 
        
        public async Task Create(Entities.NovelComment comment)
        {
            await _context.NovelComments.AddAsync(comment);
        }

        public async Task Delete(int Id)
        {
            _context.NovelComments.Remove(await _context.NovelComments.FindAsync(Id));
        }

        public async Task<ICollection<Entities.NovelComment>> List(int novellId)
        {
            return await _context.NovelComments.Where(a => a.NovelId == novellId).ToListAsync();
        }

        public async Task<bool> Save()
        {
            return ((await _context.SaveChangesAsync()) >= 0);
        }
    }
}
