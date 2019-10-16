using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Webnovel.Migrations
{
    public partial class removedChapterFromLibrary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NovelLibraries_Chapters_ChapterId",
                table: "NovelLibraries");

            migrationBuilder.DropIndex(
                name: "IX_NovelLibraries_ChapterId",
                table: "NovelLibraries");

            migrationBuilder.DropColumn(
                name: "ChapterId",
                table: "NovelLibraries");

            migrationBuilder.DropColumn(
                name: "LastViewedChapterId",
                table: "NovelLibraries");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChapterId",
                table: "NovelLibraries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LastViewedChapterId",
                table: "NovelLibraries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_NovelLibraries_ChapterId",
                table: "NovelLibraries",
                column: "ChapterId");

            migrationBuilder.AddForeignKey(
                name: "FK_NovelLibraries_Chapters_ChapterId",
                table: "NovelLibraries",
                column: "ChapterId",
                principalTable: "Chapters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
