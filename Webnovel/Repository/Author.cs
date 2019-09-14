using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Webnovel.Data;
using Webnovel.Entities;

namespace Webnovel.Repository
{
	public class Author : IAuthor
	{
		private ApplicationDbContext _context;

		public Author(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task Create(Webnovel.Entities.Author category)
		{
			await _context.Authors.AddAsync(category, default(CancellationToken));
		}

		public async Task Delete(int Id)
		{
			Webnovel.Entities.Author author = await _context.Authors.FindAsync(new object[1]
			{
				Id
			});
			_context.Authors.Remove(author);
		}

		public async Task<ICollection<Webnovel.Entities.Author>> List()
		{
			return await EntityFrameworkQueryableExtensions.ToListAsync<Webnovel.Entities.Author>((IQueryable<Webnovel.Entities.Author>)_context.Authors, default(CancellationToken));
		}

	
		public async Task<Webnovel.Entities.Author> Get(int authorId)
        {
            return await _context.Authors.FindAsync(authorId);
        }

		public async Task<Webnovel.Entities.Author> Get(string userId)
		{

			return await _context.Authors.Where(a => a.UserId == userId).FirstOrDefaultAsync();
		}

		public async Task<bool> AuthorExist(string userId)
		{
			return await EntityFrameworkQueryableExtensions.AnyAsync<Webnovel.Entities.Author>((IQueryable<Webnovel.Entities.Author>)_context.Authors, (Expression<Func<Webnovel.Entities.Author, bool>>)((Webnovel.Entities.Author a) => a.UserId == userId), default(CancellationToken));
		}

		public async Task<bool> Save()
		{
			return await((DbContext)_context).SaveChangesAsync(default(CancellationToken)) >= 0;
		}
	}
}
