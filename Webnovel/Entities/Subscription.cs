using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Webnovel.Entities
{
    public class Subscription
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }

        public string Title { get; set; }

        public string Description { get; set; }
        public double Amount { get; set; }
        public int Days { get; set; }
        public int Preference { get; set; }
    }
}
