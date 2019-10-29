using System.ComponentModel.DataAnnotations.Schema;
using Webnovel.Models;

namespace Webnovel.Entities
{
	public class FundHistory
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id
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
	}
}
