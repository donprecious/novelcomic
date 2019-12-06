using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Webnovel.Models;

namespace Webnovel.Entities
{
	public class PaymentHistory
	{
		[Key]
		public string Id
		{
			get;
			set;
		}

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

		public string ReferenceNumber
		{
			get;
			set;
		}

		public double AmountUsd
		{
			get;
			set;
		}

		public string PaymentGateWay
		{
			get;
			set;
		}

        public string AdditionalDetail { get; set; }
        public DateTime TxtDateTime { get; set; }
	}
}
