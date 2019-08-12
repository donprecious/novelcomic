using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Webnovel.Entities;

namespace Webnovel.Repository
{
  

    public interface IAuthor
    {
        Task Create(Entities.Author category);
        Task Delete(int Id);
        Task<ICollection<Entities.Author>> List();
        Task<Entities.Author> Get(int authorId);
        Task<Entities.Author> Get(string userId);


        Task<bool> AuthorExist(string userId);
        Task<bool> Save();
    }
}
