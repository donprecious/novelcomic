using System.ComponentModel.DataAnnotations;

namespace Webnovel.Models
{
	public class AnimationCoverPageVm
	{
		public int Id
		{
			get;
			set;
		}

		[Required(ErrorMessage = "Image Not Found")]
		public string ImageData
		{
			get;
			set;
		}
	}
}
