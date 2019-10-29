using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
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

		public async Task CreateNovel(Webnovel.Entities.Novel novel)
		{
			novel.DateCreated = DateTime.UtcNow;
			await _context.Novels.AddAsync(novel, default(CancellationToken));
		}

		public async Task<List<Webnovel.Entities.Novel>> GetAllNovels(bool? hasImage =null, bool? hasChapters=null)
        {
            var list = await _context.Novels.Include(a => a.Category)
                .Include(a => a.Author)
                .Include(a => a.Chapters)
                .Include(a=>a.NovelRatings)
               

                .Include(a => a.Tags).ToListAsync();
            if ( hasImage != null)
            {
                if ((bool)hasImage)
                {
                    list = list.Where(a => a.CoverPageImageUrl != null).ToList();

                }
            }
            if ( hasChapters != null)
            {
                if ((bool)hasChapters)
                {
                    list = list.Where(a => a.Chapters.Any()).ToList();

                }
            }

            return list;
        }

		public async Task<Webnovel.Entities.Novel> GetNovel(int novelId)
		{
            return await _context.Novels.Where(a=>a.Id == novelId).Include(a=>a.Category)
                .Include(a=>a.Author)
                .Include(a=>a.Chapters)
                .Include(a=>a.Tags)
                .SingleOrDefaultAsync();
		}

		public async Task<List<Webnovel.Entities.Novel>> GetAuthorNovels(int id)
		{
			return await EntityFrameworkQueryableExtensions.ToListAsync<Webnovel.Entities.Novel>(((IQueryable<Webnovel.Entities.Novel>)_context.Novels).Where((Webnovel.Entities.Novel a) => a.AuthorId == id), default(CancellationToken));
		}

		public async Task DeleteNovel(int id)
		{
			DbSet<Webnovel.Entities.Novel> novels = _context.Novels;
			novels.Remove(await _context.Novels.FindAsync(new object[1]
			{
				id
			}));
		}


		public async Task EditNovel(Webnovel.Entities.Novel novel)
        {
            var r = _context.Entry(novel).State = EntityState.Modified;
        }

		public async Task<bool> FindNovel(int novelId)
		{
			return await EntityFrameworkQueryableExtensions.AnyAsync<Webnovel.Entities.Novel>((IQueryable<Webnovel.Entities.Novel>)_context.Novels, (Expression<Func<Webnovel.Entities.Novel, bool>>)((Webnovel.Entities.Novel a) => a.Id == novelId), default(CancellationToken));
		}

		public async Task CreateSection(NovelSection novelSection)
		{
			await((DbContext)_context).AddAsync<NovelSection>(novelSection, default(CancellationToken));
		}

		public async Task<ICollection<NovelSection>> GetNovelSections(int novelId)
		{
			return await EntityFrameworkQueryableExtensions.ToListAsync<NovelSection>((IQueryable<NovelSection>)EntityFrameworkQueryableExtensions.Include<NovelSection, ICollection<Chapter>>(((IQueryable<NovelSection>)_context.NovelSections).Where((NovelSection a) => a.NovelId == novelId), (Expression<Func<NovelSection, ICollection<Chapter>>>)((NovelSection a) => a.Chapters)), default(CancellationToken));
		}

		public async Task<NovelSection> GetNovelSection(int sectionId)
		{
			return await EntityFrameworkQueryableExtensions.SingleOrDefaultAsync<NovelSection>((IQueryable<NovelSection>)EntityFrameworkQueryableExtensions.Include<NovelSection, Webnovel.Entities.Novel>((IQueryable<NovelSection>)EntityFrameworkQueryableExtensions.Include<NovelSection, ICollection<Chapter>>(((IQueryable<NovelSection>)_context.NovelSections).Where((NovelSection a) => a.Id == sectionId), (Expression<Func<NovelSection, ICollection<Chapter>>>)((NovelSection a) => a.Chapters)), (Expression<Func<NovelSection, Webnovel.Entities.Novel>>)((NovelSection a) => a.Novel)), default(CancellationToken));
		}

		public async Task EditNovelSection(NovelSection novelSection)
        {
            _context.Entry(novelSection).State = EntityState.Modified;
		}

		public async Task DeleteNovelSection(int id)
		{
			NovelSection novelSection = await _context.NovelSections.FindAsync(new object[1]
			{
				id
			});
			((DbContext)_context).Remove<NovelSection>(novelSection);
		}

		public async Task CreateChapter(Chapter chapter)
		{
			chapter.DateCreated = DateTime.UtcNow;
			await _context.Chapters.AddAsync(chapter, default(CancellationToken));
		}

		public async Task UpdateChapter(Chapter chapter)
        {
            _context.Entry(chapter);
        }

		public async Task<bool> FindNovelChapter(int chapterId)
		{
			return await EntityFrameworkQueryableExtensions.AnyAsync<Chapter>((IQueryable<Chapter>)_context.Chapters, (Expression<Func<Chapter, bool>>)((Chapter a) => a.Id == chapterId), default(CancellationToken));
		}

		public async Task<IEnumerable<Chapter>> GetNovelChapters(int novelId)
		{
            //return await _context.SingleOrDefaultAsync<Chapter>((IQueryable<Chapter>)EntityFrameworkQueryableExtensions.Include<Chapter, NovelSection>(((IQueryable<Chapter>)_context.Chapters).Where((Chapter a) => a.Id == chapterId), (Expression<Func<Chapter, NovelSection>>)((Chapter a) => a.NovelSection)), default(CancellationToken));
          return await  _context.Chapters.Include(a => a.Novel).Include(a => a.NovelSection).Where(a=>a.NovelId == novelId).ToListAsync();
        }
        public async Task<IOrderedQueryable<Chapter>> GetNovelChaptersNoTracking(int novelId)
        {
            //return await _context.SingleOrDefaultAsync<Chapter>((IQueryable<Chapter>)EntityFrameworkQueryableExtensions.Include<Chapter, NovelSection>(((IQueryable<Chapter>)_context.Chapters).Where((Chapter a) => a.Id == chapterId), (Expression<Func<Chapter, NovelSection>>)((Chapter a) => a.NovelSection)), default(CancellationToken));
            return  _context.Chapters.Include(a => a.Novel).Include(a => a.NovelSection)
                .Where(a => a.NovelId == novelId).AsNoTracking().OrderBy(a => a.DateCreated);
        }

        public async Task<IQueryable<Chapter>> GetNovelChaptersAsIQueryable(int novelId)
        {
            return  _context.Chapters.Include(a => a.Novel).Include(a => a.NovelSection)
                .Where(a => a.NovelId == novelId).AsNoTracking().OrderBy(a => a.DateCreated);
        }

        public async Task<Chapter> GetNovelChapter(int chapterId)
		{
			return await EntityFrameworkQueryableExtensions.SingleOrDefaultAsync<Chapter>((IQueryable<Chapter>)EntityFrameworkQueryableExtensions.Include<Chapter, NovelSection>(((IQueryable<Chapter>)_context.Chapters).Where((Chapter a) => a.Id == chapterId), (Expression<Func<Chapter, NovelSection>>)((Chapter a) => a.NovelSection)), default(CancellationToken));
		}

		public async Task EditNovelChapter(ChapterVm chapter)
		{
			Chapter chapter2 = _context.Chapters.Find(new object[1]
			{
				chapter.Id
			});
			chapter2.Content = chapter.Content;
			chapter2.Description = chapter.Description;
			chapter2.Name = chapter.Name;
            _context.Entry(chapter2).State = EntityState.Modified;
        }

		public async Task EditNovelChapter(Chapter chapter)
        {
            _context.Entry(chapter).State = EntityState.Modified;
		}

		public async Task DeleteNovelChapter(Chapter chapter)
		{
			_context.Chapters.Remove(chapter);
		}

		public async Task AddUpdateToLibrary(NovelLibrary comicLibrary)
		{
			NovelLibrary novelLibrary = await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync<NovelLibrary>(((IQueryable<NovelLibrary>)_context.NovelLibraries).Where((NovelLibrary a) => a.NovelId == comicLibrary.NovelId && a.UserId == comicLibrary.UserId), default(CancellationToken));
			if (novelLibrary == null)
			{
				_context.NovelLibraries.Add(comicLibrary);
			}
			//else
			//{
			//	novelLibrary.LastViewedChapterId = comicLibrary.LastViewedChapterId;
			//}
		}

		public async Task<IEnumerable<NovelLibrary>> GetLibrary(string userId)
		{
			return await EntityFrameworkQueryableExtensions.ToListAsync<NovelLibrary>((IQueryable<NovelLibrary>)EntityFrameworkQueryableExtensions.Include<NovelLibrary, ICollection<Chapter>>((IQueryable<NovelLibrary>)EntityFrameworkQueryableExtensions.Include<NovelLibrary, Webnovel.Entities.Novel>(((IQueryable<NovelLibrary>)_context.NovelLibraries).Where((NovelLibrary a) => a.UserId == userId), (Expression<Func<NovelLibrary, Webnovel.Entities.Novel>>)((NovelLibrary a) => a.Novel)), (Expression<Func<NovelLibrary, ICollection<Chapter>>>)((NovelLibrary a) => a.Novel.Chapters)), default(CancellationToken));
		}

		public async Task AddToSave(NovelSaved comicLibrary)
		{
			await _context.NovelSaveds.AddAsync(comicLibrary, default(CancellationToken));
		}

		public async Task DeleteSavedNovel(int comicId, string userId)
		{
			List<NovelSaved> list = await EntityFrameworkQueryableExtensions.ToListAsync<NovelSaved>(((IQueryable<NovelSaved>)_context.NovelSaveds).Where((NovelSaved a) => a.NovelId == comicId && a.UserId == userId), default(CancellationToken));
			_context.NovelSaveds.RemoveRange((IEnumerable<NovelSaved>)list);
		}

		public async Task<IEnumerable<NovelSaved>> SavedNovel(string userId)
		{
			return await EntityFrameworkQueryableExtensions.ToListAsync<NovelSaved>((IQueryable<NovelSaved>)EntityFrameworkQueryableExtensions.Include<NovelSaved, ApplicationUser>((IQueryable<NovelSaved>)EntityFrameworkQueryableExtensions.Include<NovelSaved, Webnovel.Entities.Novel>(((IQueryable<NovelSaved>)_context.NovelSaveds).Where((NovelSaved a) => a.UserId == userId), (Expression<Func<NovelSaved, Webnovel.Entities.Novel>>)((NovelSaved a) => a.Novel)), (Expression<Func<NovelSaved, ApplicationUser>>)((NovelSaved a) => a.User)), default(CancellationToken));
		}

		public async Task AddToLibrary(NovelLibrary Library)
		{
			await _context.NovelLibraries.AddAsync(Library, default(CancellationToken));
		}

		public async Task UpdateLibraryLastViewed(int id, int chapterId)
		{
			NovelLibrary novelLibrary = await _context.NovelLibraries.FindAsync(new object[1]
			{
				id
			});
		//	novelLibrary.LastViewedChapterId = chapterId;
            _context.Entry<NovelLibrary>(novelLibrary).State = EntityState.Modified;
        }

		public async Task RemoveFromLibrary(int id, string userid)
		{
			List<NovelLibrary> list = await EntityFrameworkQueryableExtensions.ToListAsync<NovelLibrary>(((IQueryable<NovelLibrary>)_context.NovelLibraries).Where((NovelLibrary a) => a.UserId == userid && a.NovelId == id), default(CancellationToken));
			_context.NovelLibraries.RemoveRange((IEnumerable<NovelLibrary>)list);
		}

		public async Task<IEnumerable<NovelLibrary>> GetLibraries(string userId)
        {
            var lib = await _context.NovelLibraries.Where(a => a.UserId == userId).Include(a => a.User)
                .Include(a => a.Novel).ToListAsync();
            return lib;
			//return await EntityFrameworkQueryableExtensions.ToListAsync<NovelLibrary>((IQueryable<NovelLibrary>)EntityFrameworkQueryableExtensions.Include<NovelLibrary, Webnovel.Entities.Novel>((IQueryable<NovelLibrary>)EntityFrameworkQueryableExtensions.Include<NovelLibrary, Chapter>(((IQueryable<NovelLibrary>)_context.NovelLibraries).Where((NovelLibrary a) => a.UserId == userId), (Expression<Func<NovelLibrary, Chapter>>)((NovelLibrary a) => a.Chapter)), (Expression<Func<NovelLibrary, Webnovel.Entities.Novel>>)((NovelLibrary a) => a.Novel)), default(CancellationToken));
		}

		public async Task<bool> CheckLibrary(int novelId)
		{
			return ((IQueryable<NovelLibrary>)_context.NovelLibraries).Any((NovelLibrary a) => a.NovelId == novelId);
		}

		public async Task AddTag(Tag tag)
		{
			await _context.Tags.AddAsync(tag, default(CancellationToken));
		}

		public async Task<IEnumerable<Tag>> Tags()
		{
			return await EntityFrameworkQueryableExtensions.ToListAsync<Tag>((IQueryable<Tag>)_context.Tags, default(CancellationToken));
		}

		public async Task RemoveTag(Tag tag)
		{
			_context.Tags.Remove(tag);
		}

		public async Task AddNovelTag(NovelTag tag)
		{
			await _context.NovelTags.AddAsync(tag, default(CancellationToken));
		}

		public async Task RemoveNovelTag(NovelTag tag)
		{
			_context.NovelTags.Remove(tag);
		}

		public async Task<bool> FindTag(string name)
		{
			return await EntityFrameworkQueryableExtensions.AnyAsync<Tag>((IQueryable<Tag>)_context.Tags, (Expression<Func<Tag, bool>>)((Tag a) => a.Name == name), default(CancellationToken));
		}

		public async Task<Tag> GetTag(string name)
		{
			return await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync<Tag>(((IQueryable<Tag>)_context.Tags).Where((Tag a) => a.Name == name), default(CancellationToken));
		}


        public async Task ChapterComment(ChapterComment chapterComment)
        {
          await  _context.ChapterComments.AddAsync(chapterComment);
        }

        public async Task<ICollection<Chapter>> GetNovelPublishedChapter(int novelId){
                var chapters = await _context.Chapters.Where(a=>a.NovelId == novelId 
                && a.isPublished == true  ).ToListAsync();
            return chapters;
         } 
          public async Task<ICollection<Chapter>> GetAuthorPublishedChapter(int authorId)
            {
                var chapters = await _context.Chapters.Where(a=>a.Novel.AuthorId == authorId 
                && a.isPublished == true  ).ToListAsync();
            return chapters;
         }

          public async Task AddViewer(NovelViewer novelViewer)
          {
              await _context.NovelViewer.AddAsync(novelViewer);
          }

          public async Task<ICollection<NovelViewer>> GetNovelViewer()
          {
              return await _context.NovelViewer.Include(a=>a.Novel).ToListAsync();
          }
          public async Task<ICollection<NovelViewer>> GetNovelViewer(int novelId)
          {
              return await _context.NovelViewer.Where(a=>a.NovelId == novelId).Include(a=>a.Novel).ToListAsync();
          }
          public async Task<ICollection<NovelViewer>> GetAuthorNovelViewers(int authorId)
          {
              return await _context.NovelViewer.Where(a=>a.Novel.AuthorId == authorId).Include(a=>a.Novel).ToListAsync();
          }
		public async Task<bool> Save()
		{
			return await((DbContext)_context).SaveChangesAsync(default(CancellationToken)) >= 0;
		}
	}
}
