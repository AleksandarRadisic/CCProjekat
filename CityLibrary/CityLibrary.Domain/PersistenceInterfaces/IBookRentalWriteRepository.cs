using CityLibrary.Domain.Model;
using CityLibrary.Domain.PersistenceInterfaces.Base;

namespace CityLibrary.Domain.PersistenceInterfaces
{
    public interface IBookRentalWriteRepository : IBaseWriteRepository<BookRental>
    {
    }
}
