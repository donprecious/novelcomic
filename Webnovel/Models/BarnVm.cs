using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Webnovel.Models
{
    public class BarnVm
    {
        public IPagedList<Entities.NovelLibrary> Novels { get; set; }
        public IPagedList<Entities.ComicLibrary> Comics { get; set; }
    }
}
