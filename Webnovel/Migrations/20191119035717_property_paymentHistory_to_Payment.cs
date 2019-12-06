using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Webnovel.Migrations
{
    public partial class property_paymentHistory_to_Payment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentHistoryId",
                table: "PaidChapterHistories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PaidChapterHistories_PaymentHistoryId",
                table: "PaidChapterHistories",
                column: "PaymentHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaidChapterHistories_PaymentHistories_PaymentHistoryId",
                table: "PaidChapterHistories",
                column: "PaymentHistoryId",
                principalTable: "PaymentHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaidChapterHistories_PaymentHistories_PaymentHistoryId",
                table: "PaidChapterHistories");

            migrationBuilder.DropIndex(
                name: "IX_PaidChapterHistories_PaymentHistoryId",
                table: "PaidChapterHistories");

            migrationBuilder.DropColumn(
                name: "PaymentHistoryId",
                table: "PaidChapterHistories");
        }
    }
}
