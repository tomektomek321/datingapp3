using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace datingapp1.Persistence.EF.Migrations
{
    public partial class CategoriesForHobbies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HobbiesCategoryId",
                table: "Hobbies",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "HobbiesCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HobbiesCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hobbies_HobbiesCategoryId",
                table: "Hobbies",
                column: "HobbiesCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hobbies_HobbiesCategories_HobbiesCategoryId",
                table: "Hobbies",
                column: "HobbiesCategoryId",
                principalTable: "HobbiesCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hobbies_HobbiesCategories_HobbiesCategoryId",
                table: "Hobbies");

            migrationBuilder.DropTable(
                name: "HobbiesCategories");

            migrationBuilder.DropIndex(
                name: "IX_Hobbies_HobbiesCategoryId",
                table: "Hobbies");

            migrationBuilder.DropColumn(
                name: "HobbiesCategoryId",
                table: "Hobbies");
        }
    }
}
