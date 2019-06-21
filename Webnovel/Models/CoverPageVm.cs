using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webnovel.Models
{
    public class CoverPageVm
    {
        
        public int Id { get; set; }
     
        public string ImageData { get; set; }

     }
}
