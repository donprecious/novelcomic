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
    public class EpisodeVm
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name or Title Required")]
        public string Name { get; set; }

      
        public string Description { get; set; }

        //[Column(TypeName = "varchar(MAX)")]
        public string Content { get; set; }

        //[Required(ErrorMessage = "A Picture is Required")]
        public string ImageUrl { get; set; }

        public int ComicId { get; set; }
        //[ForeignKey("ComicId")]
        //public ComicVm Comic { get; set; }

        public int ComicSceneId { get; set; }
        //[ForeignKey("ComicSceneId")]
        //public ComicScene ComicScene{ get; set; }



    }
}
