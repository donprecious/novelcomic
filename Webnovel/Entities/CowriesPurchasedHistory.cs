using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Webnovel.Models;

namespace Webnovel.Entities
{
    /// <summary>
    /// Store Cowries  Purchased by User
    /// </summary>
    public class CowriesPurchasedHistory
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

        public DateTime DatePurchased { get; set; }

        public double Quantity { get; set; }

    }
}
