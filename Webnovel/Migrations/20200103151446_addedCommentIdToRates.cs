using Microsoft.EntityFrameworkCore.Migrations;

namespace Webnovel.Migrations
{
    public partial class addedCommentIdToRates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "NovelRatings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "ComicRatings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_NovelRatings_CommentId",
                table: "NovelRatings",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_ComicRatings_CommentId",
                table: "ComicRatings",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComicRatings_1_ComicComments_CommentId",
                table: "ComicRatings",
                column: "CommentId",
                principalTable: "ComicComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_NovelRatings_NovelComments_CommentId",
                table: "NovelRatings",
                column: "CommentId",
                principalTable: "NovelComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComicRatings_ComicComments_CommentId",
                table: "ComicRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_NovelRatings_NovelComments_CommentId",
                table: "NovelRatings");

            migrationBuilder.DropIndex(
                name: "IX_NovelRatings_CommentId",
                table: "NovelRatings");

            migrationBuilder.DropIndex(
                name: "IX_ComicRatings_CommentId",
                table: "ComicRatings");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "NovelRatings");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "ComicRatings");
        }
    }
}
