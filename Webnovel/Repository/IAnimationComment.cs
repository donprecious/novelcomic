using System.Collections.Generic;
using System.Threading.Tasks;
using Webnovel.Entities;

namespace Webnovel.Repository
{
	public interface IAnimationComment
	{
		Task Create(Webnovel.Entities.AnimationComment comment);

		Task Delete(int Id);

		Task<ICollection<Webnovel.Entities.AnimationComment>> List(int novelId);

		Task<bool> Save();
	}
}
