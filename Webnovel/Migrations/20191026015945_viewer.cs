using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Webnovel.Migrations
{
    public partial class viewer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Novels",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ComicViewer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrowserAgent = table.Column<string>(nullable: true),
                    ComicId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    IpAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComicViewer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComicViewer_Comics_ComicId",
                        column: x => x.ComicId,
                        principalTable: "Comics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NovelViewer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrowserAgent = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    IpAddress = table.Column<string>(nullable: true),
                    NovelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NovelViewer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NovelViewer_Novels_NovelId",
                        column: x => x.NovelId,
                        principalTable: "Novels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComicViewer_ComicId",
                table: "ComicViewer",
                column: "ComicId");

            migrationBuilder.CreateIndex(
                name: "IX_NovelViewer_NovelId",
                table: "NovelViewer",
                column: "NovelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComicViewer");

            migrationBuilder.DropTable(
                name: "NovelViewer");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Novels");
        }
    }
}
