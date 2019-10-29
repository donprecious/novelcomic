using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webnovel.Entities
{
	public class Comic
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

		public int CategoryId
		{
			get;
			set;
		}

		public DateTime DateCreated
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

     
        public ICollection<Episode> Episodes
		{
			get;
			set;
		}

		public ICollection<ComicScene> ComicScenes
		{
			get;
			set;
		}
        public ICollection<ComicTag> Tags
        {
            get;
            set;
        }
        public ICollection<ComicRating> ComicRatings
		{
			get;
			set;
		}
	}
}
