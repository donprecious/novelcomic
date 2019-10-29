using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Webnovel.Models;

namespace Webnovel.Entities
{
    public class ChapterComment
    { 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }

        public int ChapterId {
            get;
            set;
        }

        public string UserId
        {
            get; set;
        }

        public string Comment { get; set; } 

        [ForeignKey("ChapterId")]
        public Chapter Chapter { get; set; } 

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; } 
        public DateTime? DateTime { get; set; }
        public  ICollection<ChapterCommentReply> ChapterCommentReplies { get; set; }
    }

    public class ChapterCommentReply
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }

        public int ChapterCommentId {
            get;
            set;
        } 

        public string UserId
        {
            get; set;
        }

        public string Comment { get; set; } 

        public DateTime? DateTime { get; set; }

        [ForeignKey("ChapterCommentId")]
        public ChapterComment ChapterComment { get; set; }  


        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
