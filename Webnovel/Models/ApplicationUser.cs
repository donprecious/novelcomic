using Microsoft.AspNetCore.Identity;

namespace Webnovel.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string FirstName
		{
			get;
			set;
		}

		public string LastName
		{
			get;
			set;
		}

		public ApplicationUser()
        {
		}
	}
}
