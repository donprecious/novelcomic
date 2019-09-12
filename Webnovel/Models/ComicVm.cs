using System.ComponentModel.DataAnnotations;

namespace Webnovel.Models
{
	public class ComicVm
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

		[Required(ErrorMessage = "Description Required")]
		public string Description
		{
			get;
			set;
		}

		[Required(ErrorMessage = "You Need to be an Author ")]
		public int AuthorId
		{
			get;
			set;
		}

		public string CoverPageImageUrl
		{
			get;
			set;
		}

		[Required(ErrorMessage = "Category  Required")]
		public int CategoryId
		{
			get;
			set;
		}
	}
}
