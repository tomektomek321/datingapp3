using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace datingapp1.Persistence.EF.Migrations
{
    public partial class UserLikeTrueFalse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isLiked",
                table: "UserLikes",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isLiked",
                table: "UserLikes");
        }
    }
}
