using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webnovel.Entities
{
	public class AuthorEarning
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id
		{
			get;
			set;
		}

		public int PaidChapterHistoryId
		{
			get;
			set;
		}

		[ForeignKey("PaidChapterHistoryId")]
		public PaidChapterHistory PaidChapterHistory
		{
			get;
			set;
		}

		public double AmountEarnedUsd
		{
			get;
			set;
		}

		public DateTime DateTime
		{
			get;
			set;
		}
	}
}
