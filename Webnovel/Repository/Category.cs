using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Webnovel.Data;
using Webnovel.Entities;
using Webnovel.Enum;

namespace Webnovel.Repository
{
	public class Category : ICategory
	{
		private ApplicationDbContext _context;

		public Category(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task Create(Webnovel.Entities.Category category)
		{
			await _context.Categories.AddAsync(category, default(CancellationToken));
		}

        public async Task Edit(Entities.Category category)
        {
            _context.Entry(category).State = EntityState.Modified;

        }
		
		public async Task Delete(int Id)
        {
            var find = await _context.Categories.FindAsync(Id);
            _context.Categories.Remove(find);
        }

        public async Task<bool> HasBeenUsed(int id)
        {
            var usedNovel = await _context.Novels.AnyAsync(a => a.CategoryId == id);
            var usedComic = await _context.Comics.AnyAsync(a => a.CategoryId == id);
            var usedani = await _context.Animations.AnyAsync(a => a.CategoryId == id);
            if (usedComic && usedNovel && usedani)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> EditStatusCategory(int id, EntityVisibilityStatus status)
        {
            var cat = await _context.Categories.FindAsync(id);
            if (cat != null)
            {
                cat.Status = status.ToString();
                _context.Entry(cat).State = EntityState.Modified;
                return await Save();
            }
            return false;
        }
        public async Task<Entities.Category> GetCategory(int id)
        {
            var cat = await _context.Categories.FindAsync(id);
            return cat;
        }

		public async Task<ICollection<Webnovel.Entities.Category>> List()
		{
			return await EntityFrameworkQueryableExtensions.ToListAsync<Webnovel.Entities.Category>((IQueryable<Webnovel.Entities.Category>)_context.Categories, default(CancellationToken));
		}

        public async Task<ICollection<Webnovel.Entities.Category>> List(EntityVisibilityStatus status)
        {
            return await _context.Categories.Where(a => a.Status != status.ToString()).ToListAsync();
        }
		public async Task<bool> Save()
		{
			return await((DbContext)_context).SaveChangesAsync(default(CancellationToken)) >= 0;
		}
	}
}
