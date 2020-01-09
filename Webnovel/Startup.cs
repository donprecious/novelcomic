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
using System.Buffers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;
using ReflectionIT.Mvc.Paging;
using Webnovel.Data;
using Webnovel.DtoModels;
using Webnovel.Entities;
using Webnovel.Filters;
using Webnovel.Hubs;
using Webnovel.Models;
using Webnovel.Repository;
using Webnovel.Services;
using ComicComment = Webnovel.Entities.ComicComment;
using NovelComment = Webnovel.Repository.NovelComment;

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
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromMinutes(60);
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });
            services.AddAuthentication().AddGoogle(o =>
            {
                o.ClientId = "473446857855-ea7uf8cjvr9ttmc270pp9f1uqni65vs7.apps.googleusercontent.com";
                o.ClientSecret = "u322Bps4I7SGj3bvTDk4TX6R";
              
            })
                .AddFacebook(o =>
                {
                    o.AppId = "562656214588013";
                    o.AppSecret = "6f08585198e73a56b8d0a874c1b63a20";
                })
                
                ;
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
            services.AddScoped<IReferral, Repository.Referral>();
            services.AddScoped<INovelHistory, NovelHistory>();
            services.AddScoped<IComicHistory, Repository.ComicHistory>();

            services.AddScoped<INovelComment, NovelComment>();
            services.AddScoped<IComicComment, Repository.ComicComment>();
            services.AddScoped<IAppConfig, AppConfig>();
            services.AddScoped<IRate, Rate>();
            services.AddScoped<IPayment, Payment>();
            services.AddScoped<IPage, Repository.Page>();
            services.AddScoped<IRate, Repository.Rate>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAsyncInitializer<MyAppInitializer>();
            services.AddPaging();

            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(Configuration.GetConnectionString("DefaultConnection"), new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    UsePageLocksOnDequeue = true,
                    DisableGlobalLocks = true
                }));

            // Add the processing server as IHostedService
            services.AddHangfireServer();
            //for website optimization 
            services.AddResponseCompression();


            services.AddMvc(o =>
            {
             

            })
                .AddJsonOptions(options =>
                 {

                     options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                 }); ;
            services.AddCors(options => options.AddPolicy("CorsPolicy", 
                builder => 
                {
                    builder.AllowAnyMethod().AllowAnyHeader()
                        .AllowAnyOrigin()
                        .AllowCredentials();
                }));

        

            services.AddSignalR(o =>
            {
                o.EnableDetailedErrors = true;
            }); 

          

		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env,  IBackgroundJobClient backgroundJobs,  IRecurringJobManager recurringJobManager)
        {
            if (env.IsDevelopment())
            {
                //app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {

                app.UseExceptionHandler("/Home/Error");
            }
            //app.UseBrowserLink();
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

                map.CreateMap<Entities.ChapterComment, Models.NovelChapterCommentVm>();
                map.CreateMap<Models.NovelChapterCommentVm, Entities.ChapterComment>();

                map.CreateMap<Subscription, SubscriptionVm>();
                map.CreateMap<SubscriptionVm,Subscription>();
                map.CreateMap<ApplicationUser, UserDto>();
                map.CreateMap<Entities.NovelComment, NovelCommentDto>();
            });

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseSession();
          //  app.UseHttpContextItemsMiddleware();

          app.UseHangfireDashboard("/jobs", new DashboardOptions()
          {
              Authorization = new [] { new HangDashboardAuthorizationFilter()}
          });
          backgroundJobs.Enqueue(() => Console.WriteLine("Hello world from Hangfire!"));
          //"0 0/30 0 ? * * *"
          RecurringJob.AddOrUpdate<INovel>(a =>  a.PublishAllChapters(), "*/30 * * * *");
          //RecurringJob.AddOrUpdate(); 

          //   website optimization 
          app.UseResponseCompression();
          app.UseSignalR(routes => 
          {
              routes.MapHub<NovelCommentHub>("/novelCommentHub");
              routes.MapHub<ComicCommentHub>("/comicCommentHub");
          });
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
