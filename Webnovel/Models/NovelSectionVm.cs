using System.ComponentModel.DataAnnotations;

namespace Webnovel.Models
{
	public class NovelSectionVm
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

		[Required(ErrorMessage = "Novel is Required")]
		public int NovelId
		{
			get;
			set;
		}
	}
}
