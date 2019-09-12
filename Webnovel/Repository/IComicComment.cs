using System.Collections.Generic;
using System.Threading.Tasks;
using Webnovel.Entities;

namespace Webnovel.Repository
{
	public interface IComicComment
	{
		Task Create(Webnovel.Entities.ComicComment comment);

		Task Delete(int Id);

		Task<ICollection<Webnovel.Entities.ComicComment>> List(int novelId);

		Task<bool> Save();
	}
}
