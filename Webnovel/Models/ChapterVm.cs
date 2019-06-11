using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webnovel.Models
{
    public class ChapterVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int NovelId { get; set; }
        //[ForeignKey("NovelId")]
        //public Novel Novel { get; set; }

        public int NovelSectionId { get; set; }
        //[ForeignKey("NovelSectionId")]
        //public NovelSection NovelSection { get; set; }
    }
}
