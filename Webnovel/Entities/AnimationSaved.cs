using System;
using System.ComponentModel.DataAnnotations.Schema;
using Webnovel.Models;

namespace Webnovel.Entities
{
	public class AnimationSaved
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

		public DateTime DateTime
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

		[ForeignKey("UserId")]
		public ApplicationUser User
		{
			get;
			set;
		}
	}
}
