using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Webnovel.Migrations
{
    public partial class removeRateinNovelComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NovelComments_NovelRatings_RateId",
                table: "NovelComments");

            migrationBuilder.DropIndex(
                name: "IX_NovelComments_RateId",
                table: "NovelComments");

            migrationBuilder.DropColumn(
                name: "RateId",
                table: "NovelComments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RateId",
                table: "NovelComments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_NovelComments_RateId",
                table: "NovelComments",
                column: "RateId");

            migrationBuilder.AddForeignKey(
                name: "FK_NovelComments_NovelRatings_RateId",
                table: "NovelComments",
                column: "RateId",
                principalTable: "NovelRatings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
