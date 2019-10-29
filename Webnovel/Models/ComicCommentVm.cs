using System.ComponentModel.DataAnnotations;

namespace Webnovel.Models
{
	public class ComicCommentVm
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

		public int CommentId
		{
			get;
			set;
		}
	}
}
