using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class AddHobbyDBSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserHobbies_Hobby_HobbyId",
                table: "UserHobbies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hobby",
                table: "Hobby");

            migrationBuilder.RenameTable(
                name: "Hobby",
                newName: "Hobbies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hobbies",
                table: "Hobbies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserHobbies_Hobbies_HobbyId",
                table: "UserHobbies",
                column: "HobbyId",
                principalTable: "Hobbies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserHobbies_Hobbies_HobbyId",
                table: "UserHobbies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hobbies",
                table: "Hobbies");

            migrationBuilder.RenameTable(
                name: "Hobbies",
                newName: "Hobby");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hobby",
                table: "Hobby",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserHobbies_Hobby_HobbyId",
                table: "UserHobbies",
                column: "HobbyId",
                principalTable: "Hobby",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
