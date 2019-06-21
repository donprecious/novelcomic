using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webnovel.Models
{
    public class ChapterVm
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Chapter Title or Name Required")]
        public string Name { get; set; }

   
        public string Description { get; set; }

        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public int NovelId { get; set; }
        //[ForeignKey("NovelId")]
        //public Novel Novel { get; set; }

        public int NovelSectionId { get; set; }
        //[ForeignKey("NovelSectionId")]
        //public NovelSection NovelSection { get; set; }
    }
}
