using System;
using System.ComponentModel.DataAnnotations.Schema;
using Webnovel.Models;

namespace Webnovel.Entities
{
	public class PaidEpisodeHistory
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
        
		public int EpisodeId
		{
			get;
			set;
		}

		[ForeignKey("EpisodeId")]
		public Episode Episode
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
