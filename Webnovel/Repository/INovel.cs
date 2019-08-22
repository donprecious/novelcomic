using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using Webnovel.Entities;
using Webnovel.Models;

namespace Webnovel.Repository
{
  public  interface INovel
  {
      Task CreateNovel(Entities.Novel novel);
      Task<List<Entities.Novel>> GetAllNovels();
      Task<Entities.Novel> GetNovel(int novelId);
        Task<List<Entities.Novel>> GetAuthorNovels(int id);
      Task DeleteNovel(int id);
      Task EditNovel(Entities.Novel novel);
      Task<bool> FindNovel(int novelId);


        Task CreateSection(NovelSection novelSection);
      Task<ICollection<Entities.NovelSection>> GetNovelSections(int novelId);
      Task GetNovelSection(int sectionId);
      Task EditNovelSection(NovelSection novelSection);
      Task DeleteNovelSection();


      Task CreateChapter(Chapter chapter);
      Task<bool> FindNovelChapter(int chapterId);
        Task GetNovelChapters(int novelId);
      Task<Entities.Chapter> GetNovelChapter(int chapterId);
      Task EditNovelChapter(ChapterVm chapter );
      Task DeleteNovelChapter(Chapter chapter);
      Task AddToSave(NovelSaved comicLibrary);
    Task  DeleteSavedNovel(int comicId, string userId);
    Task<IEnumerable<NovelSaved>> SavedNovel(string userId);
    Task AddUpdateToLibrary(NovelLibrary comicLibrary);
      Task<bool> Save();
      Task<IEnumerable<Entities.NovelLibrary>> GetLibrary(string userId);
    }
}
