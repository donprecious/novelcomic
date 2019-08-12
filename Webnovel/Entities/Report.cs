using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Webnovel.Models;

namespace Webnovel.Entities
{
    public class ComicReport
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  

        public  int ComicId { get; set; }

        public string UserId { get; set; }

        public string Message { get; set; }


        [ForeignKey("ComicId")]
        public Comic Comic { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }

    public class AnimationReport
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int AnimationId { get; set; }

        public string UserId { get; set; }

        public string Message { get; set; }

        [ForeignKey("AnimationId")]
        public Animation Animation { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }

    public class NovelReport
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int NovelId { get; set; }

        public string UserId { get; set; }

        public string Message { get; set; }

        [ForeignKey("NovelId")]
        public Novel Novel { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
