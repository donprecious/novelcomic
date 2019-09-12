using System.Collections.Generic;
using System.Threading.Tasks;
using Webnovel.Entities;

namespace Webnovel.Repository
{
	public interface IAuthor
	{
		Task Create(Webnovel.Entities.Author category);

		Task Delete(int Id);

		Task<ICollection<Webnovel.Entities.Author>> List();

		Task<Webnovel.Entities.Author> Get(int authorId);

		Task<Webnovel.Entities.Author> Get(string userId);

		Task<bool> AuthorExist(string userId);

		Task<bool> Save();
	}
}
