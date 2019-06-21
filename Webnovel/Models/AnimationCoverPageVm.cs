using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webnovel.Models
{
    public class AnimationCoverPageVm
    {
        
        public int Id { get; set; }
     
        [Required(ErrorMessage = "Image Not Found")]
        public string ImageData { get; set; }

     }
}
