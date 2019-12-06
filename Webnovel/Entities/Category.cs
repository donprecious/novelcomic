using System.ComponentModel.DataAnnotations.Schema;

namespace Webnovel.Entities
{
	public class Category
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

        public string ImageUrl { get; set; }
	}
}
