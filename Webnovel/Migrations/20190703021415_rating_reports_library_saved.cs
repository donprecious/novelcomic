using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Webnovel.Migrations
{
    public partial class rating_reports_library_saved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimationLibraries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnimationId = table.Column<int>(nullable: false),
                    LastViewedId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimationLibraries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimationLibraries_Animations_AnimationId",
                        column: x => x.AnimationId,
                        principalTable: "Animations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimationLibraries_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnimationRatings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnimationId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Value = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimationRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimationRatings_Animations_AnimationId",
                        column: x => x.AnimationId,
                        principalTable: "Animations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimationRatings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnimationReports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnimationId = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimationReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimationReports_Animations_AnimationId",
                        column: x => x.AnimationId,
                        principalTable: "Animations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimationReports_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnimationSaveds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnimationId = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimationSaveds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimationSaveds_Animations_AnimationId",
                        column: x => x.AnimationId,
                        principalTable: "Animations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimationSaveds_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComicLibraries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComicId = table.Column<int>(nullable: false),
                    LastViewedId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComicLibraries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComicLibraries_Comics_ComicId",
                        column: x => x.ComicId,
                        principalTable: "Comics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComicLibraries_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComicRatings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComicId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Value = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComicRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComicRatings_Comics_ComicId",
                        column: x => x.ComicId,
                        principalTable: "Comics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComicRatings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComicReports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComicId = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComicReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComicReports_Comics_ComicId",
                        column: x => x.ComicId,
                        principalTable: "Comics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComicReports_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComicSaveds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComicId = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComicSaveds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComicSaveds_Comics_ComicId",
                        column: x => x.ComicId,
                        principalTable: "Comics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComicSaveds_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NovelLibraries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LastViewedChapterId = table.Column<int>(nullable: false),
                    NovelId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NovelLibraries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NovelLibraries_Novels_NovelId",
                        column: x => x.NovelId,
                        principalTable: "Novels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NovelLibraries_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NovelRatings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NovelId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Value = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NovelRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NovelRatings_Novels_NovelId",
                        column: x => x.NovelId,
                        principalTable: "Novels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NovelRatings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NovelReports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Message = table.Column<string>(nullable: true),
                    NovelId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NovelReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NovelReports_Novels_NovelId",
                        column: x => x.NovelId,
                        principalTable: "Novels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NovelReports_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NovelSaveds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateTime = table.Column<DateTime>(nullable: false),
                    NovelId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NovelSaveds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NovelSaveds_Novels_NovelId",
                        column: x => x.NovelId,
                        principalTable: "Novels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NovelSaveds_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimationLibraries_AnimationId",
                table: "AnimationLibraries",
                column: "AnimationId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimationLibraries_UserId",
                table: "AnimationLibraries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimationRatings_AnimationId",
                table: "AnimationRatings",
                column: "AnimationId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimationRatings_UserId",
                table: "AnimationRatings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimationReports_AnimationId",
                table: "AnimationReports",
                column: "AnimationId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimationReports_UserId",
                table: "AnimationReports",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimationSaveds_AnimationId",
                table: "AnimationSaveds",
                column: "AnimationId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimationSaveds_UserId",
                table: "AnimationSaveds",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ComicLibraries_ComicId",
                table: "ComicLibraries",
                column: "ComicId");

            migrationBuilder.CreateIndex(
                name: "IX_ComicLibraries_UserId",
                table: "ComicLibraries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ComicRatings_ComicId",
                table: "ComicRatings",
                column: "ComicId");

            migrationBuilder.CreateIndex(
                name: "IX_ComicRatings_UserId",
                table: "ComicRatings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ComicReports_ComicId",
                table: "ComicReports",
                column: "ComicId");

            migrationBuilder.CreateIndex(
                name: "IX_ComicReports_UserId",
                table: "ComicReports",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ComicSaveds_ComicId",
                table: "ComicSaveds",
                column: "ComicId");

            migrationBuilder.CreateIndex(
                name: "IX_ComicSaveds_UserId",
                table: "ComicSaveds",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NovelLibraries_NovelId",
                table: "NovelLibraries",
                column: "NovelId");

            migrationBuilder.CreateIndex(
                name: "IX_NovelLibraries_UserId",
                table: "NovelLibraries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NovelRatings_NovelId",
                table: "NovelRatings",
                column: "NovelId");

            migrationBuilder.CreateIndex(
                name: "IX_NovelRatings_UserId",
                table: "NovelRatings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NovelReports_NovelId",
                table: "NovelReports",
                column: "NovelId");

            migrationBuilder.CreateIndex(
                name: "IX_NovelReports_UserId",
                table: "NovelReports",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NovelSaveds_NovelId",
                table: "NovelSaveds",
                column: "NovelId");

            migrationBuilder.CreateIndex(
                name: "IX_NovelSaveds_UserId",
                table: "NovelSaveds",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimationLibraries");

            migrationBuilder.DropTable(
                name: "AnimationRatings");

            migrationBuilder.DropTable(
                name: "AnimationReports");

            migrationBuilder.DropTable(
                name: "AnimationSaveds");

            migrationBuilder.DropTable(
                name: "ComicLibraries");

            migrationBuilder.DropTable(
                name: "ComicRatings");

            migrationBuilder.DropTable(
                name: "ComicReports");

            migrationBuilder.DropTable(
                name: "ComicSaveds");

            migrationBuilder.DropTable(
                name: "NovelLibraries");

            migrationBuilder.DropTable(
                name: "NovelRatings");

            migrationBuilder.DropTable(
                name: "NovelReports");

            migrationBuilder.DropTable(
                name: "NovelSaveds");
        }
    }
}
