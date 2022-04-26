using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace datingapp1.Persistence.EF.Migrations
{
    public partial class genderTest2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "AppUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AppUsers");
        }
    }
}
