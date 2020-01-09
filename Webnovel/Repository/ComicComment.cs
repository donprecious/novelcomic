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

        public async Task<Entities.ComicComment> GetComment(int id)
        {
            var comment = await _context.ComicComments.Where(a => a.Id == id)
                .Include(a=>a.User)
                .Include(a=>a.Comic)
                .SingleOrDefaultAsync();
            return comment;
        }
		public async Task<ICollection<Webnovel.Entities.ComicComment>> List(int comicId)
        {
            return await _context.ComicComments.Where(a => a.ComicId == comicId)
                .Include(a => a.User)
                .Include(a => a.Comic).ToListAsync();

        }

		public async Task<bool> Save()
		{
			return await((DbContext)_context).SaveChangesAsync(default(CancellationToken)) >= 0;
		}
	}
}
