using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Webnovel.Entities;
using Webnovel.Models;

namespace Webnovel.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }
        public DbSet<Author> Authors
		{
			get;
			set;
		}

		public DbSet<Category> Categories
		{
			get;
			set;
		}

		public DbSet<Chapter> Chapters
		{
			get;
			set;
		}

		public DbSet<Novel> Novels
		{
			get;
			set;
		}

		public DbSet<NovelSection> NovelSections
		{
			get;
			set;
		}

		public DbSet<Comic> Comics
		{
			get;
			set;
		}

		public DbSet<ComicScene> ComicScenes
		{
			get;
			set;
		}

		public DbSet<Episode> Episodes
		{
			get;
			set;
		}

		public DbSet<Animation> Animations
		{
			get;
			set;
		}

		public DbSet<AnimationEpisode> AnimationEpisodes
		{
			get;
			set;
		}

		public DbSet<AnimationComment> AnimationComments
		{
			get;
			set;
		}

		public DbSet<NovelComment> NovelComments
		{
			get;
			set;
		}

		public DbSet<ComicComment> ComicComments
		{
			get;
			set;
		}

		public DbSet<ComicLibrary> ComicLibraries
		{
			get;
			set;
		}

		public DbSet<NovelLibrary> NovelLibraries
		{
			get;
			set;
		}

		public DbSet<AnimationLibrary> AnimationLibraries
		{
			get;
			set;
		}

		public DbSet<ComicSaved> ComicSaveds
		{
			get;
			set;
		}

		public DbSet<AnimationSaved> AnimationSaveds
		{
			get;
			set;
		}

		public DbSet<NovelSaved> NovelSaveds
		{
			get;
			set;
		}

		public DbSet<ComicReport> ComicReports
		{
			get;
			set;
		}

		public DbSet<AnimationReport> AnimationReports
		{
			get;
			set;
		}

		public DbSet<NovelReport> NovelReports
		{
			get;
			set;
		}

		public DbSet<AnimationRating> AnimationRatings
		{
			get;
			set;
		}

		public DbSet<NovelRating> NovelRatings
		{
			get;
			set;
		}

		public DbSet<ComicRating> ComicRatings
		{
			get;
			set;
		}

		public DbSet<UserFund> UserFunds
		{
			get;
			set;
		}

		public DbSet<FundHistory> FundHistories
		{
			get;
			set;
		}

		public DbSet<PaidChapterHistory> PaidChapterHistories
		{
			get;
			set;
		}

		public DbSet<AuthorEarning> AuthorEarnings
		{
			get;
			set;
		}

		public DbSet<AuthorIncome> AuthorIncomes
		{
			get;
			set;
		}

		public DbSet<Tag> Tags
		{
			get;
			set;
		}

		public DbSet<NovelTag> NovelTags
		{
			get;
			set;
		}

		public DbSet<ComicTag> ComicTags
		{
			get;
			set;
		}

		public DbSet<AnimationTag> AnimationTags
		{
			get;
			set;
		}


        protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.Entity<Author>().HasMany<Novel>((Expression<Func<Author, IEnumerable<Novel>>>)((Author a) => a.Novels)).WithOne((Expression<Func<Novel, Author>>)((Novel a) => a.Author));
			builder.Entity<Author>().HasOne<ApplicationUser>((Expression<Func<Author, ApplicationUser>>)((Author a) => a.User));
			builder.Entity<Novel>().HasMany<Chapter>((Expression<Func<Novel, IEnumerable<Chapter>>>)((Novel a) => a.Chapters)).WithOne((Expression<Func<Chapter, Novel>>)((Chapter a) => a.Novel));
			builder.Entity<Novel>().HasMany<NovelSection>((Expression<Func<Novel, IEnumerable<NovelSection>>>)((Novel a) => a.NovelSections)).WithOne((Expression<Func<NovelSection, Novel>>)((NovelSection a) => a.Novel));
			builder.Entity<Novel>().HasOne<Category>((Expression<Func<Novel, Category>>)((Novel a) => a.Category));
			builder.Entity<Chapter>().HasOne<NovelSection>((Expression<Func<Chapter, NovelSection>>)((Chapter a) => a.NovelSection));
			builder.Entity<NovelSection>().HasMany<Chapter>((Expression<Func<NovelSection, IEnumerable<Chapter>>>)((NovelSection a) => a.Chapters)).WithOne((Expression<Func<Chapter, NovelSection>>)((Chapter a) => a.NovelSection))
				.OnDelete((DeleteBehavior)3);
			builder.Entity<Comic>().HasOne<Category>((Expression<Func<Comic, Category>>)((Comic a) => a.Category));
			builder.Entity<Comic>().HasOne<Author>((Expression<Func<Comic, Author>>)((Comic a) => a.Author)).WithMany((Expression<Func<Author, IEnumerable<Comic>>>)((Author a) => a.Comics));
			builder.Entity<Comic>().HasMany<ComicScene>((Expression<Func<Comic, IEnumerable<ComicScene>>>)((Comic a) => a.ComicScenes)).WithOne((Expression<Func<ComicScene, Comic>>)((ComicScene a) => a.Comic));
			builder.Entity<Comic>().HasMany<Episode>((Expression<Func<Comic, IEnumerable<Episode>>>)((Comic a) => a.Episodes)).WithOne((Expression<Func<Episode, Comic>>)((Episode a) => a.Comic));
			builder.Entity<ComicScene>().HasMany<Episode>((Expression<Func<ComicScene, IEnumerable<Episode>>>)((ComicScene a) => a.Episodes)).WithOne((Expression<Func<Episode, ComicScene>>)((Episode a) => a.ComicScene));
			builder.Entity<Episode>().HasOne<Comic>((Expression<Func<Episode, Comic>>)((Episode a) => a.Comic));
			builder.Entity<Episode>().HasOne<ComicScene>((Expression<Func<Episode, ComicScene>>)((Episode a) => a.ComicScene));
			builder.Entity<Animation>().HasMany<AnimationEpisode>((Expression<Func<Animation, IEnumerable<AnimationEpisode>>>)((Animation a) => a.AnimationEpisodes)).WithOne((Expression<Func<AnimationEpisode, Animation>>)((AnimationEpisode a) => a.Animation));
			builder.Entity<Animation>().HasOne<Author>((Expression<Func<Animation, Author>>)((Animation a) => a.Author));
			builder.Entity<Animation>().HasOne<Category>((Expression<Func<Animation, Category>>)((Animation a) => a.Category));
			builder.Entity<NovelComment>().HasOne<ApplicationUser>((Expression<Func<NovelComment, ApplicationUser>>)((NovelComment a) => a.User));
			builder.Entity<NovelComment>().HasOne<Novel>((Expression<Func<NovelComment, Novel>>)((NovelComment a) => a.Novel));
			builder.Entity<ComicComment>().HasOne<ApplicationUser>((Expression<Func<ComicComment, ApplicationUser>>)((ComicComment a) => a.User));
			builder.Entity<ComicComment>().HasOne<Comic>((Expression<Func<ComicComment, Comic>>)((ComicComment a) => a.Comic));
			builder.Entity<AnimationComment>().HasOne<ApplicationUser>((Expression<Func<AnimationComment, ApplicationUser>>)((AnimationComment a) => a.User));
			builder.Entity<AnimationComment>().HasOne<Animation>((Expression<Func<AnimationComment, Animation>>)((AnimationComment a) => a.Animation));
			builder.Entity<NovelLibrary>().HasOne<ApplicationUser>((Expression<Func<NovelLibrary, ApplicationUser>>)((NovelLibrary a) => a.User));
			builder.Entity<NovelLibrary>().HasOne<Novel>((Expression<Func<NovelLibrary, Novel>>)((NovelLibrary a) => a.Novel));
			builder.Entity<NovelLibrary>().HasOne<Chapter>((Expression<Func<NovelLibrary, Chapter>>)((NovelLibrary a) => a.Chapter));
			builder.Entity<ComicLibrary>().HasOne<ApplicationUser>((Expression<Func<ComicLibrary, ApplicationUser>>)((ComicLibrary a) => a.User));
			builder.Entity<ComicLibrary>().HasOne<Comic>((Expression<Func<ComicLibrary, Comic>>)((ComicLibrary a) => a.Comic));
			builder.Entity<ComicLibrary>().HasOne<Episode>((Expression<Func<ComicLibrary, Episode>>)((ComicLibrary a) => a.Episode));
			builder.Entity<AnimationLibrary>().HasOne<ApplicationUser>((Expression<Func<AnimationLibrary, ApplicationUser>>)((AnimationLibrary a) => a.User));
			builder.Entity<AnimationLibrary>().HasOne<Animation>((Expression<Func<AnimationLibrary, Animation>>)((AnimationLibrary a) => a.Animation));
			builder.Entity<AnimationLibrary>().HasOne<AnimationEpisode>((Expression<Func<AnimationLibrary, AnimationEpisode>>)((AnimationLibrary a) => a.AnimationEpisode));
			builder.Entity<NovelSaved>().HasOne<ApplicationUser>((Expression<Func<NovelSaved, ApplicationUser>>)((NovelSaved a) => a.User));
			builder.Entity<NovelSaved>().HasOne<Novel>((Expression<Func<NovelSaved, Novel>>)((NovelSaved a) => a.Novel));
			builder.Entity<ComicSaved>().HasOne<ApplicationUser>((Expression<Func<ComicSaved, ApplicationUser>>)((ComicSaved a) => a.User));
			builder.Entity<ComicSaved>().HasOne<Comic>((Expression<Func<ComicSaved, Comic>>)((ComicSaved a) => a.Comic));
			builder.Entity<AnimationReport>().HasOne<ApplicationUser>((Expression<Func<AnimationReport, ApplicationUser>>)((AnimationReport a) => a.User));
			builder.Entity<AnimationReport>().HasOne<Animation>((Expression<Func<AnimationReport, Animation>>)((AnimationReport a) => a.Animation));
			builder.Entity<NovelReport>().HasOne<ApplicationUser>((Expression<Func<NovelReport, ApplicationUser>>)((NovelReport a) => a.User));
			builder.Entity<NovelReport>().HasOne<Novel>((Expression<Func<NovelReport, Novel>>)((NovelReport a) => a.Novel));
			builder.Entity<ComicReport>().HasOne<ApplicationUser>((Expression<Func<ComicReport, ApplicationUser>>)((ComicReport a) => a.User));
			builder.Entity<ComicReport>().HasOne<Comic>((Expression<Func<ComicReport, Comic>>)((ComicReport a) => a.Comic));
			builder.Entity<AnimationRating>().HasOne<ApplicationUser>((Expression<Func<AnimationRating, ApplicationUser>>)((AnimationRating a) => a.User));
			builder.Entity<AnimationRating>().HasOne<Animation>((Expression<Func<AnimationRating, Animation>>)((AnimationRating a) => a.Animation)).WithMany((Expression<Func<Animation, IEnumerable<AnimationRating>>>)((Animation a) => a.AnimationRatings));
			builder.Entity<ComicRating>().HasOne<ApplicationUser>((Expression<Func<ComicRating, ApplicationUser>>)((ComicRating a) => a.User));
			builder.Entity<ComicRating>().HasOne<Comic>((Expression<Func<ComicRating, Comic>>)((ComicRating a) => a.Comic)).WithMany((Expression<Func<Comic, IEnumerable<ComicRating>>>)((Comic a) => a.ComicRatings));
			builder.Entity<NovelRating>().HasOne<ApplicationUser>((Expression<Func<NovelRating, ApplicationUser>>)((NovelRating a) => a.User));
			builder.Entity<NovelRating>().HasOne<Novel>((Expression<Func<NovelRating, Novel>>)((NovelRating a) => a.Novel)).WithMany((Expression<Func<Novel, IEnumerable<NovelRating>>>)((Novel a) => a.NovelRatings));
			builder.Entity<UserFund>().HasOne<ApplicationUser>((Expression<Func<UserFund, ApplicationUser>>)((UserFund a) => a.User));
			builder.Entity<FundHistory>().HasOne<ApplicationUser>((Expression<Func<FundHistory, ApplicationUser>>)((FundHistory a) => a.User));
			builder.Entity<PaidChapterHistory>().HasOne<ApplicationUser>((Expression<Func<PaidChapterHistory, ApplicationUser>>)((PaidChapterHistory a) => a.User));
			builder.Entity<PaidChapterHistory>().HasOne<Chapter>((Expression<Func<PaidChapterHistory, Chapter>>)((PaidChapterHistory a) => a.Chapter));
			builder.Entity<AuthorEarning>().HasOne<PaidChapterHistory>((Expression<Func<AuthorEarning, PaidChapterHistory>>)((AuthorEarning a) => a.PaidChapterHistory));
			builder.Entity<AuthorIncome>().HasOne<Author>((Expression<Func<AuthorIncome, Author>>)((AuthorIncome a) => a.Author));
		}
	}
}
