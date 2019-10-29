using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Webnovel.Models;

namespace Webnovel.Entities
{
	public class Author
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

		public string UserId
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

		public ICollection<Novel> Novels
		{
			get;
			set;
		}

		public ICollection<Comic> Comics
		{
			get;
			set;
		}
	}
}
