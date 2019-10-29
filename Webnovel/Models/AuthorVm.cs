using System.ComponentModel.DataAnnotations;

namespace Webnovel.Models
{
	public class AuthorVm
	{
		public int Id
		{
			get;
			set;
		}

		[Required(ErrorMessage = "Title is Required")]
		public string Title
		{
			get;
			set;
		}

		public string UserId
		{
			get;
			set;
		}
	}
}
