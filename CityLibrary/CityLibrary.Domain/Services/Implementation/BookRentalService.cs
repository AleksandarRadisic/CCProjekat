using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CityLibrary.Domain.EnvironmentConfig;
using CityLibrary.Domain.Exceptions;
using CityLibrary.Domain.Model;
using CityLibrary.Domain.PersistenceInterfaces;
using CityLibrary.Domain.Services.Interface;
using CityLibrary.Domain.Utility;

namespace CityLibrary.Domain.Services.Implementation
{
    public class BookRentalService : IBookRentalService
    {
        private readonly IBookReadRepository _bookReadRepository;
        private readonly IBookWriteRepository _bookWriteRepository;
        private readonly IBookRentalReadRepository _bookRentalReadRepository;
        private readonly IBookRentalWriteRepository _bookRentalWriteRepository;
        private readonly IEnvironmentConfig _environmentConfig;
        private readonly IHttpSender _httpSender;

        public BookRentalService(IBookReadRepository bookReadRepository, IBookWriteRepository bookWriteRepository, IBookRentalReadRepository bookRentalReadRepository, IBookRentalWriteRepository bookRentalWriteRepository, IHttpSender httpSender, IEnvironmentConfig environmentConfig)
        {
            _bookReadRepository = bookReadRepository;
            _bookWriteRepository = bookWriteRepository;
            _bookRentalReadRepository = bookRentalReadRepository;
            _bookRentalWriteRepository = bookRentalWriteRepository;
            _httpSender = httpSender;
            _environmentConfig = environmentConfig;
        }

        public void RentBook(Book book, int memberNumber)
        {
            var bookRentalFromRepo = _bookRentalReadRepository.GetActiveByIsbnAndMemberNumber(book.ISBN, memberNumber);
            if (bookRentalFromRepo != null) throw new ConflictException("Book already rented by that member"); 
            var response = _httpSender.Put("http://" + _environmentConfig.CentralLibraryUrl + "/api/Member/Rent",
                new CentralLibraryRentalData { MemberNumber = memberNumber }).Result;

            if (!response.IsSuccessStatusCode)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.Conflict: throw new ConflictException(response.Content.ReadAsStringAsync().Result);
                    case HttpStatusCode.NotFound: throw new NotFoundException(response.Content.ReadAsStringAsync().Result);
                    default: throw new Exception(response.Content.ReadAsStringAsync().Result);
                }
            }

            Book fromRepo = _bookReadRepository.GetByIsbn(book.ISBN);
            if (fromRepo == null) throw new NotFoundException("Book not found");
            if (fromRepo.AmountAvailable == 0) throw new ConflictException("Book is not available at the current time");
            fromRepo.AmountAvailable -= 1;
            BookRental newRent = new BookRental
            {
                BookId = fromRepo.Id,
                Book = fromRepo,
                MemberNumber = memberNumber,
                RentalDate = DateTime.Now,
                ReturnDate = DateTime.MinValue
            };
            _bookRentalWriteRepository.Add(newRent);
        }

        public void ReturnBook(string isbn, int memberNumber)
        {
            BookRental rental = _bookRentalReadRepository.GetActiveByIsbnAndMemberNumber(isbn, memberNumber);
            if (rental == null) throw new NotFoundException("Book Rental not found");
            var response = _httpSender.Put("http://" + _environmentConfig.CentralLibraryUrl + "/api/Member/Return",
                new CentralLibraryRentalData { MemberNumber = memberNumber }).Result;
            if (!response.IsSuccessStatusCode)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.NotFound: throw new NotFoundException(response.Content.ReadAsStringAsync().Result);
                    case HttpStatusCode.Conflict: throw new ConflictException(response.Content.ReadAsStringAsync().Result);
                    default: throw new Exception(response.Content.ReadAsStringAsync().Result);
                }
            }
            rental.Book.AmountAvailable += 1;
            rental.ReturnDate = DateTime.Now;
            _bookRentalWriteRepository.Update(rental);
        }

        public IEnumerable<BookRental> GetAll()
        {
            return _bookRentalReadRepository.GetAll();
        }
    }
}
