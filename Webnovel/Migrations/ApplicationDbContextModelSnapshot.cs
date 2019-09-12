using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Webnovel.Data;

namespace Webnovel.Migrations
{
	[DbContext(typeof(ApplicationDbContext))]
	internal class ApplicationDbContextModelSnapshot : ModelSnapshot
	{
		protected override void BuildModel(ModelBuilder modelBuilder)
		{
			modelBuilder.HasAnnotation("ProductVersion", (object)"2.0.3-rtm-10026").HasAnnotation("SqlServer:ValueGenerationStrategy", (object)(SqlServerValueGenerationStrategy)1);
			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<string>("Id").ValueGeneratedOnAdd();
				b.Property<string>("ConcurrencyStamp").IsConcurrencyToken(true);
				b.Property<string>("Name").HasMaxLength(256);
				b.Property<string>("NormalizedName").HasMaxLength(256);
				b.HasKey(new string[1]
				{
					"Id"
				});
				RelationalIndexBuilderExtensions.HasFilter(RelationalIndexBuilderExtensions.HasName(b.HasIndex(new string[1]
				{
					"NormalizedName"
				}).IsUnique(true), "RoleNameIndex"), "[NormalizedName] IS NOT NULL");
				RelationalEntityTypeBuilderExtensions.ToTable(b, "AspNetRoles");
			});
			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<int>("Id").ValueGeneratedOnAdd();
				b.Property<string>("ClaimType");
				b.Property<string>("ClaimValue");
				b.Property<string>("RoleId").IsRequired(true);
				b.HasKey(new string[1]
				{
					"Id"
				});
				b.HasIndex(new string[1]
				{
					"RoleId"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "AspNetRoleClaims");
			});
			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<int>("Id").ValueGeneratedOnAdd();
				b.Property<string>("ClaimType");
				b.Property<string>("ClaimValue");
				b.Property<string>("UserId").IsRequired(true);
				b.HasKey(new string[1]
				{
					"Id"
				});
				b.HasIndex(new string[1]
				{
					"UserId"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "AspNetUserClaims");
			});
			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<string>("LoginProvider");
				b.Property<string>("ProviderKey");
				b.Property<string>("ProviderDisplayName");
				b.Property<string>("UserId").IsRequired(true);
				b.HasKey(new string[2]
				{
					"LoginProvider",
					"ProviderKey"
				});
				b.HasIndex(new string[1]
				{
					"UserId"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "AspNetUserLogins");
			});
			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<string>("UserId");
				b.Property<string>("RoleId");
				b.HasKey(new string[2]
				{
					"UserId",
					"RoleId"
				});
				b.HasIndex(new string[1]
				{
					"RoleId"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "AspNetUserRoles");
			});
			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<string>("UserId");
				b.Property<string>("LoginProvider");
				b.Property<string>("Name");
				b.Property<string>("Value");
				b.HasKey(new string[3]
				{
					"UserId",
					"LoginProvider",
					"Name"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "AspNetUserTokens");
			});
			modelBuilder.Entity("Webnovel.Entities.Animation", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<int>("Id").ValueGeneratedOnAdd();
				b.Property<int>("AuthorId");
				b.Property<int>("CategoryId");
				b.Property<string>("CoverPageImageUrl");
				b.Property<DateTime>("DateCreated");
				b.Property<string>("Description");
				b.Property<string>("Title");
				b.HasKey(new string[1]
				{
					"Id"
				});
				b.HasIndex(new string[1]
				{
					"AuthorId"
				});
				b.HasIndex(new string[1]
				{
					"CategoryId"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "Animations");
			});
			modelBuilder.Entity("Webnovel.Entities.AnimationComment", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<int>("Id").ValueGeneratedOnAdd();
				b.Property<int>("AnimationId");
				b.Property<string>("Comment").IsRequired(true);
				b.Property<string>("UserId");
				b.HasKey(new string[1]
				{
					"Id"
				});
				b.HasIndex(new string[1]
				{
					"AnimationId"
				});
				b.HasIndex(new string[1]
				{
					"UserId"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "AnimationComments");
			});
			modelBuilder.Entity("Webnovel.Entities.AnimationEpisode", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<int>("Id").ValueGeneratedOnAdd();
				b.Property<int>("AnimationId");
				b.Property<string>("Title");
				b.Property<string>("VideoUrl");
				b.HasKey(new string[1]
				{
					"Id"
				});
				b.HasIndex(new string[1]
				{
					"AnimationId"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "AnimationEpisodes");
			});
			modelBuilder.Entity("Webnovel.Entities.AnimationLibrary", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<int>("Id").ValueGeneratedOnAdd();
				b.Property<int>("AnimationEpisodeId");
				b.Property<int>("AnimationId");
				b.Property<int>("LastViewedId");
				b.Property<string>("UserId");
				b.HasKey(new string[1]
				{
					"Id"
				});
				b.HasIndex(new string[1]
				{
					"AnimationEpisodeId"
				});
				b.HasIndex(new string[1]
				{
					"AnimationId"
				});
				b.HasIndex(new string[1]
				{
					"UserId"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "AnimationLibraries");
			});
			modelBuilder.Entity("Webnovel.Entities.AnimationRating", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<int>("Id").ValueGeneratedOnAdd();
				b.Property<int>("AnimationId");
				b.Property<string>("UserId");
				b.Property<double>("Value");
				b.HasKey(new string[1]
				{
					"Id"
				});
				b.HasIndex(new string[1]
				{
					"AnimationId"
				});
				b.HasIndex(new string[1]
				{
					"UserId"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "AnimationRatings");
			});
			modelBuilder.Entity("Webnovel.Entities.AnimationReport", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<int>("Id").ValueGeneratedOnAdd();
				b.Property<int>("AnimationId");
				b.Property<string>("Message");
				b.Property<string>("UserId");
				b.HasKey(new string[1]
				{
					"Id"
				});
				b.HasIndex(new string[1]
				{
					"AnimationId"
				});
				b.HasIndex(new string[1]
				{
					"UserId"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "AnimationReports");
			});
			modelBuilder.Entity("Webnovel.Entities.AnimationSaved", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<int>("Id").ValueGeneratedOnAdd();
				b.Property<int>("AnimationId");
				b.Property<DateTime>("DateTime");
				b.Property<string>("UserId");
				b.HasKey(new string[1]
				{
					"Id"
				});
				b.HasIndex(new string[1]
				{
					"AnimationId"
				});
				b.HasIndex(new string[1]
				{
					"UserId"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "AnimationSaveds");
			});
			modelBuilder.Entity("Webnovel.Entities.AnimationTag", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<int>("Id").ValueGeneratedOnAdd();
				b.Property<int>("AnimationId");
				b.Property<int>("TagId");
				b.HasKey(new string[1]
				{
					"Id"
				});
				b.HasIndex(new string[1]
				{
					"AnimationId"
				});
				b.HasIndex(new string[1]
				{
					"TagId"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "AnimationTags");
			});
			modelBuilder.Entity("Webnovel.Entities.Author", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<int>("Id").ValueGeneratedOnAdd();
				b.Property<string>("Title");
				b.Property<string>("UserId");
				b.HasKey(new string[1]
				{
					"Id"
				});
				b.HasIndex(new string[1]
				{
					"UserId"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "Authors");
			});
			modelBuilder.Entity("Webnovel.Entities.AuthorEarning", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<int>("Id").ValueGeneratedOnAdd();
				b.Property<double>("AmountEarnedUsd");
				b.Property<DateTime>("DateTime");
				b.Property<int>("PaidChapterHistoryId");
				b.HasKey(new string[1]
				{
					"Id"
				});
				b.HasIndex(new string[1]
				{
					"PaidChapterHistoryId"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "AuthorEarnings");
			});
			modelBuilder.Entity("Webnovel.Entities.AuthorIncome", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<int>("AuthorId");
				b.Property<double>("AmountUsd");
				b.HasKey(new string[1]
				{
					"AuthorId"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "AuthorIncomes");
			});
			modelBuilder.Entity("Webnovel.Entities.Category", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<int>("Id").ValueGeneratedOnAdd();
				b.Property<string>("Description");
				b.Property<string>("Name");
				b.HasKey(new string[1]
				{
					"Id"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "Categories");
			});
			modelBuilder.Entity("Webnovel.Entities.Chapter", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<int>("Id").ValueGeneratedOnAdd();
				RelationalPropertyBuilderExtensions.HasColumnType<string>(b.Property<string>("Content"), "varchar(MAX)");
				b.Property<DateTime>("DateCreated");
				b.Property<DateTime?>("DatePublished");
				b.Property<string>("Description");
				b.Property<string>("Name");
				b.Property<int>("NovelId");
				b.Property<int>("NovelSectionId");
				b.Property<string>("TimeZone");
				b.Property<bool>("isPublished");
				b.Property<string>("status");
				b.HasKey(new string[1]
				{
					"Id"
				});
				b.HasIndex(new string[1]
				{
					"NovelId"
				});
				b.HasIndex(new string[1]
				{
					"NovelSectionId"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "Chapters");
			});
			modelBuilder.Entity("Webnovel.Entities.Comic", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<int>("Id").ValueGeneratedOnAdd();
				b.Property<int>("AuthorId");
				b.Property<int>("CategoryId");
				b.Property<string>("CoverPageImageUrl");
				b.Property<DateTime>("DateCreated");
				b.Property<string>("Description");
				b.Property<string>("Title");
				b.HasKey(new string[1]
				{
					"Id"
				});
				b.HasIndex(new string[1]
				{
					"AuthorId"
				});
				b.HasIndex(new string[1]
				{
					"CategoryId"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "Comics");
			});
			modelBuilder.Entity("Webnovel.Entities.ComicComment", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<int>("Id").ValueGeneratedOnAdd();
				b.Property<int>("ComicId");
				b.Property<string>("Comment").IsRequired(true);
				b.Property<DateTime>("DateCreated");
				b.Property<string>("UserId");
				b.HasKey(new string[1]
				{
					"Id"
				});
				b.HasIndex(new string[1]
				{
					"ComicId"
				});
				b.HasIndex(new string[1]
				{
					"UserId"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "ComicComments");
			});
			modelBuilder.Entity("Webnovel.Entities.ComicLibrary", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<int>("Id").ValueGeneratedOnAdd();
				b.Property<int>("ComicId");
				b.Property<int>("EpisodeId");
				b.Property<int>("LastViewedId");
				b.Property<string>("UserId");
				b.HasKey(new string[1]
				{
					"Id"
				});
				b.HasIndex(new string[1]
				{
					"ComicId"
				});
				b.HasIndex(new string[1]
				{
					"EpisodeId"
				});
				b.HasIndex(new string[1]
				{
					"UserId"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "ComicLibraries");
			});
			modelBuilder.Entity("Webnovel.Entities.ComicRating", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<int>("Id").ValueGeneratedOnAdd();
				b.Property<int>("ComicId");
				b.Property<string>("UserId");
				b.Property<double>("Value");
				b.HasKey(new string[1]
				{
					"Id"
				});
				b.HasIndex(new string[1]
				{
					"ComicId"
				});
				b.HasIndex(new string[1]
				{
					"UserId"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "ComicRatings");
			});
			modelBuilder.Entity("Webnovel.Entities.ComicReport", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<int>("Id").ValueGeneratedOnAdd();
				b.Property<int>("ComicId");
				b.Property<string>("Message");
				b.Property<string>("UserId");
				b.HasKey(new string[1]
				{
					"Id"
				});
				b.HasIndex(new string[1]
				{
					"ComicId"
				});
				b.HasIndex(new string[1]
				{
					"UserId"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "ComicReports");
			});
			modelBuilder.Entity("Webnovel.Entities.ComicSaved", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<int>("Id").ValueGeneratedOnAdd();
				b.Property<int>("ComicId");
				b.Property<DateTime>("DateTime");
				b.Property<string>("UserId");
				b.HasKey(new string[1]
				{
					"Id"
				});
				b.HasIndex(new string[1]
				{
					"ComicId"
				});
				b.HasIndex(new string[1]
				{
					"UserId"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "ComicSaveds");
			});
			modelBuilder.Entity("Webnovel.Entities.ComicScene", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<int>("Id").ValueGeneratedOnAdd();
				b.Property<int>("ComicId");
				b.Property<string>("Title");
				b.HasKey(new string[1]
				{
					"Id"
				});
				b.HasIndex(new string[1]
				{
					"ComicId"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "ComicScenes");
			});
			modelBuilder.Entity("Webnovel.Entities.ComicTag", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<int>("Id").ValueGeneratedOnAdd();
				b.Property<int>("ComicId");
				b.Property<int>("TagId");
				b.HasKey(new string[1]
				{
					"Id"
				});
				b.HasIndex(new string[1]
				{
					"ComicId"
				});
				b.HasIndex(new string[1]
				{
					"TagId"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "ComicTags");
			});
			modelBuilder.Entity("Webnovel.Entities.Episode", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<int>("Id").ValueGeneratedOnAdd();
				b.Property<int>("ComicId");
				b.Property<int>("ComicSceneId");
				RelationalPropertyBuilderExtensions.HasColumnType<string>(b.Property<string>("Content"), "varchar(MAX)");
				b.Property<string>("Description");
				b.Property<string>("ImageUrl");
				b.Property<string>("Name");
				b.HasKey(new string[1]
				{
					"Id"
				});
				b.HasIndex(new string[1]
				{
					"ComicId"
				});
				b.HasIndex(new string[1]
				{
					"ComicSceneId"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "Episodes");
			});
			modelBuilder.Entity("Webnovel.Entities.FundHistory", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<int>("Id").ValueGeneratedOnAdd();
				b.Property<double>("AmountUsd");
				b.Property<string>("PaymentGateWay");
				b.Property<string>("ReferenceNumber");
				b.Property<string>("UserId");
				b.HasKey(new string[1]
				{
					"Id"
				});
				b.HasIndex(new string[1]
				{
					"UserId"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "FundHistories");
			});
			modelBuilder.Entity("Webnovel.Entities.Novel", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<int>("Id").ValueGeneratedOnAdd();
				b.Property<string>("AudienceAge");
				b.Property<int>("AuthorId");
				b.Property<int>("CategoryId");
				b.Property<string>("CoverPageImageUrl");
				b.Property<DateTime>("DateCreated");
				b.Property<string>("Language");
				b.Property<string>("LeadingGender");
				b.Property<string>("Name");
				b.Property<string>("Title");
				b.Property<string>("WariningNotice");
				b.HasKey(new string[1]
				{
					"Id"
				});
				b.HasIndex(new string[1]
				{
					"AuthorId"
				});
				b.HasIndex(new string[1]
				{
					"CategoryId"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "Novels");
			});
			modelBuilder.Entity("Webnovel.Entities.NovelComment", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<int>("Id").ValueGeneratedOnAdd();
				b.Property<string>("Comment").IsRequired(true);
				b.Property<int>("NovelId");
				b.Property<string>("UserId");
				b.HasKey(new string[1]
				{
					"Id"
				});
				b.HasIndex(new string[1]
				{
					"NovelId"
				});
				b.HasIndex(new string[1]
				{
					"UserId"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "NovelComments");
			});
			modelBuilder.Entity("Webnovel.Entities.NovelLibrary", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<int>("Id").ValueGeneratedOnAdd();
				b.Property<int>("ChapterId");
				b.Property<int>("LastViewedChapterId");
				b.Property<int>("NovelId");
				b.Property<string>("UserId");
				b.HasKey(new string[1]
				{
					"Id"
				});
				b.HasIndex(new string[1]
				{
					"ChapterId"
				});
				b.HasIndex(new string[1]
				{
					"NovelId"
				});
				b.HasIndex(new string[1]
				{
					"UserId"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "NovelLibraries");
			});
			modelBuilder.Entity("Webnovel.Entities.NovelRating", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<int>("Id").ValueGeneratedOnAdd();
				b.Property<int>("NovelId");
				b.Property<string>("UserId");
				b.Property<double>("Value");
				b.HasKey(new string[1]
				{
					"Id"
				});
				b.HasIndex(new string[1]
				{
					"NovelId"
				});
				b.HasIndex(new string[1]
				{
					"UserId"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "NovelRatings");
			});
			modelBuilder.Entity("Webnovel.Entities.NovelReport", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<int>("Id").ValueGeneratedOnAdd();
				b.Property<string>("Message");
				b.Property<int>("NovelId");
				b.Property<string>("UserId");
				b.HasKey(new string[1]
				{
					"Id"
				});
				b.HasIndex(new string[1]
				{
					"NovelId"
				});
				b.HasIndex(new string[1]
				{
					"UserId"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "NovelReports");
			});
			modelBuilder.Entity("Webnovel.Entities.NovelSaved", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<int>("Id").ValueGeneratedOnAdd();
				b.Property<DateTime>("DateTime");
				b.Property<int>("NovelId");
				b.Property<string>("UserId");
				b.HasKey(new string[1]
				{
					"Id"
				});
				b.HasIndex(new string[1]
				{
					"NovelId"
				});
				b.HasIndex(new string[1]
				{
					"UserId"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "NovelSaveds");
			});
			modelBuilder.Entity("Webnovel.Entities.NovelSection", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<int>("Id").ValueGeneratedOnAdd();
				b.Property<int>("NovelId");
				b.Property<string>("Title");
				b.HasKey(new string[1]
				{
					"Id"
				});
				b.HasIndex(new string[1]
				{
					"NovelId"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "NovelSections");
			});
			modelBuilder.Entity("Webnovel.Entities.NovelTag", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<int>("Id").ValueGeneratedOnAdd();
				b.Property<int>("NovelId");
				b.Property<int>("TagId");
				b.HasKey(new string[1]
				{
					"Id"
				});
				b.HasIndex(new string[1]
				{
					"NovelId"
				});
				b.HasIndex(new string[1]
				{
					"TagId"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "NovelTags");
			});
			modelBuilder.Entity("Webnovel.Entities.PaidChapterHistory", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<int>("Id").ValueGeneratedOnAdd();
				b.Property<int>("ChapterId");
				b.Property<double>("CowriesUsed");
				b.Property<DateTime>("DateTime");
				b.Property<double>("SpentInUsd");
				b.Property<string>("UserId");
				b.HasKey(new string[1]
				{
					"Id"
				});
				b.HasIndex(new string[1]
				{
					"ChapterId"
				});
				b.HasIndex(new string[1]
				{
					"UserId"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "PaidChapterHistories");
			});
			modelBuilder.Entity("Webnovel.Entities.Tag", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<int>("Id").ValueGeneratedOnAdd();
				b.Property<string>("Name");
				b.HasKey(new string[1]
				{
					"Id"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "Tags");
			});
			modelBuilder.Entity("Webnovel.Entities.UserFund", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<int>("UserId").ValueGeneratedOnAdd();
				b.Property<double>("Cowries");
				b.Property<string>("UserId1");
				b.Property<int>("WordsRemaining");
				b.HasKey(new string[1]
				{
					"UserId"
				});
				b.HasIndex(new string[1]
				{
					"UserId1"
				});
				RelationalEntityTypeBuilderExtensions.ToTable(b, "UserFunds");
			});
			modelBuilder.Entity("Webnovel.Models.ApplicationUser", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.Property<string>("Id").ValueGeneratedOnAdd();
				b.Property<int>("AccessFailedCount");
				b.Property<string>("ConcurrencyStamp").IsConcurrencyToken(true);
				b.Property<string>("Email").HasMaxLength(256);
				b.Property<bool>("EmailConfirmed");
				b.Property<string>("FirstName");
				b.Property<string>("LastName");
				b.Property<bool>("LockoutEnabled");
				b.Property<DateTimeOffset?>("LockoutEnd");
				b.Property<string>("NormalizedEmail").HasMaxLength(256);
				b.Property<string>("NormalizedUserName").HasMaxLength(256);
				b.Property<string>("PasswordHash");
				b.Property<string>("PhoneNumber");
				b.Property<bool>("PhoneNumberConfirmed");
				b.Property<string>("SecurityStamp");
				b.Property<bool>("TwoFactorEnabled");
				b.Property<string>("UserName").HasMaxLength(256);
				b.HasKey(new string[1]
				{
					"Id"
				});
				RelationalIndexBuilderExtensions.HasName(b.HasIndex(new string[1]
				{
					"NormalizedEmail"
				}), "EmailIndex");
				RelationalIndexBuilderExtensions.HasFilter(RelationalIndexBuilderExtensions.HasName(b.HasIndex(new string[1]
				{
					"NormalizedUserName"
				}).IsUnique(true), "UserNameIndex"), "[NormalizedUserName] IS NOT NULL");
				RelationalEntityTypeBuilderExtensions.ToTable(b, "AspNetUsers");
			});
			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", (string)null).WithMany((string)null).HasForeignKey(new string[1]
				{
					"RoleId"
				})
					.OnDelete((DeleteBehavior)3);
			});
			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.HasOne("Webnovel.Models.ApplicationUser", (string)null).WithMany((string)null).HasForeignKey(new string[1]
				{
					"UserId"
				})
					.OnDelete((DeleteBehavior)3);
			});
			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.HasOne("Webnovel.Models.ApplicationUser", (string)null).WithMany((string)null).HasForeignKey(new string[1]
				{
					"UserId"
				})
					.OnDelete((DeleteBehavior)3);
			});
			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", (string)null).WithMany((string)null).HasForeignKey(new string[1]
				{
					"RoleId"
				})
					.OnDelete((DeleteBehavior)3);
				b.HasOne("Webnovel.Models.ApplicationUser", (string)null).WithMany((string)null).HasForeignKey(new string[1]
				{
					"UserId"
				})
					.OnDelete((DeleteBehavior)3);
			});
			modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.HasOne("Webnovel.Models.ApplicationUser", (string)null).WithMany((string)null).HasForeignKey(new string[1]
				{
					"UserId"
				})
					.OnDelete((DeleteBehavior)3);
			});
			modelBuilder.Entity("Webnovel.Entities.Animation", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.HasOne("Webnovel.Entities.Author", "Author").WithMany((string)null).HasForeignKey(new string[1]
				{
					"AuthorId"
				})
					.OnDelete((DeleteBehavior)3);
				b.HasOne("Webnovel.Entities.Category", "Category").WithMany((string)null).HasForeignKey(new string[1]
				{
					"CategoryId"
				})
					.OnDelete((DeleteBehavior)3);
			});
			modelBuilder.Entity("Webnovel.Entities.AnimationComment", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.HasOne("Webnovel.Entities.Animation", "Animation").WithMany((string)null).HasForeignKey(new string[1]
				{
					"AnimationId"
				})
					.OnDelete((DeleteBehavior)3);
				b.HasOne("Webnovel.Models.ApplicationUser", "User").WithMany((string)null).HasForeignKey(new string[1]
				{
					"UserId"
				});
			});
			modelBuilder.Entity("Webnovel.Entities.AnimationEpisode", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.HasOne("Webnovel.Entities.Animation", "Animation").WithMany("AnimationEpisodes").HasForeignKey(new string[1]
				{
					"AnimationId"
				})
					.OnDelete((DeleteBehavior)3);
			});
			modelBuilder.Entity("Webnovel.Entities.AnimationLibrary", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.HasOne("Webnovel.Entities.AnimationEpisode", "AnimationEpisode").WithMany((string)null).HasForeignKey(new string[1]
				{
					"AnimationEpisodeId"
				})
					.OnDelete((DeleteBehavior)3);
				b.HasOne("Webnovel.Entities.Animation", "Animation").WithMany((string)null).HasForeignKey(new string[1]
				{
					"AnimationId"
				})
					.OnDelete((DeleteBehavior)3);
				b.HasOne("Webnovel.Models.ApplicationUser", "User").WithMany((string)null).HasForeignKey(new string[1]
				{
					"UserId"
				});
			});
			modelBuilder.Entity("Webnovel.Entities.AnimationRating", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.HasOne("Webnovel.Entities.Animation", "Animation").WithMany("AnimationRatings").HasForeignKey(new string[1]
				{
					"AnimationId"
				})
					.OnDelete((DeleteBehavior)3);
				b.HasOne("Webnovel.Models.ApplicationUser", "User").WithMany((string)null).HasForeignKey(new string[1]
				{
					"UserId"
				});
			});
			modelBuilder.Entity("Webnovel.Entities.AnimationReport", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.HasOne("Webnovel.Entities.Animation", "Animation").WithMany((string)null).HasForeignKey(new string[1]
				{
					"AnimationId"
				})
					.OnDelete((DeleteBehavior)3);
				b.HasOne("Webnovel.Models.ApplicationUser", "User").WithMany((string)null).HasForeignKey(new string[1]
				{
					"UserId"
				});
			});
			modelBuilder.Entity("Webnovel.Entities.AnimationSaved", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.HasOne("Webnovel.Entities.Animation", "Animation").WithMany((string)null).HasForeignKey(new string[1]
				{
					"AnimationId"
				})
					.OnDelete((DeleteBehavior)3);
				b.HasOne("Webnovel.Models.ApplicationUser", "User").WithMany((string)null).HasForeignKey(new string[1]
				{
					"UserId"
				});
			});
			modelBuilder.Entity("Webnovel.Entities.AnimationTag", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.HasOne("Webnovel.Entities.Animation", "Animation").WithMany((string)null).HasForeignKey(new string[1]
				{
					"AnimationId"
				})
					.OnDelete((DeleteBehavior)3);
				b.HasOne("Webnovel.Entities.Tag", "Tag").WithMany((string)null).HasForeignKey(new string[1]
				{
					"TagId"
				})
					.OnDelete((DeleteBehavior)3);
			});
			modelBuilder.Entity("Webnovel.Entities.Author", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.HasOne("Webnovel.Models.ApplicationUser", "User").WithMany((string)null).HasForeignKey(new string[1]
				{
					"UserId"
				});
			});
			modelBuilder.Entity("Webnovel.Entities.AuthorEarning", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.HasOne("Webnovel.Entities.PaidChapterHistory", "PaidChapterHistory").WithMany((string)null).HasForeignKey(new string[1]
				{
					"PaidChapterHistoryId"
				})
					.OnDelete((DeleteBehavior)3);
			});
			modelBuilder.Entity("Webnovel.Entities.AuthorIncome", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.HasOne("Webnovel.Entities.Author", "Author").WithMany((string)null).HasForeignKey(new string[1]
				{
					"AuthorId"
				})
					.OnDelete((DeleteBehavior)3);
			});
			modelBuilder.Entity("Webnovel.Entities.Chapter", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.HasOne("Webnovel.Entities.Novel", "Novel").WithMany("Chapters").HasForeignKey(new string[1]
				{
					"NovelId"
				})
					.OnDelete((DeleteBehavior)3);
				b.HasOne("Webnovel.Entities.NovelSection", "NovelSection").WithMany("Chapters").HasForeignKey(new string[1]
				{
					"NovelSectionId"
				})
					.OnDelete((DeleteBehavior)3);
			});
			modelBuilder.Entity("Webnovel.Entities.Comic", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.HasOne("Webnovel.Entities.Author", "Author").WithMany("Comics").HasForeignKey(new string[1]
				{
					"AuthorId"
				})
					.OnDelete((DeleteBehavior)3);
				b.HasOne("Webnovel.Entities.Category", "Category").WithMany((string)null).HasForeignKey(new string[1]
				{
					"CategoryId"
				})
					.OnDelete((DeleteBehavior)3);
			});
			modelBuilder.Entity("Webnovel.Entities.ComicComment", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.HasOne("Webnovel.Entities.Comic", "Comic").WithMany((string)null).HasForeignKey(new string[1]
				{
					"ComicId"
				})
					.OnDelete((DeleteBehavior)3);
				b.HasOne("Webnovel.Models.ApplicationUser", "User").WithMany((string)null).HasForeignKey(new string[1]
				{
					"UserId"
				});
			});
			modelBuilder.Entity("Webnovel.Entities.ComicLibrary", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.HasOne("Webnovel.Entities.Comic", "Comic").WithMany((string)null).HasForeignKey(new string[1]
				{
					"ComicId"
				})
					.OnDelete((DeleteBehavior)3);
				b.HasOne("Webnovel.Entities.Episode", "Episode").WithMany((string)null).HasForeignKey(new string[1]
				{
					"EpisodeId"
				})
					.OnDelete((DeleteBehavior)3);
				b.HasOne("Webnovel.Models.ApplicationUser", "User").WithMany((string)null).HasForeignKey(new string[1]
				{
					"UserId"
				});
			});
			modelBuilder.Entity("Webnovel.Entities.ComicRating", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.HasOne("Webnovel.Entities.Comic", "Comic").WithMany("ComicRatings").HasForeignKey(new string[1]
				{
					"ComicId"
				})
					.OnDelete((DeleteBehavior)3);
				b.HasOne("Webnovel.Models.ApplicationUser", "User").WithMany((string)null).HasForeignKey(new string[1]
				{
					"UserId"
				});
			});
			modelBuilder.Entity("Webnovel.Entities.ComicReport", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.HasOne("Webnovel.Entities.Comic", "Comic").WithMany((string)null).HasForeignKey(new string[1]
				{
					"ComicId"
				})
					.OnDelete((DeleteBehavior)3);
				b.HasOne("Webnovel.Models.ApplicationUser", "User").WithMany((string)null).HasForeignKey(new string[1]
				{
					"UserId"
				});
			});
			modelBuilder.Entity("Webnovel.Entities.ComicSaved", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.HasOne("Webnovel.Entities.Comic", "Comic").WithMany((string)null).HasForeignKey(new string[1]
				{
					"ComicId"
				})
					.OnDelete((DeleteBehavior)3);
				b.HasOne("Webnovel.Models.ApplicationUser", "User").WithMany((string)null).HasForeignKey(new string[1]
				{
					"UserId"
				});
			});
			modelBuilder.Entity("Webnovel.Entities.ComicScene", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.HasOne("Webnovel.Entities.Comic", "Comic").WithMany("ComicScenes").HasForeignKey(new string[1]
				{
					"ComicId"
				})
					.OnDelete((DeleteBehavior)3);
			});
			modelBuilder.Entity("Webnovel.Entities.ComicTag", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.HasOne("Webnovel.Entities.Comic", "Comic").WithMany((string)null).HasForeignKey(new string[1]
				{
					"ComicId"
				})
					.OnDelete((DeleteBehavior)3);
				b.HasOne("Webnovel.Entities.Tag", "Tag").WithMany((string)null).HasForeignKey(new string[1]
				{
					"TagId"
				})
					.OnDelete((DeleteBehavior)3);
			});
			modelBuilder.Entity("Webnovel.Entities.Episode", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.HasOne("Webnovel.Entities.Comic", "Comic").WithMany("Episodes").HasForeignKey(new string[1]
				{
					"ComicId"
				})
					.OnDelete((DeleteBehavior)3);
				b.HasOne("Webnovel.Entities.ComicScene", "ComicScene").WithMany("Episodes").HasForeignKey(new string[1]
				{
					"ComicSceneId"
				})
					.OnDelete((DeleteBehavior)3);
			});
			modelBuilder.Entity("Webnovel.Entities.FundHistory", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.HasOne("Webnovel.Models.ApplicationUser", "User").WithMany((string)null).HasForeignKey(new string[1]
				{
					"UserId"
				});
			});
			modelBuilder.Entity("Webnovel.Entities.Novel", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.HasOne("Webnovel.Entities.Author", "Author").WithMany("Novels").HasForeignKey(new string[1]
				{
					"AuthorId"
				})
					.OnDelete((DeleteBehavior)3);
				b.HasOne("Webnovel.Entities.Category", "Category").WithMany((string)null).HasForeignKey(new string[1]
				{
					"CategoryId"
				})
					.OnDelete((DeleteBehavior)3);
			});
			modelBuilder.Entity("Webnovel.Entities.NovelComment", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.HasOne("Webnovel.Entities.Novel", "Novel").WithMany((string)null).HasForeignKey(new string[1]
				{
					"NovelId"
				})
					.OnDelete((DeleteBehavior)3);
				b.HasOne("Webnovel.Models.ApplicationUser", "User").WithMany((string)null).HasForeignKey(new string[1]
				{
					"UserId"
				});
			});
			modelBuilder.Entity("Webnovel.Entities.NovelLibrary", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.HasOne("Webnovel.Entities.Chapter", "Chapter").WithMany((string)null).HasForeignKey(new string[1]
				{
					"ChapterId"
				})
					.OnDelete((DeleteBehavior)3);
				b.HasOne("Webnovel.Entities.Novel", "Novel").WithMany((string)null).HasForeignKey(new string[1]
				{
					"NovelId"
				})
					.OnDelete((DeleteBehavior)3);
				b.HasOne("Webnovel.Models.ApplicationUser", "User").WithMany((string)null).HasForeignKey(new string[1]
				{
					"UserId"
				});
			});
			modelBuilder.Entity("Webnovel.Entities.NovelRating", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.HasOne("Webnovel.Entities.Novel", "Novel").WithMany("NovelRatings").HasForeignKey(new string[1]
				{
					"NovelId"
				})
					.OnDelete((DeleteBehavior)3);
				b.HasOne("Webnovel.Models.ApplicationUser", "User").WithMany((string)null).HasForeignKey(new string[1]
				{
					"UserId"
				});
			});
			modelBuilder.Entity("Webnovel.Entities.NovelReport", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.HasOne("Webnovel.Entities.Novel", "Novel").WithMany((string)null).HasForeignKey(new string[1]
				{
					"NovelId"
				})
					.OnDelete((DeleteBehavior)3);
				b.HasOne("Webnovel.Models.ApplicationUser", "User").WithMany((string)null).HasForeignKey(new string[1]
				{
					"UserId"
				});
			});
			modelBuilder.Entity("Webnovel.Entities.NovelSaved", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.HasOne("Webnovel.Entities.Novel", "Novel").WithMany((string)null).HasForeignKey(new string[1]
				{
					"NovelId"
				})
					.OnDelete((DeleteBehavior)3);
				b.HasOne("Webnovel.Models.ApplicationUser", "User").WithMany((string)null).HasForeignKey(new string[1]
				{
					"UserId"
				});
			});
			modelBuilder.Entity("Webnovel.Entities.NovelSection", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.HasOne("Webnovel.Entities.Novel", "Novel").WithMany("NovelSections").HasForeignKey(new string[1]
				{
					"NovelId"
				})
					.OnDelete((DeleteBehavior)3);
			});
			modelBuilder.Entity("Webnovel.Entities.NovelTag", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.HasOne("Webnovel.Entities.Novel", "Novel").WithMany("Tags").HasForeignKey(new string[1]
				{
					"NovelId"
				})
					.OnDelete((DeleteBehavior)3);
				b.HasOne("Webnovel.Entities.Tag", "Tag").WithMany((string)null).HasForeignKey(new string[1]
				{
					"TagId"
				})
					.OnDelete((DeleteBehavior)3);
			});
			modelBuilder.Entity("Webnovel.Entities.PaidChapterHistory", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.HasOne("Webnovel.Entities.Chapter", "Chapter").WithMany((string)null).HasForeignKey(new string[1]
				{
					"ChapterId"
				})
					.OnDelete((DeleteBehavior)3);
				b.HasOne("Webnovel.Models.ApplicationUser", "User").WithMany((string)null).HasForeignKey(new string[1]
				{
					"UserId"
				});
			});
			modelBuilder.Entity("Webnovel.Entities.UserFund", (Action<EntityTypeBuilder>)delegate(EntityTypeBuilder b)
			{
				b.HasOne("Webnovel.Models.ApplicationUser", "User").WithMany((string)null).HasForeignKey(new string[1]
				{
					"UserId1"
				});
			});
		}

	
	}
}
