using System.ComponentModel.DataAnnotations;

namespace Webnovel.Models
{
	public class AnimationCommentVm
	{
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

		public int AnimationId
		{
			get;
			set;
		}
	}
}
