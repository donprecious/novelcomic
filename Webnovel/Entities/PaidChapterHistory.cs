using System;
using System.ComponentModel.DataAnnotations.Schema;
using Webnovel.Models;

namespace Webnovel.Entities
{
	public class PaidChapterHistory
	{
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

		public int ChapterId
		{
			get;
			set;
		}

		[ForeignKey("ChapterId")]
		public Chapter Chapter
		{
			get;
			set;
		}

		public double CowriesUsed
		{
			get;
			set;
		}

		public double SpentInUsd
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
