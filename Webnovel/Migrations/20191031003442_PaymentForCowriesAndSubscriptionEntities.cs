using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Webnovel.Migrations
{
    public partial class PaymentForCowriesAndSubscriptionEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCowrieses_AspNetUsers_UserId1",
                table: "UserCowrieses");

            migrationBuilder.DropIndex(
                name: "IX_UserCowrieses_UserId1",
                table: "UserCowrieses");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserCowrieses");
            migrationBuilder.DropPrimaryKey("PK_UserCowrieses", "UserCowrieses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserCowrieses");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserCowrieses",
                nullable: false
                );
            migrationBuilder.AddPrimaryKey(
             name: "pk_UserCowries",
              table: "UserCowrieses",
             column: "UserId"
            );
            migrationBuilder.AddForeignKey(
                name: "FK_UserCowries_User",
                table: "UserCowrieses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
            );
            //migrationBuilder.AlterColumn<string>(
            //    name: "UserId",
            //    table: "UserCowrieses",
            //    nullable: false,
            //    oldClrType: typeof(int))
            //    .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
            //migrationBuilder.AddColumn<string>(
            //    "UserId",
            //      table: "UserCowrieses",

            //    defaultValue: 0
            //    );

            migrationBuilder.CreateTable(
                name: "CowriesPurchasedHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatePurchased = table.Column<DateTime>(nullable: false),
                    PaymentHistoryId = table.Column<int>(nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CowriesPurchasedHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CowriesPurchasedHistories_PaymentHistories_PaymentHistoryId",
                        column: x => x.PaymentHistoryId,
                        principalTable: "PaymentHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CowriesPurchasedHistories_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionPaidHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<double>(nullable: false),
                    DatePurchased = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false),
                    PaymentHistoryId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionPaidHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionPaidHistories_PaymentHistories_PaymentHistoryId",
                        column: x => x.PaymentHistoryId,
                        principalTable: "PaymentHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubscriptionPaidHistories_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserSubscriptions",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSubscriptions", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserSubscriptions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CowriesPurchasedHistories_PaymentHistoryId",
                table: "CowriesPurchasedHistories",
                column: "PaymentHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CowriesPurchasedHistories_UserId",
                table: "CowriesPurchasedHistories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionPaidHistories_PaymentHistoryId",
                table: "SubscriptionPaidHistories",
                column: "PaymentHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionPaidHistories_UserId",
                table: "SubscriptionPaidHistories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCowrieses_AspNetUsers_UserId",
                table: "UserCowrieses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCowrieses_AspNetUsers_UserId",
                table: "UserCowrieses");

            migrationBuilder.DropTable(
                name: "CowriesPurchasedHistories");

            migrationBuilder.DropTable(
                name: "SubscriptionPaidHistories");

            migrationBuilder.DropTable(
                name: "UserSubscriptions");
            migrationBuilder.DropColumn(name: "UserId",
                table: "UserCowrieses");
            //migrationBuilder.AlterColumn<int>(
            //    name: "UserId",
            //    table: "UserCowrieses",
            //    nullable: false,
            //    oldClrType: typeof(string))
            //    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserCowrieses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserCowrieses_UserId1",
                table: "UserCowrieses",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCowrieses_AspNetUsers_UserId1",
                table: "UserCowrieses",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
