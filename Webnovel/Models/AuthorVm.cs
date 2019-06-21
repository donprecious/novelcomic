using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webnovel.Models
{
    public class AuthorVm
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is Required" )]
        public string Title { get; set; }

        //[Required(ErrorMessage = "User is Required")]

        public string UserId { get; set; }

        //[ForeignKey("UserId")]
        //public ApplicationUser User { get; set; }

        //public ICollection<Novel> Novels { get; set; }

    }
}
