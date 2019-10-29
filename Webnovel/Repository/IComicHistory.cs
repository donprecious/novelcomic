using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webnovel.Repository
{
  public  interface IComicHistory
  {
      Task AddUniqueHistory(Entities.ComicHistory history);
      Task<ICollection<Entities.ComicHistory>> GetComicHistoryTask(string userId);
      Task<ICollection<Entities.ComicHistory>> GetComicHistoryTask(string userId, int comicId);
  }
}
