using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Webnovel.Models;

namespace Webnovel.Entities
{
    public class AnimationEpisode
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Title { get; set; }

        public int  AnimationId { get; set; }

        public string VideoUrl { get; set; }

        [ForeignKey("AnimationId")]
        public Animation Animation { get; set; }
    }
}
