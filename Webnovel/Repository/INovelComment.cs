using System.Collections.Generic;
using System.Threading.Tasks;
using Webnovel.Entities;

namespace Webnovel.Repository
{
	public interface INovelComment
	{
		Task Create(Webnovel.Entities.NovelComment comment);

		Task Delete(int Id);

		Task<ICollection<Webnovel.Entities.NovelComment>> List(int novelId);

		Task<bool> Save();
	}
}
