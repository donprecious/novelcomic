using System;
using System.Collections.Generic;


using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Webnovel.Data;
using Webnovel.Entities;
using Webnovel.Models;

namespace Webnovel.Repository
{
    public class Novel : INovel
    {
        private ApplicationDbContext _context;
        public Novel(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateNovel(Entities.Novel novel)
        {
           await _context.Novels.AddAsync(novel);
        }

        public async Task<List<Entities.Novel>> GetAllNovels()
        {
            throw new NotImplementedException();
        }

        public async Task<Entities.Novel> GetNovel(int novelId)
        {
            var novel = await _context.Novels.FindAsync(novelId);
            return novel;
        }

        public async Task<List<Entities.Novel>> GetAuthorNovels(int id)
        {
            var list = await _context.Novels.Where(a=>a.AuthorId == id).ToListAsync();
            return list;
        }

        public async Task DeleteNovel(int id)
        {
            _context.Novels.Remove(await _context.Novels.FindAsync(id));
        }

        public async Task EditNovel(Entities.Novel novel)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> FindNovel(int novelId)
        {
            return await _context.Novels.AnyAsync(a => a.Id == novelId);
        }


        public async Task CreateSection(NovelSection novelSection)
        {
            await _context.AddAsync(novelSection);
        }

        public async Task<ICollection<Entities.NovelSection>> GetNovelSections(int novelId)
        {
            var sections = await _context.NovelSections.Where(a => a.NovelId == novelId)
                .Include(a => a.Chapters)
                .ToListAsync();
            return sections;

        }

        public async Task GetNovelSection(int sectionId)
        {
            throw new NotImplementedException();
        }

        public async Task EditNovelSection(NovelSection novelSection)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteNovelSection()
        {
            throw new NotImplementedException();
        }

        public async Task CreateChapter(Chapter chapter)
        {
            await  _context.Chapters.AddAsync(chapter);
        }

        public async Task<bool> FindNovelChapter(int chapterId)
        {
            return await _context.Chapters.AnyAsync(a => a.Id == chapterId);
        }

        public async Task GetNovelChapters(int novelId)
        {
            throw new NotImplementedException();
        }

        public async Task<Entities.Chapter> GetNovelChapter(int chapterId)
        {
            return await _context.Chapters.Where(a => a.Id == chapterId)
                .Include(a => a.NovelSection)
                .SingleOrDefaultAsync()
                ;
        }

        public async Task EditNovelChapter(ChapterVm chapter)
        {
            var ch = _context.Chapters.Find(chapter.Id);
            ch.Content = chapter.Content;
            ch.Description = chapter.Description;
            ch.Name = chapter.Name;
            _context.Entry(ch).State = EntityState.Modified;
        }

        public async Task DeleteNovelChapter(Chapter chapter)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Save()
        {
            return ((await _context.SaveChangesAsync()) >= 0);
        }
    }
}
