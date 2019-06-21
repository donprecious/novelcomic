using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Webnovel.Data;

namespace Webnovel.Repository
{
    public class Author :IAuthor
    {
        private ApplicationDbContext _context;
        public Author(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Create(Entities.Author category)
        {
            await _context.Authors.AddAsync(category);
        }

        public async Task Delete(int Id)
        {
            var r = await _context.Authors.FindAsync(Id);
           _context.Authors.Remove(r);
        }

        public async Task<ICollection<Entities.Author>> List()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Entities.Author> Get(int authorId)
        {
            throw new NotImplementedException();
        }

        public async Task<Entities.Author> Get(string userId)
        {
            var author = await _context.Authors.Where(a => a.UserId == userId).FirstOrDefaultAsync();
            return author;
        }

        public async Task<bool> AuthorExist(string userId)
        {
            return await _context.Authors.AnyAsync(a => a.UserId == userId);
        }

        public async Task<bool> Save()
        {
            return ((await _context.SaveChangesAsync()) >= 0);

        }
    }
}
