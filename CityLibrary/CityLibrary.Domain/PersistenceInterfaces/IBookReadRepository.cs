using System;
using System.Collections;
using System.Collections.Generic;
using CityLibrary.Domain.Model;
using CityLibrary.Domain.PersistenceInterfaces.Base;

namespace CityLibrary.Domain.PersistenceInterfaces
{
    public interface IBookReadRepository : IBaseReadRepository<Guid, Book>
    {
        public Book GetByIsbn(string isbn);
        public IEnumerable<Book> GetAll();
    }
}
