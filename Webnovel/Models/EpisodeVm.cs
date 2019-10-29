using System.ComponentModel.DataAnnotations;

namespace Webnovel.Models
{
	public class EpisodeVm
	{
		public int Id
		{
			get;
			set;
		}

		[Required(ErrorMessage = "Name or Title Required")]
		public string Name
		{
			get;
			set;
		}

		public string Description
		{
			get;
			set;
		}

		public string Content
		{
			get;
			set;
		}

		public string ImageUrl
		{
			get;
			set;
		}

		public int ComicId
		{
			get;
			set;
		}

		public int ComicSceneId
		{
			get;
			set;
		}
	}
}
