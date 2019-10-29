using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webnovel.Entities
{
	public class Chapter
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id
		{
			get;
			set;
		}

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

		[Column(TypeName = "varchar(MAX)")]
		public string Content
		{
			get;
			set;
		}

		public DateTime DateCreated
		{
			get;
			set;
		}

		public DateTime? DatePublished
		{
			get;
			set;
		}

		public string TimeZone
		{
			get;
			set;
		}

		public int NovelId
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

		public bool isPublished
		{
			get;
			set;
		}

		public string status
		{
			get;
			set;
		}

		public int NovelSectionId
		{
			get;
			set;
		}

		[ForeignKey("NovelSectionId")]
		public NovelSection NovelSection
		{
			get;
			set;
		} 

        public ICollection<ChapterComment> ChapterComments { get; set; }
	}
}
