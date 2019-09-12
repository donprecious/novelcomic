using System.ComponentModel.DataAnnotations.Schema;
using Webnovel.Models;

namespace Webnovel.Entities
{
	public class ComicLibrary
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id
		{
			get;
			set;
		}

		public int EpisodeId
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

		public int LastViewedId
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

		[ForeignKey("EpisodeId")]
		public Episode Episode
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
