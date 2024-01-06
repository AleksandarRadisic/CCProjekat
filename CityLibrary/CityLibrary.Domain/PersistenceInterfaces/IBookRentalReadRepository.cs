using CityLibrary.Domain.Model;
using CityLibrary.Domain.PersistenceInterfaces.Base;
using System;
using System.Collections.Generic;

namespace CityLibrary.Domain.PersistenceInterfaces
{
    public interface IBookRentalReadRepository : IBaseReadRepository<Guid, BookRental>
    {
        public BookRental GetActiveByIsbnAndMemberNumber(string isbn, int memberNumber);
        public IEnumerable<BookRental> GetAll();
    }
}
