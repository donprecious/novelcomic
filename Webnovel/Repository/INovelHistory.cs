using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webnovel.Entities;

namespace Webnovel.Repository
{
    public  interface INovelHistory
    {

        Task<ICollection<NovelChapterHistory>> GetHistories(string userId, int novelId);
        Task<bool> CheckHistory(string userId, int chapterId);
        Task<NovelChapterHistory> GetLastHistory(string userId, int novelId);
        Task AddHistory(NovelChapterHistory chapterHistory);
        Task<bool> Save();

    }
}
