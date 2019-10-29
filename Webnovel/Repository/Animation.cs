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
using Webnovel.Models;

namespace Webnovel.Repository
{
	public class Animation : IAnimation
	{
		private ApplicationDbContext _context;

		public Animation(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task CreateAnimation(Webnovel.Entities.Animation animation)
		{
			animation.DateCreated = DateTime.UtcNow;
			await _context.Animations.AddAsync(animation, default(CancellationToken));
		}

		public async Task<List<Webnovel.Entities.Animation>> GetAllAnimations()
        {
            return await _context.Animations.Include(a => a.Author)
                .Include(a => a.Category)
                .Include(a => a.AnimationEpisodes)
                .ToListAsync();
        }

		public async Task<Webnovel.Entities.Animation> GetAnimation(int animationId)
		{
			return await EntityFrameworkQueryableExtensions.SingleOrDefaultAsync<Webnovel.Entities.Animation>(((IQueryable<Webnovel.Entities.Animation>)EntityFrameworkQueryableExtensions.Include<Webnovel.Entities.Animation, ICollection<AnimationEpisode>>((IQueryable<Webnovel.Entities.Animation>)EntityFrameworkQueryableExtensions.Include<Webnovel.Entities.Animation, Webnovel.Entities.Category>((IQueryable<Webnovel.Entities.Animation>)EntityFrameworkQueryableExtensions.Include<Webnovel.Entities.Animation, Webnovel.Entities.Author>((IQueryable<Webnovel.Entities.Animation>)_context.Animations, (Expression<Func<Webnovel.Entities.Animation, Webnovel.Entities.Author>>)((Webnovel.Entities.Animation a) => a.Author)), (Expression<Func<Webnovel.Entities.Animation, Webnovel.Entities.Category>>)((Webnovel.Entities.Animation a) => a.Category)), (Expression<Func<Webnovel.Entities.Animation, ICollection<AnimationEpisode>>>)((Webnovel.Entities.Animation a) => a.AnimationEpisodes))).Where((Webnovel.Entities.Animation a) => a.Id == animationId), default(CancellationToken));
		}

		public async Task<List<Webnovel.Entities.Animation>> GetAuthorAnimations(int id)
		{
			return await EntityFrameworkQueryableExtensions.ToListAsync<Webnovel.Entities.Animation>(((IQueryable<Webnovel.Entities.Animation>)_context.Animations).Where((Webnovel.Entities.Animation a) => a.AuthorId == id), default(CancellationToken));
		}

		public async Task DeleteAnimation(int id)
		{
			DbSet<Webnovel.Entities.Animation> animations = _context.Animations;
			animations.Remove(await _context.Animations.FindAsync(new object[1]
			{
				id
			}));
		}

		public async Task<bool> FindAnimation(int animationId)
		{
			return await EntityFrameworkQueryableExtensions.AnyAsync<Webnovel.Entities.Animation>((IQueryable<Webnovel.Entities.Animation>)_context.Animations, (Expression<Func<Webnovel.Entities.Animation, bool>>)((Webnovel.Entities.Animation a) => a.Id == animationId), default(CancellationToken));
		}

		public async Task CreateAnimationEpisode(AnimationEpisode animationEpisode)
		{
			await _context.AnimationEpisodes.AddAsync(animationEpisode, default(CancellationToken));
		}

		
		public async Task<bool> FindAnimationEpisode(int animationEpisodeId)
        {
         return   await _context.AnimationEpisodes.AnyAsync(a => a.Id == animationEpisodeId);
        }

		public async Task<ICollection<AnimationEpisode>> GetAnimationEpisodes(int animationId)
		{
			return await EntityFrameworkQueryableExtensions.ToListAsync<AnimationEpisode>(((IQueryable<AnimationEpisode>)_context.AnimationEpisodes).Where((AnimationEpisode a) => a.AnimationId == animationId), default(CancellationToken));
		}

		public async Task<AnimationEpisode> GetAnimationEpisode(int animationEpisodeId)
		{
			return await EntityFrameworkQueryableExtensions.SingleOrDefaultAsync<AnimationEpisode>(((IQueryable<AnimationEpisode>)_context.AnimationEpisodes).Where((AnimationEpisode a) => a.Id == animationEpisodeId), default(CancellationToken));
		}

		public async Task AddToSave(AnimationSaved comicLi)
		{
			await _context.AnimationSaveds.AddAsync(comicLi, default(CancellationToken));
		}

		public async Task<IEnumerable<AnimationSaved>> SavedAnimation(string userId)
		{
			return await EntityFrameworkQueryableExtensions.ToListAsync<AnimationSaved>((IQueryable<AnimationSaved>)EntityFrameworkQueryableExtensions.Include<AnimationSaved, ApplicationUser>((IQueryable<AnimationSaved>)EntityFrameworkQueryableExtensions.Include<AnimationSaved, Webnovel.Entities.Animation>(((IQueryable<AnimationSaved>)_context.AnimationSaveds).Where((AnimationSaved a) => a.UserId == userId), (Expression<Func<AnimationSaved, Webnovel.Entities.Animation>>)((AnimationSaved a) => a.Animation)), (Expression<Func<AnimationSaved, ApplicationUser>>)((AnimationSaved a) => a.User)), default(CancellationToken));
		}

		public async Task DeleteAnimationEpisode(AnimationEpisode animationEpisode)
		{
		    throw new NotFiniteNumberException();
		}

		public async Task AddToLibrary(AnimationLibrary library)
		{
			await _context.AnimationLibraries.AddAsync(library, default(CancellationToken));
		}

		public Task UpdateLibraryLastViewed(int id)
		{
            throw new NotFiniteNumberException();
        }

        public async Task RemoveFromLibrary(int id, string userid)
		{
			List<AnimationLibrary> list = await EntityFrameworkQueryableExtensions.ToListAsync<AnimationLibrary>(((IQueryable<AnimationLibrary>)_context.AnimationLibraries).Where((AnimationLibrary a) => a.UserId == userid && a.AnimationId == id), default(CancellationToken));
			_context.AnimationLibraries.RemoveRange((IEnumerable<AnimationLibrary>)list);
		}

		public async Task<IEnumerable<AnimationLibrary>> GetLibraries(string userId)
		{
			return await EntityFrameworkQueryableExtensions.ToListAsync<AnimationLibrary>((IQueryable<AnimationLibrary>)EntityFrameworkQueryableExtensions.Include<AnimationLibrary, Webnovel.Entities.Animation>(((IQueryable<AnimationLibrary>)_context.AnimationLibraries).Where((AnimationLibrary a) => a.UserId == userId), (Expression<Func<AnimationLibrary, Webnovel.Entities.Animation>>)((AnimationLibrary a) => a.Animation)), default(CancellationToken));
		}

		public async Task<bool> CheckLibrary(int chapterId)
		{
			return ((IQueryable<AnimationLibrary>)_context.AnimationLibraries).Any((AnimationLibrary a) => a.AnimationEpisodeId == chapterId);
		}

		public async Task AddTag(Tag tag)
		{
			await _context.Tags.AddAsync(tag, default(CancellationToken));
		}

		public async Task RemoveTag(Tag tag)
		{
			_context.Tags.Remove(tag);
		}

		public async Task AddAnimationTag(AnimationTag tag)
		{
			await _context.AnimationTags.AddAsync(tag, default(CancellationToken));
		}

		public async Task RemoveAnimationTag(AnimationTag tag)
		{
			_context.AnimationTags.Remove(tag);
		}

		public async Task<bool> Save()
		{
			return await((DbContext)_context).SaveChangesAsync(default(CancellationToken)) >= 0;
		}
	}
}
