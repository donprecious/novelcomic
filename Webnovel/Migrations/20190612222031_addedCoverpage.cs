using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Webnovel.Migrations
{
    public partial class addedCoverpage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverPageImageUrl",
                table: "Novels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoverPageImageUrl",
                table: "Comics",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverPageImageUrl",
                table: "Novels");

            migrationBuilder.DropColumn(
                name: "CoverPageImageUrl",
                table: "Comics");
        }
    }
}
