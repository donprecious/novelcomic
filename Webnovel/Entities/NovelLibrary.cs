using System.ComponentModel.DataAnnotations.Schema;
using Webnovel.Models;

namespace Webnovel.Entities
{
	public class NovelLibrary
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id
		{
			get;
			set;
		}

		public int NovelId
		{
			get;
			set;
		}

		public int ChapterId
		{
			get;
			set;
		}

		public string UserId
		{
			get;
			set;
		}

		public int LastViewedChapterId
		{
			get;
			set;
		}

		[ForeignKey("NovelId")]
		public Novel Novel
		{
			get;
			set;
		}

		[ForeignKey("ChapterId")]
		public Chapter Chapter
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
