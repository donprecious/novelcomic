using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Webnovel.Models;

namespace Webnovel.Entities
{
	public class AnimationComment
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

		public int AnimationId
		{
			get;
			set;
		}

		[ForeignKey("AnimationId")]
		public Animation Animation
		{
			get;
			set;
		}
	}
}
