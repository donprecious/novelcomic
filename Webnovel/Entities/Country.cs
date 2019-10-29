using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Webnovel.Entities
{
   
    public class Country
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }
        public string name { get; set; }
  
        public string alpha2Code { get; set; }
        public string alpha3Code { get; set; }
    
        public string capital { get; set; }

        public string region { get; set; }
        public string subregion { get; set; }
        public int population { get; set; }
     
        public string demonym { get; set; }
       
     
        public string nativeName { get; set; }
        public string numericCode { get; set; }
       
    }
}
