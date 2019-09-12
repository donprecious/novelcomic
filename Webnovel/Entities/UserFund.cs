using System.ComponentModel.DataAnnotations;
using Webnovel.Models;

namespace Webnovel.Entities
{
	public class UserFund
	{
		[Key]
		public int UserId
		{
			get;
			set;
		}

		public ApplicationUser User
		{
			get;
			set;
		}

		public double Cowries
		{
			get;
			set;
		}

		public int WordsRemaining
		{
			get;
			set;
		}
	}
}
