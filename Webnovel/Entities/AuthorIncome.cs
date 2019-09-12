using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webnovel.Entities
{
	public class AuthorIncome
	{
		[Key]
		public int AuthorId
		{
			get;
			set;
		}

		[ForeignKey("AuthorId")]
		public Author Author
		{
			get;
			set;
		}

		public double AmountUsd
		{
			get;
			set;
		}
	}
}
