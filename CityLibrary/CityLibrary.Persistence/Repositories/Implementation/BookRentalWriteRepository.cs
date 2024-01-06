using CityLibrary.Domain.Model;
using CityLibrary.Domain.PersistenceInterfaces;
using CityLibrary.Persistence.EfStructures;
using CityLibrary.Persistence.Repositories.Base.Implementation;

namespace CityLibrary.Persistence.Repositories.Implementation
{
    public class BookRentalWriteRepository : BaseWriteRepository<BookRental>, IBookRentalWriteRepository
    {
        public BookRentalWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
