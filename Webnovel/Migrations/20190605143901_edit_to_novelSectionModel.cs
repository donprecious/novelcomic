using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Webnovel.Migrations
{
    public partial class edit_to_novelSectionModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NovelSections_NovelSections_NovelSectionId",
                table: "NovelSections");

            migrationBuilder.DropIndex(
                name: "IX_NovelSections_NovelSectionId",
                table: "NovelSections");

            migrationBuilder.DropColumn(
                name: "NovelSectionId",
                table: "NovelSections");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NovelSectionId",
                table: "NovelSections",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NovelSections_NovelSectionId",
                table: "NovelSections",
                column: "NovelSectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_NovelSections_NovelSections_NovelSectionId",
                table: "NovelSections",
                column: "NovelSectionId",
                principalTable: "NovelSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
