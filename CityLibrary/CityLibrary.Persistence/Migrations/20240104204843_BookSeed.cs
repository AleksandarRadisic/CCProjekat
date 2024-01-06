using Microsoft.EntityFrameworkCore.Migrations;

namespace CityLibrary.Persistence.Migrations
{
    public partial class BookSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO public." + "\"Books\"" +
                                 "(\"Id\", \"Title\", \"Writer\", \"ISBN\", \"AmountAvailable\") VALUES " +
                                 "('178a2c93-d574-42ed-9dba-343a8b3f1d3a', 'Rat i mir', 'Lav Tolstoj', '9788676743452', '50')," +
                                 "('2075dcae-47f5-464c-aae1-bcf5be339f7e', 'Na Drini Cuprija', 'Ivo Andric', '9788661050930', '20')," +
                                 "('64943aad-9282-49a2-825b-f9a76b83c450', 'Ana Karenjina', 'Lav Tolstoj', '9788652135554', '10')," +
                                 "('71e740de-08f3-4c74-b417-f171d49a55b1', 'Zlocin i kazna', 'Fjodor Dostojevski', '9788663690646', '5')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM public.\"Books\"");
        }
    }
}
