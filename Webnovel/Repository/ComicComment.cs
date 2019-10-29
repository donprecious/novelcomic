using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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

		public async Task Create(Webnovel.Entities.ComicComment comment)
		{
			await _context.ComicComments.AddAsync(comment, default(CancellationToken));
		}

		public async Task Delete(int Id)
		{
			DbSet<Webnovel.Entities.ComicComment> comicComments = _context.ComicComments;
			comicComments.Remove(await _context.ComicComments.FindAsync(new object[1]
			{
				Id
			}));
		}

		public async Task<ICollection<Webnovel.Entities.ComicComment>> List(int comicId)
		{
			return await EntityFrameworkQueryableExtensions.ToListAsync<Webnovel.Entities.ComicComment>(((IQueryable<Webnovel.Entities.ComicComment>)_context.ComicComments).Where((Webnovel.Entities.ComicComment a) => a.ComicId == comicId), default(CancellationToken));
		}

		public async Task<bool> Save()
		{
			return await((DbContext)_context).SaveChangesAsync(default(CancellationToken)) >= 0;
		}
	}
}
