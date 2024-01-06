using Microsoft.EntityFrameworkCore.Migrations;

namespace CentralLibrary.Persistence.Migrations
{
    public partial class MemberSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO public." + "\"Members\"" +
                                 "(\"Id\", \"Name\", \"Surname\", \"Address\", \"Jmbg\", \"CurrentRentals\", \"MemberNumber\") VALUES " +
                                 "('46610334-5538-4fc6-850d-d2f0da6b31e8', 'Aleksandar', 'Radisic', 'Zlatne Grede 2', '1234567891033', '0', '1')," +
                                 "('77053a85-f0b5-48cc-8cc9-90964c830654', 'Vanja', 'Padalica', 'Zlatne Grede 3', '1234567891034', '0', '2')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM public.\"Members\"");
        }
    }
}
