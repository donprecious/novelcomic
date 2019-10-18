using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Webnovel.Data;
using Webnovel.Entities;

namespace Webnovel.Repository
{
    public class Rate : IRate
    {
        private ApplicationDbContext _context;

        public Rate(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateNovelRate(NovelRating rate)
        {
            await _context.NovelRatings.AddAsync(rate);
        }

        public async Task CreateRateType(RatingType ratingType)
        {
            await _context.RatingTypes.AddAsync(ratingType);
        }

        public async Task<ICollection<NovelRating>> NovelRatings(int novelId)
        {
            var list = await _context.NovelRatings.Where(a => a.NovelId == novelId).ToListAsync();
            return list;
        }

        public async Task<ICollection<RatingType>> RatingType()
        {
            return await _context.RatingTypes.ToListAsync();
        }

        public async Task<bool> Save()
        {
            return await((DbContext)_context).SaveChangesAsync(default(CancellationToken)) >= 0;
        }

    }
}
