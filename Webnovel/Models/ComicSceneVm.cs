using System.ComponentModel.DataAnnotations;

namespace Webnovel.Models
{
	public class ComicSceneVm
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

		[Required(ErrorMessage = "A Comic Need to be selected or Present")]
		public int ComicId
		{
			get;
			set;
		}
	}
}
