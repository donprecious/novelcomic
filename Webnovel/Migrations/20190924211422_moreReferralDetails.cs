using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Webnovel.Migrations
{
    public partial class moreReferralDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdditonalInformation",
                table: "Referrals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Referrals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InformationFrom",
                table: "Referrals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MinimumReferral",
                table: "Referrals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Occupation",
                table: "Referrals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProgramType",
                table: "Referrals",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditonalInformation",
                table: "Referrals");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Referrals");

            migrationBuilder.DropColumn(
                name: "InformationFrom",
                table: "Referrals");

            migrationBuilder.DropColumn(
                name: "MinimumReferral",
                table: "Referrals");

            migrationBuilder.DropColumn(
                name: "Occupation",
                table: "Referrals");

            migrationBuilder.DropColumn(
                name: "ProgramType",
                table: "Referrals");
        }
    }
}
