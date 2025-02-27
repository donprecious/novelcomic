using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webnovel.Entities
{
	public class Animation
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

		public string Description
		{
			get;
			set;
		}

		public string CoverPageImageUrl
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

		public ICollection<AnimationEpisode> AnimationEpisodes
		{
			get;
			set;
		}

		public ICollection<AnimationRating> AnimationRatings
		{
			get;
			set;
		}
	}
}
