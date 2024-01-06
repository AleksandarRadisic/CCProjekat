using CentralLibrary.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CentralLibrary.Persistence.EfStructures
{
    public class AppDbContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
    }
}
