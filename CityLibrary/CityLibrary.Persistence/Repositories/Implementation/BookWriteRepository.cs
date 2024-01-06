using CityLibrary.Domain.Model;
using CityLibrary.Domain.PersistenceInterfaces;
using CityLibrary.Persistence.EfStructures;
using CityLibrary.Persistence.Repositories.Base.Implementation;

namespace CityLibrary.Persistence.Repositories.Implementation
{
    public class BookWriteRepository : BaseWriteRepository<Book>, IBookWriteRepository
    {
        public BookWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
