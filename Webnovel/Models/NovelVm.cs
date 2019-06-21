using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webnovel.Models
{
    public class NovelVm
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Novel Title Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Novel Description")]

        public string Title { get; set; }

        [Required(ErrorMessage = "Author is Required")]

        public int AuthorId { get; set; }

        //[ForeignKey("AuthorId")]
        //public Author Author { get; set; }
        [Required(ErrorMessage = "Category Required")]

        public int CategoryId { get; set; }

        //[ForeignKey("CategoryId")]
        //public Category Category { get; set; }


        //public ICollection<Chapter> Chapters { get; set; }
        //public ICollection<NovelSection> NovelSections { get; set; }

    }
}
