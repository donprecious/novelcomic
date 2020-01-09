using System.ComponentModel.DataAnnotations.Schema;
using Webnovel.Models;

namespace Webnovel.Entities
{
	public class ComicRating
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id
		{
			get;
			set;
		}

		public int ComicId
		{
			get;
			set;
		}

		public string UserId
		{
			get;
			set;
		}

		public double Value
		{
			get;
			set;
		} 

        public int RatingTypeId { get; set; }
        [ForeignKey("RatingTypeId")]
        public RatingType RatingType { get; set; } 

        public string Description { get; set; }
		[ForeignKey("ComicId")]
		public Comic Comic
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

        public int CommentId { get; set; } 

        [ForeignKey("CommentId")]
        public ComicComment ComicComment { get; set; }
	}
}
