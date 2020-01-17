using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webnovel.Models
{
    public class EditUserVm
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string  AuthorTitle { get; set; }
        public string  Phone { get; set; }
        public string DisplayName { get; set; } 
       
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CountryId { get; set; }
    }
}
