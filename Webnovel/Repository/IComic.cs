using System.Collections.Generic;
using System.Threading.Tasks;
using Webnovel.Entities;
using Webnovel.Models;

namespace Webnovel.Repository
{
	public interface IComic
	{
		Task CreateComic(Webnovel.Entities.Comic comic);

		Task<List<Webnovel.Entities.Comic>> GetAllComics();

		Task<Webnovel.Entities.Comic> GetComic(int comicId);

		Task<List<Webnovel.Entities.Comic>> GetAuthorComics(int id);

		Task DeleteComic(int id);

		Task EditComic(Webnovel.Entities.Comic comic);

		Task<bool> FindComic(int comicId);

		Task CreateComicScene(ComicScene comicScene);

		Task<ICollection<ComicScene>> GetComicScenes(int comicId);

		Task<ComicScene> GetComicScene(int sectionId);

		Task EditComicScene(ComicScene comicScene);

		Task DeleteComicScene();

		Task CreateEpisode(Episode episode);

		Task<bool> FindEpisode(int episodeId);

        Task<IEnumerable<Episode>> GetEpisodes(int comicId);


        Task<Episode> GetEpisode(int episodeId);

		Task EditEpisode(EpisodeVm episode);

		Task DeleteSavedComic(int comicId, string userId);

		Task DeleteEpisode(Episode episode);

		Task AddToSave(ComicSaved comicSaved);

		Task<IEnumerable<ComicSaved>> SavedComic(string userId);

		Task<IEnumerable<ComicLibrary>> GetLibrary(string userId);

		Task AddToLibrary(ComicLibrary comicLibrary);

		Task UpdateLibraryLastViewed(int id, int episodeId);

		Task RemoveFromLibrary(int id, string userid);

		Task<bool> CheckLibrary(int chapterId);

		Task AddTag(Tag tag);

		Task RemoveTag(Tag tag);

		Task AddComicTag(ComicTag tag);

		Task RemoveComicTag(ComicTag tag);

		Task<bool> Save();
	}
}
