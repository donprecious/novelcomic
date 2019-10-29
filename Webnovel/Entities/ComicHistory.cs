using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Webnovel.Models;

namespace Webnovel.Entities
{
    public class ComicHistory
    { 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get;   set; } 
        public int ComicId { get; set; } 
        [ForeignKey("ComicId")]
        public Comic Comic { get; set; }
        public int EpisodeId { get; set; }  
        [ForeignKey("EpisodeId")]
        public Episode Episode { get; set; }
        
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastOpened { get; set; }
    }
}
