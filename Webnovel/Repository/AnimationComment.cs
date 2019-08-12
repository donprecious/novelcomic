using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
        
        public async Task Create(Entities.AnimationComment comment)
        {
            await _context.AnimationComments.AddAsync(comment);
        }

        public async Task Delete(int Id)
        {
            _context.AnimationComments.Remove(await _context.AnimationComments.FindAsync(Id));
        }

        public async Task<ICollection<Entities.AnimationComment>> List(int animationlId)
        {
            return await _context.AnimationComments.Where(a => a.AnimationId == animationlId).ToListAsync();
        }

        public async Task<bool> Save()
        {
            return ((await _context.SaveChangesAsync()) >= 0);
        }
    }
}
