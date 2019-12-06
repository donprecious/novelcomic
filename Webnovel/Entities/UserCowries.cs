using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Webnovel.Models;

namespace Webnovel.Entities
{
	public class UserCowries
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

		public double Cowries
		{
			get;
			set;
		}

		//public int WordsRemaining
		//{
		//	get;
		//	set;
		//}
	}
}
