using System.ComponentModel.DataAnnotations.Schema;

namespace Webnovel.Entities
{
	public class NovelTag
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

		[ForeignKey("NovelId")]
		public Novel Novel
		{
			get;
			set;
		}
	}
}
