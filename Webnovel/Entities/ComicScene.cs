using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webnovel.Entities
{
	public class ComicScene
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

		public int ComicId
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

		public ICollection<Episode> Episodes
		{
			get;
			set;
		}
	}
}
