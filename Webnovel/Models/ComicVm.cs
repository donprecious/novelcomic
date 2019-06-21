using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webnovel.Models
{
    public class ComicVm
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title Required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description Required")]

        public string Description { get; set; }

        [Required(ErrorMessage = "You Need to be an Author ")]

        public int AuthorId { get; set; }

    
        public string CoverPageImageUrl { get; set; }


        //[ForeignKey("AuthorId")]
        //public Author Author { get; set; }
        [Required(ErrorMessage = "Category  Required")]

        public int CategoryId { get; set; }
        
        //[ForeignKey("CategoryId")]
        //public Category Category { get; set; }


        //public ICollection<Episode> Episodes { get; set; }
        //public  ICollection<ComicScene> ComicScenes { get; set; }

     }
}
