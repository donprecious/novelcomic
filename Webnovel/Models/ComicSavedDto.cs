using System;

namespace Webnovel.Models
{
	public class ComicSavedDto
	{
		public int Id
		{
			get;
			set;
		}

		public int ComicId
		{
			get;
			set;
		}

		public string UserId
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
