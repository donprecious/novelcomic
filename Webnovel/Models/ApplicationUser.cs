using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        public int CountryId { get; set; }

        //[ForeignKey("CountryId")]
        public Country Country { get; set; }

        public bool HasEditedBirthDate {get; set; }
        public bool HasEditedCountry {get; set; }
		public ApplicationUser()
        {
		}
	}
}
