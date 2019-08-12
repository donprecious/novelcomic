using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Webnovel.Entities;

namespace Webnovel.Repository
{
    public interface IComicComment
    {
        Task Create(Entities.ComicComment comment);
        Task Delete(int Id);
        Task<ICollection<Entities.ComicComment>> List(int novelId);
      
        Task<bool> Save();
    }

}
