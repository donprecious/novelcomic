using Microsoft.EntityFrameworkCore.Migrations;

namespace Webnovel.Migrations
{
    public partial class addedHasEdited_Birth_Country : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasEditedBirthDate",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasEditedCountry",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasEditedBirthDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HasEditedCountry",
                table: "AspNetUsers");
        }
    }
}
