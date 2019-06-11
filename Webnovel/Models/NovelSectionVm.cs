using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webnovel.Models
{
    public class NovelSectionVm
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string NovelId { get; set; }

        //[ForeignKey("NovelId")]
        //public Novel Novel { get; set; }

    }
}
