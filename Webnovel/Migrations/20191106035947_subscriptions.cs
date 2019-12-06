using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Webnovel.Migrations
{
    public partial class subscriptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubscriptionId",
                table: "UserSubscriptions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubscriptionId",
                table: "SubscriptionPaidHistories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<double>(nullable: false),
                    Days = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Preference = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSubscriptions_SubscriptionId",
                table: "UserSubscriptions",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionPaidHistories_SubscriptionId",
                table: "SubscriptionPaidHistories",
                column: "SubscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionPaidHistories_Subscriptions_SubscriptionId",
                table: "SubscriptionPaidHistories",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSubscriptions_Subscriptions_SubscriptionId",
                table: "UserSubscriptions",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionPaidHistories_Subscriptions_SubscriptionId",
                table: "SubscriptionPaidHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSubscriptions_Subscriptions_SubscriptionId",
                table: "UserSubscriptions");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_UserSubscriptions_SubscriptionId",
                table: "UserSubscriptions");

            migrationBuilder.DropIndex(
                name: "IX_SubscriptionPaidHistories_SubscriptionId",
                table: "SubscriptionPaidHistories");

            migrationBuilder.DropColumn(
                name: "SubscriptionId",
                table: "UserSubscriptions");

            migrationBuilder.DropColumn(
                name: "SubscriptionId",
                table: "SubscriptionPaidHistories");
        }
    }
}
