using System;
using System.ComponentModel.DataAnnotations.Schema;
using Webnovel.Models;

namespace Webnovel.Entities
{
	public class ComicSaved
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id
		{
			get;
			set;
		}

		public int ComicId
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

		[ForeignKey("ComicId")]
		public Comic Comic
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
