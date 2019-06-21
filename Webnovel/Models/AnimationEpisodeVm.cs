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
    public class AnimationEpisodeVm
    {

        public int Id { get; set; }
        
        [Required(ErrorMessage = "Title Required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Animation must be Selected")]

        public int  AnimationId { get; set; }

        [Required(ErrorMessage = "Animation or Video not found")]

        public string VideoUrl { get; set; }

        //[ForeignKey("AnimationId")]
        //public Animation Animation { get; set; }
    }
}
