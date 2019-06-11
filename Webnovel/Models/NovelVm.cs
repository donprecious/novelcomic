using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webnovel.Models
{
    public class NovelVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }

        public int AuthorId { get; set; }

        //[ForeignKey("AuthorId")]
        //public Author Author { get; set; }

        public int CategoryId { get; set; }

        //[ForeignKey("CategoryId")]
        //public Category Category { get; set; }


        //public ICollection<Chapter> Chapters { get; set; }
        //public ICollection<NovelSection> NovelSections { get; set; }

    }
}
