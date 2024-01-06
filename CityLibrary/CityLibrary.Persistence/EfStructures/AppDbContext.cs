using CityLibrary.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CityLibrary.Persistence.EfStructures
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookRental> BookRentals { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
    }
}
