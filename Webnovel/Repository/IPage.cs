using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webnovel.Repository
{
   public interface IPage
   {
       Task CreatePage(Entities.Page page);
       Task<Entities.Page> GetPage(int pageId);
   
       Task<ICollection<Entities.Page>> GetPages();
       Task EditPage(Entities.Page page);
       Task<bool> Save();
   }
}
