using System.ComponentModel.DataAnnotations.Schema;

namespace Webnovel.Entities
{
	public class AnimationEpisode
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id
		{
			get;
			set;
		}

		public string Title
		{
			get;
			set;
		}

		public int AnimationId
		{
			get;
			set;
		}

		public string VideoUrl
		{
			get;
			set;
		}

		[ForeignKey("AnimationId")]
		public Animation Animation
		{
			get;
			set;
		}
	}
}
