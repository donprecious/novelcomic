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
            //var find = await _context.NovelRatings.Where(a => a.NovelId == rate.NovelId && a.UserId == rate.UserId).FirstOrDefaultAsync();
            //if (find == null)
            //{
            await _context.NovelRatings.AddAsync(rate);
        //}
        //    else
        //    {
        //        update it
        //        find.UserId = rate.UserId;
        //        find.Value = rate.Value;
        //        find.Description = rate.Description;
        //        _context.Entry(find).State = EntityState.Modified;
               
        //    }
}
        public async Task CreateComicRate(ComicRating rate)
        { 
            var find = await _context.ComicRatings.Where(a => a.ComicId == rate.ComicId && a.UserId == rate.UserId).FirstOrDefaultAsync();
            if (find == null)
            {
                await _context.ComicRatings.AddAsync(rate);
            }
            else
            {
                //update it 
                find.UserId = rate.UserId;
                find.Value = rate.Value;
                find.Description = rate.Description;
                _context.Entry(find).State = EntityState.Modified;
               
            }
        }

        public async Task<ICollection<NovelRating>> GetNovelRating(int novelId)
        {
            var list = await _context.NovelRatings.Where(a => a.NovelId == novelId).ToListAsync();
            return list;
        }  
        public async Task<ICollection<ComicRating>> GetComicRating(int comicId)
        {
            var list = await _context.ComicRatings.Where(a => a.ComicId == comicId).ToListAsync();
            return list;
        }

        public async Task CreateRateType(RatingType ratingType)
        {
            await _context.RatingTypes.AddAsync(ratingType);
        }



        public async Task<NovelRating> GetNovelUserNovelRating(int novelId, string userId)
        {
            var list = await _context.NovelRatings.Where(a => a.NovelId == novelId && a.UserId == userId).SingleOrDefaultAsync();
            return list;
        }

        public async Task<bool> HasUserRatedNovel(int novelId, string userId)
        {
         return await _context.NovelRatings.Where(a => a.NovelId == novelId && a.UserId == userId).AnyAsync();
        }

        public async Task<double> GetNovelRateAverage(int novelId)
        {
            var rates = await GetNovelRating(novelId);
            var totalValue = 0.0;
            foreach (var i in rates)
            {
                totalValue += i.Value;
            } 
            var rate = totalValue / rates.Count();
            if (!rates.Any())
            {
                rate = 0.0;
            }
            return Math.Round(rate,1, MidpointRounding.ToEven);
           
        }

        public async Task<double> GetComicRateAverage(int comicId)
        {
            var rates = await GetComicRating(comicId);
            var totalValue = 0.0;
          
            foreach (var i in rates)
            {
                totalValue += i.Value;
               
            }

            var rate = totalValue / rates.Count();
            if (!rates.Any())
            {
                rate = 0.0;
            }
            return Math.Round(rate,1, MidpointRounding.ToEven);
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
