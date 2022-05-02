using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace datingapp1.Persistence.EF.Migrations
{
    public partial class UserCreatedUpdated2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "AppUsers",
                type: "timestamp with time zone",
                nullable: true);
            migrationBuilder.AddColumn<DateTime>(
                name: "LastActive",
                table: "AppUsers",
                type: "timestamp with time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "AppUsers");
            migrationBuilder.DropColumn(
                name: "LastActive",
                table: "AppUsers");
        }
    }
}
