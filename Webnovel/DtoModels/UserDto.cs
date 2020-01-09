using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webnovel.Entities;

namespace Webnovel.DtoModels
{
    public class UserDto
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

        public string Email { get; set; }
        public string Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public string ProfileImage { get; set; } 
        public string DisplayName { get; set; }
        public string BasicReferralLink { get; set; }
        public Referred Referred { get; set; }
    }
}
