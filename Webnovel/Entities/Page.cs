using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Webnovel.Entities
{
    public class Page
    { 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }

        public string Name { get; set; }

        [Column(TypeName = "varchar(MAX)")]
        public string Content { get; set; } 

    }
}
