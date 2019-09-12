using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Webnovel.Models
{
	public class NovelVm
	{
		public int Id
		{
			get;
			set;
		}

		[Required(ErrorMessage = "Novel Title Required")]
		public string Name
		{
			get;
			set;
		}

		[Required(ErrorMessage = "Novel Synopsis Required")]
		public string Title
		{
			get;
			set;
		}

		[Required(ErrorMessage = "Author is Required")]
		public int AuthorId
		{
			get;
			set;
		}

		public string CoverPageImageUrl
		{
			get;
			set;
		}

		[Required(ErrorMessage = "Category Required")]
		public int CategoryId
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

		public ICollection<string> NTags
		{
			get;
			set;
		}
	}
}
