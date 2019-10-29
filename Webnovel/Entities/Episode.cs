using System.ComponentModel.DataAnnotations.Schema;

namespace Webnovel.Entities
{
	public class Episode
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

		public string ImageUrl
		{
			get;
			set;
		}
        public int Preference { get; set; }
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

		public int ComicSceneId
		{
			get;
			set;
		}

		[ForeignKey("ComicSceneId")]
		public ComicScene ComicScene
		{
			get;
			set;
		}
	}
}
