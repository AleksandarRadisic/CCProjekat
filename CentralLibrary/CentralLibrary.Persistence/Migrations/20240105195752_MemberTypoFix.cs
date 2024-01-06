using Microsoft.EntityFrameworkCore.Migrations;

namespace CentralLibrary.Persistence.Migrations
{
    public partial class MemberTypoFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Members",
                newName: "Address");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Members",
                newName: "Adress");
        }
    }
}
