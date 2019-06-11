using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webnovel.Models
{
    public class AuthorVm
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string UserId { get; set; }

        //[ForeignKey("UserId")]
        //public ApplicationUser User { get; set; }

        //public ICollection<Novel> Novels { get; set; }

    }
}
