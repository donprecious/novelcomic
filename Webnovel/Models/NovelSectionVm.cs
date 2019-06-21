using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webnovel.Models
{
    public class NovelSectionVm
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "Title is Required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Novel is Required")]

        public int NovelId { get; set; }

        //[ForeignKey("NovelId")]
        //public Novel Novel { get; set; }

    }
}
