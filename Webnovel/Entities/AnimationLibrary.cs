using System.ComponentModel.DataAnnotations.Schema;
using Webnovel.Models;

namespace Webnovel.Entities
{
	public class AnimationLibrary
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id
		{
			get;
			set;
		}

		public int AnimationId
		{
			get;
			set;
		}

		public string UserId
		{
			get;
			set;
		}

		public int AnimationEpisodeId
		{
			get;
			set;
		}

		public int LastViewedId
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

		[ForeignKey("AnimationEpisodeId")]
		public AnimationEpisode AnimationEpisode
		{
			get;
			set;
		}

		[ForeignKey("UserId")]
		public ApplicationUser User
		{
			get;
			set;
		}
	}
}
