using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Webnovel.Entities;

namespace Webnovel.Models
{
    public class ReferralVm
    {

        public string UserId{get;set;}
    
        [Required (ErrorMessage = "Required")]
        public string FirstName{get;set;}
        [Required (ErrorMessage = "Required")]

        public string LastName{get;set;}

        public string Email{get;set;}
        [Required (ErrorMessage = "Required")]

        public string Phone{get;set;} 
        [Required (ErrorMessage = "Required")]

        public string Occupation{get;set;}  
     

        public string Status { get; set; }
        [Required (ErrorMessage = "Required")]

        public string InformationFrom { get; set; } 
        [Required (ErrorMessage = "Required")]

        public  string ProgramType { get; set; } 
        [Required (ErrorMessage = "Required")]

        public string MinimumReferral { get; set; }
        [Required (ErrorMessage = "Required")]

        public  string Gender { get; set; }
        [Required (ErrorMessage = "Required")]

        public int CountryId { get; set; }


        public string AdditonalInformation { get; set; }
        [Required (ErrorMessage = "Required")]
        public DateTime DateOfBirth { get; set; }
        public string ShortUrl { get; set; }  

    }
}
