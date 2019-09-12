using System.ComponentModel.DataAnnotations.Schema;

namespace Webnovel.Entities
{
	public class AnimationTag
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

		public int TagId
		{
			get;
			set;
		}

		[ForeignKey("TagId")]
		public Tag Tag
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
