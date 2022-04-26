using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace datingapp1.Persistence.EF.Migrations
{
    public partial class genderTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AppUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AppUsers",
                type: "text",
                nullable: true);
        }
    }
}
