using System.ComponentModel.DataAnnotations.Schema;
using Webnovel.Models;

namespace Webnovel.Entities
{
	public class NovelReport
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

		public string UserId
		{
			get;
			set;
		}

		public string Message
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

		[ForeignKey("UserId")]
		public ApplicationUser User
		{
			get;
			set;
		}
	}
}
