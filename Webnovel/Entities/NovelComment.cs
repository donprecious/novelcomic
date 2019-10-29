using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Webnovel.Models;

namespace Webnovel.Entities
{
	public class NovelComment
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

		[ForeignKey("UserId")]
		public ApplicationUser User
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

        public int RateId { get; set; }

        [ForeignKey("RateId")]
        public NovelRating NovelRating { get; set; }
		public int NovelId
		{
			get;
			set;
		}

		[ForeignKey("NovelId")]
		public Novel Novel
		{
			get;
			set;
		} 
        public DateTime? DateTime { get; set; }

	}
}
