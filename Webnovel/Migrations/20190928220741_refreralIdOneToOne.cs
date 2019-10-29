using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Webnovel.Migrations
{
    public partial class refreralIdOneToOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Referreds_AspNetUsers_UserId1",
                table: "Referreds");

            migrationBuilder.DropIndex(
                name: "IX_Referreds_UserId1",
                table: "Referreds");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Referreds");

            migrationBuilder.AddForeignKey(
                name: "FK_Referreds_AspNetUsers_UserId",
                table: "Referreds",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Referreds_AspNetUsers_UserId",
                table: "Referreds");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Referreds",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Referreds_UserId1",
                table: "Referreds",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Referreds_AspNetUsers_UserId1",
                table: "Referreds",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
