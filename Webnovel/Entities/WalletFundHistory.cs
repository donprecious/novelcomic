using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Webnovel.Models;

namespace Webnovel.Entities
{
    public class WalletFundHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get;   set; } 
        public string UserId
        {
            get;
            set;
        }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }


        public string PaymentHistoryId { get; set; }

        [ForeignKey("PaymentHistoryId")]

        public PaymentHistory PaymentHistory{
            get;
            set;
        }
 
        public double Amount { get; set; }

        public DateTime DateFunded { get; set; }


        public string Description { get; set; }

    }
}
