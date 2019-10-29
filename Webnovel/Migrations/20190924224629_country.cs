using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Webnovel.Migrations
{
    public partial class country : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Referrals");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Referrals",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    alpha2Code = table.Column<string>(nullable: true),
                    alpha3Code = table.Column<string>(nullable: true),
                    area = table.Column<double>(nullable: false),
                    capital = table.Column<string>(nullable: true),
                    demonym = table.Column<string>(nullable: true),
                    gini = table.Column<double>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    nativeName = table.Column<string>(nullable: true),
                    numericCode = table.Column<string>(nullable: true),
                    population = table.Column<int>(nullable: false),
                    region = table.Column<string>(nullable: true),
                    subregion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Referrals_CountryId",
                table: "Referrals",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Referrals_Countries_CountryId",
                table: "Referrals",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Referrals_Countries_CountryId",
                table: "Referrals");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Referrals_CountryId",
                table: "Referrals");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Referrals");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Referrals",
                nullable: true);
        }
    }
}
