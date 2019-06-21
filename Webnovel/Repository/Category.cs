using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Webnovel.Data;

namespace Webnovel.Repository
{
    public class Category:ICategory
    {
        private ApplicationDbContext _context;
        public Category(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Create(Entities.Category category)
        {
            await _context.Categories.AddAsync(category);
        }

        public async Task Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Entities.Category>> List()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<bool> Save()
        {
            return ((await _context.SaveChangesAsync()) >= 0);

        }
    }
}
