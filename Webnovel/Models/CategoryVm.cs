using System.ComponentModel.DataAnnotations;

namespace Webnovel.Models
{
	public class CategoryVm
	{
		public int Id
		{
			get;
			set;
		}

        [Required(ErrorMessage = "Category Title Required")]
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


	}
}
