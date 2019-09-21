using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Webnovel.Data;
using Webnovel.Entities;
using Webnovel.Models;
using Webnovel.Repository;
using Webnovel.Services;

namespace Webnovel
{
	public class Startup
	{
		public IConfiguration Configuration
		{
			get;
		}

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(o =>
                {
                    o.Password.RequireDigit = false;
                    o.Password.RequireLowercase = false;
                    o.Password.RequireUppercase = true;
                    o.Password.RequireNonAlphanumeric = false;
                    o.Password.RequiredLength = 6;
                    o.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
   // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped<ICategory, Repository.Category>();
            services.AddScoped<INovel, Repository.Novel>();
            services.AddScoped<IAuthor, Repository.Author>();
            services.AddScoped<IComic, Repository.Comic>();
            services.AddScoped<IAnimation, Repository.Animation>();
            services.AddScoped<IUser, Repository.User>();


            services.AddMvc();
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {

                app.UseExceptionHandler("/Home/Error");
            }
            app.UseBrowserLink();
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();

            AutoMapper.Mapper.Initialize(map =>
            {
                map.CreateMap<Entities.Novel, Models.NovelVm>();
                map.CreateMap<Models.NovelVm, Entities.Novel>();

                map.CreateMap<Entities.Category, Models.CategoryVm>();
                map.CreateMap<Models.CategoryVm, Entities.Category>();

                map.CreateMap<Entities.Chapter, Models.ChapterVm>();
                map.CreateMap<Models.ChapterVm, Entities.Chapter>();

                map.CreateMap<Entities.Author, Models.AuthorVm>();
                map.CreateMap<Models.AuthorVm, Entities.Author>();

                map.CreateMap<Entities.NovelSection, Models.NovelSectionVm>();
                map.CreateMap<Models.NovelSectionVm, Entities.NovelSection>();

                map.CreateMap<Entities.Comic, Models.ComicVm>();
                map.CreateMap<Models.ComicVm, Entities.Comic>();

                map.CreateMap<Models.CoverPageVm, Entities.Comic>();
                map.CreateMap<Entities.Comic, Models.CoverPageVm>();



                map.CreateMap<Entities.ComicScene, Models.ComicSceneVm>();
                map.CreateMap<Models.ComicSceneVm, Entities.ComicScene>();

                map.CreateMap<Entities.Episode, Models.EpisodeVm>();
                map.CreateMap<Models.EpisodeVm, Entities.Episode>();

                map.CreateMap<Entities.Animation, Models.AnimationVm>();
                map.CreateMap<Models.AnimationVm, Entities.Animation>();

                map.CreateMap<Models.AnimationCoverPageVm, Entities.Animation>();
                map.CreateMap<Entities.Animation, Models.AnimationCoverPageVm>();

                map.CreateMap<Entities.AnimationEpisode, Models.AnimationEpisodeVm>();
                map.CreateMap<Models.AnimationEpisodeVm, Entities.AnimationEpisode>();

                map.CreateMap<Entities.AnimationComment, Models.AnimationCommentVm>();
                map.CreateMap<Models.AnimationCommentVm, Entities.AnimationComment>();

                map.CreateMap<Entities.NovelComment, Models.NovelCommentVm>();
                map.CreateMap<Models.NovelCommentVm, Entities.NovelComment>();
            });

            app.UseStaticFiles();

            app.UseAuthentication();



            app.UseMvc(routes =>
            {
                routes.MapAreaRoute(
                    name: "MyAreaAdmin",
                    areaName: "Admin",
                    template: "Admin/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
