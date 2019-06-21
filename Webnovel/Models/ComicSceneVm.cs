using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Webnovel.Models;

namespace Webnovel.Models
{
    public class ComicSceneVm
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title Required")]

        public string Title { get; set; }

        [Required(ErrorMessage = "A Comic Need to be selected or Present")]
        public int  ComicId { get; set; }

        //[ForeignKey("ComicId")]
        //public Comic Comic { get; set; }
   
        //public ICollection<Episode> Episodes { get; set; }
       

    }
}
