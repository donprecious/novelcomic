using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Webnovel.Migrations
{
    public partial class newUpdate_to_normalUserReferred : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_NormalReferredUsers_AspNetUsers_UserId1",
            //    table: "NormalReferredUsers");

            //migrationBuilder.DropIndex(
            //    name: "IX_NormalReferredUsers_UserId1",
            //    table: "NormalReferredUsers");

            //migrationBuilder.DropColumn(
            //    name: "UserId1",
            //    table: "NormalReferredUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_NormalReferredUsers_AspNetUsers_UserId",
                table: "NormalReferredUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NormalReferredUsers_AspNetUsers_UserId",
                table: "NormalReferredUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "NormalReferredUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NormalReferredUsers_UserId1",
                table: "NormalReferredUsers",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_NormalReferredUsers_AspNetUsers_UserId1",
                table: "NormalReferredUsers",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
