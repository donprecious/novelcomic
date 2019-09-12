using System.ComponentModel.DataAnnotations.Schema;

namespace Webnovel.Entities
{
	public class Tag
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
	}
}
