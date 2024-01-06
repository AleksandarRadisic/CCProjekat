using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CityLibrary.Persistence.Migrations
{
    public partial class BookAndBookRentalInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RentalDate",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "MemberNumber",
                table: "BookRentals",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemberNumber",
                table: "BookRentals");

            migrationBuilder.AddColumn<DateTime>(
                name: "RentalDate",
                table: "Books",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
