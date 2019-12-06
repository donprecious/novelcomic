using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webnovel.Models
{
    public class SubscriptionVm
    {
            [Required(ErrorMessage ="Title Required")]
            public string Title { get; set; }

            public string Description { get; set; } 
            [Required(ErrorMessage ="Amount Required")]
            public double Amount { get; set; }
            [Required(ErrorMessage ="Duration Required")]
            public int Days { get; set; }
            public int Preference { get; set; }
        
    }
}
