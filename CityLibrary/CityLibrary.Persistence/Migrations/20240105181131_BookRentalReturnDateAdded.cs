using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CityLibrary.Persistence.Migrations
{
    public partial class BookRentalReturnDateAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDate",
                table: "BookRentals",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "BookRentals");
        }
    }
}
