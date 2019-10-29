using System.ComponentModel.DataAnnotations;

namespace Webnovel.Models
{
	public class AnimationVm
	{
		public int Id
		{
			get;
			set;
		}

		[Required(ErrorMessage = "Title Required")]
		public string Title
		{
			get;
			set;
		}

		public string Description
		{
			get;
			set;
		}

		public string CoverPageImageUrl
		{
			get;
			set;
		}

		[Required(ErrorMessage = "You are not an author yet!")]
		public int AuthorId
		{
			get;
			set;
		}

		[Required(ErrorMessage = "Category Required")]
		public int CategoryId
		{
			get;
			set;
		}
	}
}
