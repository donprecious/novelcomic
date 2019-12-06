using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Webnovel.Models;

namespace Webnovel.Entities
{
    public class UserWallet
    {
        [Key]
        public string UserId
        {
            get;
            set;
        }

        [ForeignKey("UserId")]
        public ApplicationUser User
        {
            get;
            set;
        }

        public double Amount { get; set; }

       
        public string Description { get; set; }
    }
}
