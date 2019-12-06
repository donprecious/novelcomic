
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Webnovel.Migrations
{
    public partial class correctPaymentHistoryProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.DropForeignKey(
                name: "FK_CowriesPurchasedHistories_PaymentHistories_PaymentHistoryId",
                table: "CowriesPurchasedHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_PaidChapterHistories_PaymentHistories_PaymentHistoryId",
                table: "PaidChapterHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionPaidHistories_PaymentHistories_PaymentHistoryId",
                table: "SubscriptionPaidHistories");

            migrationBuilder.DropIndex(
                name: "IX_PaidChapterHistories_PaymentHistoryId",
                table: "PaidChapterHistories");
            migrationBuilder.DropIndex(
                name: "IX_CowriesPurchasedHistories_PaymentHistoryId",
                table: "CowriesPurchasedHistories");
            migrationBuilder.DropIndex(
                name: "IX_SubscriptionPaidHistories_PaymentHistoryId",
                table: "SubscriptionPaidHistories");
         
            //migrationBuilder.CreateIndex(
            //    name: "IX_CowriesPurchasedHistories_PaymentHistoryId",
            //    table: "CowriesPurchasedHistories",
            //    column: "PaymentHistoryId");

            migrationBuilder.DropPrimaryKey("PK_PaymentHistories", "PaymentHistories");
            migrationBuilder.DropColumn(
                name: "Id",
                table: "PaymentHistories");

        
            migrationBuilder.AddColumn<string>("Id", "PaymentHistories", nullable: false);
            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentHistories",
                table: "PaymentHistories",
                column: "Id"
            );
            //migrationBuilder.DropColumn(
            //    name: "PaymentHistoryId",
            //    table: "PaidChapterHistories");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentHistoryId",
                table: "SubscriptionPaidHistories",
                nullable: true,
                oldClrType: typeof(int));

            //migrationBuilder.AlterColumn<string>(
            //    name: "Id",
            //    table: "PaymentHistories",
            //    nullable: false,
            //    oldClrType: typeof(int))
            //    .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalDetail",
                table: "PaymentHistories",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TxtDateTime",
                table: "PaymentHistories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "PaymentHistoryId",
                table: "CowriesPurchasedHistories",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_CowriesPurchasedHistories_PaymentHistories_PaymentHistoryId",
                table: "CowriesPurchasedHistories",
                column: "PaymentHistoryId",
                principalTable: "PaymentHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionPaidHistories_PaymentHistories_PaymentHistoryId",
                table: "SubscriptionPaidHistories",
                column: "PaymentHistoryId",
                principalTable: "PaymentHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.CreateIndex(
                name: "IX_CowriesPurchasedHistories_PaymentHistoryId",
                table: "CowriesPurchasedHistories",
                column: "PaymentHistoryId");
            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionPaidHistories_PaymentHistoryId",
                table: "SubscriptionPaidHistories",
                column: "PaymentHistoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CowriesPurchasedHistories_PaymentHistories_PaymentHistoryId",
                table: "CowriesPurchasedHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionPaidHistories_PaymentHistories_PaymentHistoryId",
                table: "SubscriptionPaidHistories");

            migrationBuilder.DropColumn(
                name: "AdditionalDetail",
                table: "PaymentHistories");

            migrationBuilder.DropColumn(
                name: "TxtDateTime",
                table: "PaymentHistories");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentHistoryId",
                table: "SubscriptionPaidHistories",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PaymentHistories",
                nullable: false,
                oldClrType: typeof(string))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "PaymentHistoryId",
                table: "PaidChapterHistories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PaymentHistoryId",
                table: "CowriesPurchasedHistories",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaidChapterHistories_PaymentHistoryId",
                table: "PaidChapterHistories",
                column: "PaymentHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CowriesPurchasedHistories_PaymentHistories_PaymentHistoryId",
                table: "CowriesPurchasedHistories",
                column: "PaymentHistoryId",
                principalTable: "PaymentHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaidChapterHistories_PaymentHistories_PaymentHistoryId",
                table: "PaidChapterHistories",
                column: "PaymentHistoryId",
                principalTable: "PaymentHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionPaidHistories_PaymentHistories_PaymentHistoryId",
                table: "SubscriptionPaidHistories",
                column: "PaymentHistoryId",
                principalTable: "PaymentHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
