using System.ComponentModel.DataAnnotations;

namespace Webnovel.Models
{
	public class ChapterVm
	{
		public int Id
		{
			get;
			set;
		}

		[Required(ErrorMessage = "Chapter Title or Name Required")]
		public string Name
		{
			get;
			set;
		}

		public string Description
		{
			get;
			set;
		}

		[DataType(DataType.MultilineText)]
		public string Content
		{
			get;
			set;
		}

		public int NovelId
		{
			get;
			set;
		}

		public int NovelSectionId
		{
			get;
			set;
		}
	}
}
