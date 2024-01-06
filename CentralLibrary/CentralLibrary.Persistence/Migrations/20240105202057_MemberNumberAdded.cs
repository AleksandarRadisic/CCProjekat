using Microsoft.EntityFrameworkCore.Migrations;

namespace CentralLibrary.Persistence.Migrations
{
    public partial class MemberNumberAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MemberNumber",
                table: "Members",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemberNumber",
                table: "Members");
        }
    }
}
