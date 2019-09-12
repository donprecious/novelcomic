using System.Collections.Generic;
using System.Threading.Tasks;
using Webnovel.Entities;

namespace Webnovel.Repository
{
	public interface ICategory
	{
		Task Create(Webnovel.Entities.Category category);

		Task Delete(int Id);

		Task<ICollection<Webnovel.Entities.Category>> List();

		Task<bool> Save();
	}
}
