using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Webnovel.Entities;

namespace Webnovel.Repository
{
    public interface INovelComment
    {
        Task Create(Entities.NovelComment comment);
        Task Delete(int Id);
        Task<ICollection<Entities.NovelComment>> List(int novelId);
        //Task<Entities.Author> Get(int authorId);
        //Task<Entities.Author> Get(string userId);


        //Task<bool> AuthorExist(string userId);
        Task<bool> Save();
    }

}
