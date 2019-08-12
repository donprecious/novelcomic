using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Webnovel.Entities;

namespace Webnovel.Repository
{
    public interface IAnimationComment
    {
        Task Create(Entities.AnimationComment comment);
        Task Delete(int Id);
        Task<ICollection<Entities.AnimationComment>> List(int novelId);

        Task<bool> Save();
    }

}
