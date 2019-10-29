using System.ComponentModel.DataAnnotations.Schema;

namespace Webnovel.Entities
{
	public class ComicTag
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

		[ForeignKey("ComicId")]
		public Comic Comic
		{
			get;
			set;
		}
	}
}
