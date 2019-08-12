using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Webnovel.Entities;

namespace Webnovel.Models
{
    public class ComicCommentVm
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int Id { get; set; }
        public string UserId { get; set; }

        //[ForeignKey("UserId")]
        //public ApplicationUser User { get; set; }
        [Required(ErrorMessage = "Comment Required")]
        public string Comment { get; set; }
        public int CommentId { get; set; }

        //[ForeignKey("CommentId")]
        //public Comic Comic { get; set; }
    }
    public class AnimationCommentVm
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int Id { get; set; }
        public string UserId { get; set; }

        //[ForeignKey("UserId")]
        //public ApplicationUser User { get; set; }
        [Required(ErrorMessage = "Comment Required")]
        public string Comment { get; set; }
        public int AnimationId { get; set; }

        //[ForeignKey("AnimationId")]
        //public Animation Animation { get; set; }
    }
    public class NovelCommentVm
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserId { get; set; }

        //[ForeignKey("UserId")]
        //public ApplicationUser User { get; set; }
        [Required(ErrorMessage = "Comment Required")]
        public string Comment { get; set; }
        public int NovelId { get; set; }

        //[ForeignKey("NovelId")]
        //public Novel Novel { get; set; }
    }
}
