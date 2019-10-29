using System;
using System.ComponentModel.DataAnnotations;

namespace Webnovel.Models
{
	public class NovelCommentVm
	{
		public int Id
		{ get;set;
		}

		public string UserId {get; set;}

		[Required(ErrorMessage = "Comment Required")]
		public string Comment
		{
			get;
			set;
		}

		public int NovelId
		{
			get;
			set;
		}
        public DateTime? DateTime { get; set; }

	}
    public class NovelChapterCommentVm
    {
        public int Id
        {
            get;
            set;
        }

        public string UserId
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Comment Required")]
        public string Comment
        {
            get;
            set;
        }
        public DateTime? DateTime { get; set; }

        public int ChapterId
        {
            get;
            set;
        }
    }
}
