using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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

        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Novel> Novels { get; set; }
        public DbSet<NovelSection> NovelSections { get; set; }

        public DbSet<Comic> Comics{  get; set; }
        public DbSet<ComicScene> ComicScenes { get; set; }
        public DbSet<Episode> Episodes { get; set; }

        public DbSet<Animation> Animations { get; set; }
        public DbSet<AnimationEpisode> AnimationEpisodes { get; set; }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Author>().HasMany(a => a.Novels).WithOne(a => a.Author);
            builder.Entity<Author>().HasOne(a => a.User);
            builder.Entity<Novel>().HasMany(a => a.Chapters).WithOne(a => a.Novel);
            builder.Entity<Novel>().HasMany(a => a.NovelSections).WithOne(a => a.Novel);
            builder.Entity<Novel>().HasOne(a => a.Category);
            builder.Entity<Chapter>().HasOne(a => a.NovelSection);
            builder.Entity<NovelSection>().HasMany(a => a.Chapters).WithOne(a =>a.NovelSection);
            builder.Entity<Comic>().HasOne(a => a.Category);
            builder.Entity<Comic>().HasOne(a => a.Author).WithMany(a=>a.Comics);
            builder.Entity<Comic>().HasMany(a => a.ComicScenes).WithOne(a => a.Comic);
            builder.Entity<Comic>().HasMany(a => a.Episodes).WithOne(a => a.Comic);
            builder.Entity<ComicScene>().HasMany(a => a.Episodes).WithOne(a => a.ComicScene);
            builder.Entity<Episode>().HasOne(a => a.Comic);
            builder.Entity<Episode>().HasOne(a => a.ComicScene);

            builder.Entity<Animation>().HasMany(a => a.AnimationEpisodes).WithOne(a => a.Animation);
            builder.Entity<Animation>().HasOne(a => a.Author);
            builder.Entity<Animation>().HasOne(a => a.Category); 

        }
    }
}
