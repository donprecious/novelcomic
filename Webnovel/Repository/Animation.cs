using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Webnovel.Data;
using Webnovel.Entities;

namespace Webnovel.Repository
{
    public class Animation: IAnimation
    {

        private ApplicationDbContext _context;
        public Animation(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAnimation(Entities.Animation animation)
        {
            animation.DateCreated = DateTime.UtcNow;
            await _context.Animations.AddAsync(animation);
        }

        public async Task<List<Entities.Animation>> GetAllAnimations()
        {
            throw new NotImplementedException();
        }

        public async Task<Entities.Animation> GetAnimation(int animationId)
        {
            return await _context.Animations.FindAsync(animationId);
        }

        public async Task<List<Entities.Animation>> GetAuthorAnimations(int id)
        {
            return await _context.Animations.Where(a => a.AuthorId == id).ToListAsync();
        }

        public async Task DeleteAnimation(int id)
        {
              _context.Animations.Remove( await _context.Animations.FindAsync(id));
        }

        public async Task<bool> FindAnimation(int animationId)
        {
            return await _context.Animations.AnyAsync(a => a.Id == animationId);
        }

        public async Task CreateAnimationEpisode(AnimationEpisode animationEpisode)
        {
            await _context.AnimationEpisodes.AddAsync(animationEpisode);
        }

        public async Task<bool> FindAnimationEpisode(int animationEpisodeId)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Entities.AnimationEpisode>> GetAnimationEpisodes(int animationId)
        {
            return await _context.AnimationEpisodes.Where(a => a.AnimationId == animationId).ToListAsync();
        }

        public async Task<AnimationEpisode> GetAnimationEpisode(int animationEpisodeId)
        {
            return await _context.AnimationEpisodes.Where(a => a.Id== animationEpisodeId)
                .SingleOrDefaultAsync();
        }

        public async Task DeleteAnimationEpisode(AnimationEpisode animationEpisode)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Save()
        {
            return ((await _context.SaveChangesAsync()) >= 0);
        }
    }
}
