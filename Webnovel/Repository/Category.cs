using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Webnovel.Data;
using Webnovel.Entities;

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

		
		public async Task Delete(int Id)
        {
            var find = await _context.Categories.FindAsync(Id);
            _context.Categories.Remove(find);
        }

		public async Task<ICollection<Webnovel.Entities.Category>> List()
		{
			return await EntityFrameworkQueryableExtensions.ToListAsync<Webnovel.Entities.Category>((IQueryable<Webnovel.Entities.Category>)_context.Categories, default(CancellationToken));
		}

		public async Task<bool> Save()
		{
			return await((DbContext)_context).SaveChangesAsync(default(CancellationToken)) >= 0;
		}
	}
}
