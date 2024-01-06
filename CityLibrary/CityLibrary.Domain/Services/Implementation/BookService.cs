using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityLibrary.Domain.Model;
using CityLibrary.Domain.PersistenceInterfaces;
using CityLibrary.Domain.Services.Interface;

namespace CityLibrary.Domain.Services.Implementation
{
    public class BookService : IBookService
    {
        private readonly IBookReadRepository _bookReadRepository;

        public BookService(IBookReadRepository bookReadRepository)
        {
            _bookReadRepository = bookReadRepository;
        }
        public IEnumerable<Book> GetAll()
        {
            return _bookReadRepository.GetAll().ToList();
        }
    }
}
