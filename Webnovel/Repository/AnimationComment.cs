using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Webnovel.Data;
using Webnovel.Entities;

namespace Webnovel.Repository
{
	public class AnimationComment : IAnimationComment
	{
		private ApplicationDbContext _context;

		public AnimationComment(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task Create(Webnovel.Entities.AnimationComment comment)
		{
			await _context.AnimationComments.AddAsync(comment, default(CancellationToken));
		}

		public async Task Delete(int Id)
		{
			DbSet<Webnovel.Entities.AnimationComment> animationComments = _context.AnimationComments;
			animationComments.Remove(await _context.AnimationComments.FindAsync(new object[1]
			{
				Id
			}));
		}

		public async Task<ICollection<Webnovel.Entities.AnimationComment>> List(int animationlId)
		{
			return await EntityFrameworkQueryableExtensions.ToListAsync<Webnovel.Entities.AnimationComment>(((IQueryable<Webnovel.Entities.AnimationComment>)_context.AnimationComments).Where((Webnovel.Entities.AnimationComment a) => a.AnimationId == animationlId), default(CancellationToken));
		}

		public async Task<bool> Save()
		{
			return await((DbContext)_context).SaveChangesAsync(default(CancellationToken)) >= 0;
		}
	}
}
