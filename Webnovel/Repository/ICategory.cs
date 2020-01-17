using System.Collections.Generic;
using System.Threading.Tasks;
using Webnovel.Entities;
using Webnovel.Enum;

namespace Webnovel.Repository
{
	public interface ICategory
	{
		Task Create(Webnovel.Entities.Category category);

		Task Delete(int Id);

		Task<ICollection<Webnovel.Entities.Category>> List();
        Task<ICollection<Webnovel.Entities.Category>> List(EntityVisibilityStatus status);
        Task<bool>  EditStatusCategory(int id, EntityVisibilityStatus status);
        Task Edit(Entities.Category category);
        Task<bool> HasBeenUsed(int id);
        Task<Entities.Category> GetCategory(int id);

		Task<bool> Save();
	}
}
