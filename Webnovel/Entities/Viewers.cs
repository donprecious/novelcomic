using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Webnovel.Entities
{
    public class Viewers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        } 
        public DateTime  Date{get;
            set;
        } 

        public string BrowserAgent { get; set; }
   public string IpAddress { get; set; } 

   public string UserId { get; set; }

    }

    public class NovelViewer: Viewers
    {
        public int NovelId { get; set; }
        [ForeignKey("NovelId")]
       public Novel Novel { get; set; }

    }

    public class ComicViewer : Viewers
    {
        public int ComicId { get; set; }

        [ForeignKey("ComicId")]
        public Comic Comic { get; set; }
    }
}
