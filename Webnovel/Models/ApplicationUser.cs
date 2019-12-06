using System;
using Microsoft.AspNetCore.Identity;
using Webnovel.Entities;

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

        public string Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public string ProfileImage { get; set; } 
        public string DisplayName { get; set; }
        public string BasicReferralLink { get; set; }
        public Referred Referred { get; set; }
		public ApplicationUser()
        {
		}
	}
}
