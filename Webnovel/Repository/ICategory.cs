using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Webnovel.Entities;

namespace Webnovel.Repository
{
    public interface ICategory
    {
         Task Create(Entities.Category category);
        Task Delete(int Id);
        Task<ICollection<Entities.Category>> List();
        Task<bool> Save();
    }
}
