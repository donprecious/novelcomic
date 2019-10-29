using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Webnovel.Models;

namespace Webnovel.Entities
{
    public class NovelChapterHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get;   set; } 
        public int NovelId { get; set; } 
        [ForeignKey("NovelId")]
        public Novel Novel { get; set; }
        public int ChapterId { get; set; }  
        [ForeignKey("ChapterId")]
        public Chapter Chapter { get; set; }
        
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastOpened { get; set; }
    }
}
