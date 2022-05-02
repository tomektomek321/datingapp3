using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace datingapp1.Persistence.EF.Migrations
{
    public partial class LikeUser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLike_AppUsers_LikedUserId",
                table: "UserLike");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLike_AppUsers_SourceUserId",
                table: "UserLike");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLike",
                table: "UserLike");

            migrationBuilder.RenameTable(
                name: "UserLike",
                newName: "UserLikes");

            migrationBuilder.RenameIndex(
                name: "IX_UserLike_LikedUserId",
                table: "UserLikes",
                newName: "IX_UserLikes_LikedUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLikes",
                table: "UserLikes",
                columns: new[] { "SourceUserId", "LikedUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikes_AppUsers_LikedUserId",
                table: "UserLikes",
                column: "LikedUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikes_AppUsers_SourceUserId",
                table: "UserLikes",
                column: "SourceUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLikes_AppUsers_LikedUserId",
                table: "UserLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLikes_AppUsers_SourceUserId",
                table: "UserLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLikes",
                table: "UserLikes");

            migrationBuilder.RenameTable(
                name: "UserLikes",
                newName: "UserLike");

            migrationBuilder.RenameIndex(
                name: "IX_UserLikes_LikedUserId",
                table: "UserLike",
                newName: "IX_UserLike_LikedUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLike",
                table: "UserLike",
                columns: new[] { "SourceUserId", "LikedUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserLike_AppUsers_LikedUserId",
                table: "UserLike",
                column: "LikedUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLike_AppUsers_SourceUserId",
                table: "UserLike",
                column: "SourceUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
