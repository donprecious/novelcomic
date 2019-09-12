using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webnovel.Entities
{
	public class Novel
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

		public string Title
		{
			get;
			set;
		}

		public string CoverPageImageUrl
		{
			get;
			set;
		}

		public string Language
		{
			get;
			set;
		}

		public string LeadingGender
		{
			get;
			set;
		}

		public string WariningNotice
		{
			get;
			set;
		}

		public string AudienceAge
		{
			get;
			set;
		}

		public int AuthorId
		{
			get;
			set;
		}

		[ForeignKey("AuthorId")]
		public Author Author
		{
			get;
			set;
		}

		public DateTime DateCreated
		{
			get;
			set;
		}

		public int CategoryId
		{
			get;
			set;
		}

		[ForeignKey("CategoryId")]
		public Category Category
		{
			get;
			set;
		}

		public ICollection<Chapter> Chapters
		{
			get;
			set;
		}

		public ICollection<NovelSection> NovelSections
		{
			get;
			set;
		}

		public ICollection<NovelRating> NovelRatings
		{
			get;
			set;
		}

		public ICollection<NovelTag> Tags
		{
			get;
			set;
		}
	}
}
