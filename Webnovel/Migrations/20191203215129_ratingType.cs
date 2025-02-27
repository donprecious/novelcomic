﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Webnovel.Migrations
{
    public partial class ratingType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RatingTypeId",
                table: "NovelRatings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RatingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NovelRatings_RatingTypeId",
                table: "NovelRatings",
                column: "RatingTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_NovelRatings_RatingTypes_RatingTypeId",
                table: "NovelRatings",
                column: "RatingTypeId",
                principalTable: "RatingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NovelRatings_RatingTypes_RatingTypeId",
                table: "NovelRatings");

            migrationBuilder.DropTable(
                name: "RatingTypes");

            migrationBuilder.DropIndex(
                name: "IX_NovelRatings_RatingTypeId",
                table: "NovelRatings");

            migrationBuilder.DropColumn(
                name: "RatingTypeId",
                table: "NovelRatings");
        }
    }
}
