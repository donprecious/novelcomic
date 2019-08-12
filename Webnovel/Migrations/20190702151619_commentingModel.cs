using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Webnovel.Migrations
{
    public partial class commentingModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimationComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnimationId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimationComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimationComments_Animations_AnimationId",
                        column: x => x.AnimationId,
                        principalTable: "Animations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimationComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComicComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComicId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComicComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComicComments_Comics_ComicId",
                        column: x => x.ComicId,
                        principalTable: "Comics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComicComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NovelComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(nullable: false),
                    NovelId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NovelComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NovelComments_Novels_NovelId",
                        column: x => x.NovelId,
                        principalTable: "Novels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NovelComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimationComments_AnimationId",
                table: "AnimationComments",
                column: "AnimationId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimationComments_UserId",
                table: "AnimationComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ComicComments_ComicId",
                table: "ComicComments",
                column: "ComicId");

            migrationBuilder.CreateIndex(
                name: "IX_ComicComments_UserId",
                table: "ComicComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NovelComments_NovelId",
                table: "NovelComments",
                column: "NovelId");

            migrationBuilder.CreateIndex(
                name: "IX_NovelComments_UserId",
                table: "NovelComments",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimationComments");

            migrationBuilder.DropTable(
                name: "ComicComments");

            migrationBuilder.DropTable(
                name: "NovelComments");
        }
    }
}
