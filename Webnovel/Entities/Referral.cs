using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Webnovel.Models;

namespace Webnovel.Entities
{
    public class Referral
    { 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {  get;set; }
        public string UserId { get; set; }

        public string Status { get; set; } 
        public string Occupation { get; set; } 
        public string InformationFrom { get; set; }
        public  string ProgramType { get; set; } 
        public string MinimumReferral { get; set; }

        public int CountryId { get; set; } 

        public Country Country { get; set; } 
        public string AdditonalInformation { get; set; }
        public DateTime Date { get; set; }
        public string ShortUrl { get; set; }  

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        public ICollection<Referred> referreds{get;set;}
    }

    public class Referred
    {
        [Key]
        public string UserId{ get; set; } 
        public int ReferralId { get; set; }
        public DateTime DateRegistered { get; set; }

       
        public ApplicationUser User { get; set; }
        [ForeignKey("ReferralId")]
        public  Referral Referral { get; set; }
   
    }

    public class NormalReferredUser
    {
        [Key]
        public string UserId  {  get;set; } 

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        public string ReferredUserId { get; set; } 
        [ForeignKey("ReferredUserId ")]
        public ApplicationUser ReferredUser { get; set; }

        public DateTime DateRegistered { get; set; }
    }
}
