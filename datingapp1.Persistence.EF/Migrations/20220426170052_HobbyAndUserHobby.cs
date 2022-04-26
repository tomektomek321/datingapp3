using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace datingapp1.Persistence.EF.Migrations
{
    public partial class HobbyAndUserHobby : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_Cities_CityId",
                table: "AppUser");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_Countries_CountryId",
                table: "AppUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUser",
                table: "AppUser");

            migrationBuilder.RenameTable(
                name: "AppUser",
                newName: "AppUsers");

            migrationBuilder.RenameIndex(
                name: "IX_AppUser_CountryId",
                table: "AppUsers",
                newName: "IX_AppUsers_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_AppUser_CityId",
                table: "AppUsers",
                newName: "IX_AppUsers_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUsers",
                table: "AppUsers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Hobbies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserHobbies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppUserId = table.Column<int>(type: "integer", nullable: false),
                    HobbyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHobbies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserHobbies_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserHobbies_Hobbies_HobbyId",
                        column: x => x.HobbyId,
                        principalTable: "Hobbies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserHobbies_AppUserId",
                table: "UserHobbies",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHobbies_HobbyId",
                table: "UserHobbies",
                column: "HobbyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_Cities_CityId",
                table: "AppUsers",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_Countries_CountryId",
                table: "AppUsers",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Cities_CityId",
                table: "AppUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_Countries_CountryId",
                table: "AppUsers");

            migrationBuilder.DropTable(
                name: "UserHobbies");

            migrationBuilder.DropTable(
                name: "Hobbies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUsers",
                table: "AppUsers");

            migrationBuilder.RenameTable(
                name: "AppUsers",
                newName: "AppUser");

            migrationBuilder.RenameIndex(
                name: "IX_AppUsers_CountryId",
                table: "AppUser",
                newName: "IX_AppUser_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_AppUsers_CityId",
                table: "AppUser",
                newName: "IX_AppUser_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUser",
                table: "AppUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUser_Cities_CityId",
                table: "AppUser",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUser_Countries_CountryId",
                table: "AppUser",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");
        }
    }
}
