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
       Task<ICollection<NovelRating>> NovelRatings(int novelId);
       Task<ICollection<RatingType>> RatingType();
       Task<bool> Save();
   }
}
