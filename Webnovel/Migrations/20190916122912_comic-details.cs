using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Webnovel.Migrations
{
    public partial class comicdetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AudienceAge",
                table: "Comics",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Comics",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LeadingGender",
                table: "Comics",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WariningNotice",
                table: "Comics",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AudienceAge",
                table: "Comics");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Comics");

            migrationBuilder.DropColumn(
                name: "LeadingGender",
                table: "Comics");

            migrationBuilder.DropColumn(
                name: "WariningNotice",
                table: "Comics");
        }
    }
}
