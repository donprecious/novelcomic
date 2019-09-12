using System.Collections.Generic;
using System.Threading.Tasks;
using Webnovel.Entities;
using Webnovel.Models;

namespace Webnovel.Repository
{
	public interface INovel
	{
		Task CreateNovel(Webnovel.Entities.Novel novel);

		Task<List<Webnovel.Entities.Novel>> GetAllNovels();

		Task<Webnovel.Entities.Novel> GetNovel(int novelId);

		Task<List<Webnovel.Entities.Novel>> GetAuthorNovels(int id);

		Task DeleteNovel(int id);

		Task EditNovel(Webnovel.Entities.Novel novel);

		Task<bool> FindNovel(int novelId);

		Task CreateSection(NovelSection novelSection);

		Task<ICollection<NovelSection>> GetNovelSections(int novelId);

		Task<NovelSection> GetNovelSection(int sectionId);

		Task EditNovelSection(NovelSection novelSection);

		Task DeleteNovelSection(int id);

		Task CreateChapter(Chapter chapter);

		Task<bool> FindNovelChapter(int chapterId);

		Task<IEnumerable<Chapter>> GetNovelChapters(int novelId);

		Task<Chapter> GetNovelChapter(int chapterId);

		Task EditNovelChapter(ChapterVm chapter);

		Task EditNovelChapter(Chapter chapter);

		Task DeleteNovelChapter(Chapter chapter);

		Task AddToSave(NovelSaved comicLibrary);

		Task DeleteSavedNovel(int comicId, string userId);

		Task<IEnumerable<NovelSaved>> SavedNovel(string userId);

		Task AddToLibrary(NovelLibrary comicLibrary);

		Task UpdateLibraryLastViewed(int id, int chapterId);

		Task RemoveFromLibrary(int id, string userid);

		Task<IEnumerable<NovelLibrary>> GetLibraries(string userId);

		Task<bool> CheckLibrary(int chapterId);

		Task AddTag(Tag tag);

		Task RemoveTag(Tag tag);

		Task AddNovelTag(NovelTag tag);

		Task RemoveNovelTag(NovelTag tag);

		Task<IEnumerable<Tag>> Tags();

		Task<Tag> GetTag(string name);

		Task<bool> FindTag(string name);

		Task<bool> Save();

		Task UpdateChapter(Chapter chapter);

		Task<IEnumerable<NovelLibrary>> GetLibrary(string userId);
	}
}
