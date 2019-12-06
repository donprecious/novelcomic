using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Webnovel.Migrations
{
    public partial class normalUserRefreed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NormalReferredUsers",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    DateRegistered = table.Column<DateTime>(nullable: false),
                    ReferredUserId = table.Column<string>(nullable: true),
                    UserId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NormalReferredUsers", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_NormalReferredUsers_AspNetUsers_ReferredUserId",
                        column: x => x.ReferredUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    //table.ForeignKey(
                    //    name: "FK_NormalReferredUsers_AspNetUsers_UserId1",
                    //    column: x => x.UserId1,
                    //    principalTable: "AspNetUsers",
                    //    principalColumn: "Id",
                    //    onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NormalReferredUsers_ReferredUserId",
                table: "NormalReferredUsers",
                column: "ReferredUserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_NormalReferredUsers_UserId1",
            //    table: "NormalReferredUsers",
            //    column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NormalReferredUsers");
        }
    }
}
