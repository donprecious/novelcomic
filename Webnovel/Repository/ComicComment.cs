using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Webnovel.Data;
using Webnovel.Entities;

namespace Webnovel.Repository
{
    public class ComicComment : IComicComment
    {
        private ApplicationDbContext _context;
        public ComicComment(ApplicationDbContext context)
        {
            _context = context;
        } 
        
        public async Task Create(Entities.ComicComment comment)
        {
            await _context.ComicComments.AddAsync(comment);
        }

        public async Task Delete(int Id)
        {
            _context.ComicComments.Remove(await _context.ComicComments.FindAsync(Id));
        }

        public async Task<ICollection<Entities.ComicComment>> List(int comicId)
        {
            return await _context.ComicComments.Where(a => a.ComicId == comicId).ToListAsync();
        }

        public async Task<bool> Save()
        {
            return ((await _context.SaveChangesAsync()) >= 0);
        }
    }
}
