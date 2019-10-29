using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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

		public async Task Create(Webnovel.Entities.NovelComment comment)
		{
			await _context.NovelComments.AddAsync(comment, default(CancellationToken));
		}

        public async Task CreateChapterComment(Webnovel.Entities.ChapterComment comment)
        {
            await _context.ChapterComments.AddAsync(comment, default(CancellationToken));
        }


        public async Task<ChapterComment> GetChapterComment(int id)
        {
            return await _context.ChapterComments.Where(a => a.Id == id).Include(a => a.User).SingleOrDefaultAsync();
        }

        public async Task <IEnumerable<Entities.ChapterComment>> GetChapterComments(int id)
        {
            var replies = await _context.ChapterComments.Where(a => a.ChapterId == id).Include(a=>a.User).ToListAsync();
            return replies;

        }
		public async Task Delete(int Id)
		{
			DbSet<Webnovel.Entities.NovelComment> novelComments = _context.NovelComments;
			novelComments.Remove(await _context.NovelComments.FindAsync(new object[1]
			{
				Id
			}));
		}

		public async Task<ICollection<Webnovel.Entities.NovelComment>> List(int novellId)
		{
			return await EntityFrameworkQueryableExtensions.ToListAsync<Webnovel.Entities.NovelComment>(((IQueryable<Webnovel.Entities.NovelComment>)_context.NovelComments).Where((Webnovel.Entities.NovelComment a) => a.NovelId == novellId), default(CancellationToken));
		}

		public async Task<bool> Save()
		{
			return await((DbContext)_context).SaveChangesAsync(default(CancellationToken)) >= 0;
		}
	}
}
