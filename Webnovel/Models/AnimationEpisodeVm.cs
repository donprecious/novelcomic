using System.ComponentModel.DataAnnotations;

namespace Webnovel.Models
{
	public class AnimationEpisodeVm
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

		[Required(ErrorMessage = "Animation must be Selected")]
		public int AnimationId
		{
			get;
			set;
		}

		[Required(ErrorMessage = "Animation or Video not found")]
		public string VideoUrl
		{
			get;
			set;
		}
	}
}
