using System.Collections.Generic;
using System.Threading.Tasks;
using Webnovel.Entities;

namespace Webnovel.Repository
{
	public interface IAnimation
	{
		Task CreateAnimation(Webnovel.Entities.Animation animation);

		Task<List<Webnovel.Entities.Animation>> GetAllAnimations();

		Task<Webnovel.Entities.Animation> GetAnimation(int animationId);

		Task<List<Webnovel.Entities.Animation>> GetAuthorAnimations(int id);

		Task DeleteAnimation(int id);

		Task<bool> FindAnimation(int animationId);

		Task CreateAnimationEpisode(AnimationEpisode animationEpisode);

		Task<bool> FindAnimationEpisode(int animationEpisodeId);

		Task<ICollection<AnimationEpisode>> GetAnimationEpisodes(int animationId);

		Task<AnimationEpisode> GetAnimationEpisode(int animationEpisodeId);

		Task AddToSave(AnimationSaved comicLi);

		Task<IEnumerable<AnimationSaved>> SavedAnimation(string userId);

		Task DeleteAnimationEpisode(AnimationEpisode animationEpisode);

		Task AddToLibrary(AnimationLibrary library);

		Task UpdateLibraryLastViewed(int id);

		Task RemoveFromLibrary(int id, string userid);

		Task<IEnumerable<AnimationLibrary>> GetLibraries(string userId);

		Task<bool> CheckLibrary(int chapterId);

		Task<bool> Save();
	}
}
