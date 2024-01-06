using CityLibrary.Domain.Model;
using CityLibrary.Domain.PersistenceInterfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLibrary.Domain.PersistenceInterfaces
{
    public interface IBookRentalReadRepository : IBaseReadRepository<Guid, BookRental>
    {
        public BookRental GetByIsbnAndMemberNumber(string isbn, int memberNumber);
        public IEnumerable<BookRental> GetAll();
    }
}
