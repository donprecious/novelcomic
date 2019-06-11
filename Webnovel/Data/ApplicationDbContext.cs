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
            builder.Entity<NovelSection>().HasMany(a => a.NovelSections);

        }
    }
}
