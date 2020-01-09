using Microsoft.EntityFrameworkCore.Migrations;

namespace Webnovel.Migrations
{
    public partial class comicRatingType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RatingTypeId",
                table: "ComicRatings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ComicRatings_RatingTypeId",
                table: "ComicRatings",
                column: "RatingTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComicRatings_RatingTypes_RatingTypeId",
                table: "ComicRatings",
                column: "RatingTypeId",
                principalTable: "RatingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComicRatings_RatingTypes_RatingTypeId",
                table: "ComicRatings");

            migrationBuilder.DropIndex(
                name: "IX_ComicRatings_RatingTypeId",
                table: "ComicRatings");

            migrationBuilder.DropColumn(
                name: "RatingTypeId",
                table: "ComicRatings");
        }
    }
}
