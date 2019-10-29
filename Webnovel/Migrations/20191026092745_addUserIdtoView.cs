using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Webnovel.Migrations
{
    public partial class addUserIdtoView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "NovelViewer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ComicViewer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "NovelViewer");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ComicViewer");
        }
    }
}
