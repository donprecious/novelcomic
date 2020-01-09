using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webnovel.Entities;

namespace Webnovel.Repository
{
   public interface IRate
   {
       Task CreateNovelRate(NovelRating rate);
        Task CreateRateType(RatingType ratingType);

        Task CreateComicRate(ComicRating rate);
        Task<ICollection<NovelRating>> GetNovelRating(int novelId);
       Task<NovelRating> GetNovelUserNovelRating(int novelId, string userId);
       Task<bool> HasUserRatedNovel(int novelId, string userId);
       Task<ICollection<ComicRating>> GetComicRating(int comicId);
       Task<double> GetComicRateAverage(int comicId);
       Task<double> GetNovelRateAverage(int novelId);
        Task<ICollection<RatingType>> RatingType();
        Task<bool> Save();
   }
}
