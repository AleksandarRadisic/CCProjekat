using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityLibrary.Domain.Exceptions;
using CityLibrary.Domain.Model;
using CityLibrary.Domain.PersistenceInterfaces;
using CityLibrary.Domain.Services.Interface;

namespace CityLibrary.Domain.Services.Implementation
{
    public class BookRentalService : IBookRentalService
    {
        private readonly IBookReadRepository _bookReadRepository;
        private readonly IBookWriteRepository _bookWriteRepository;
        private readonly IBookRentalReadRepository _bookRentalReadRepository;
        private readonly IBookRentalWriteRepository _bookRentalWriteRepository;

        public BookRentalService(IBookReadRepository bookReadRepository, IBookWriteRepository bookWriteRepository, IBookRentalReadRepository bookRentalReadRepository, IBookRentalWriteRepository bookRentalWriteRepository)
        {
            _bookReadRepository = bookReadRepository;
            _bookWriteRepository = bookWriteRepository;
            _bookRentalReadRepository = bookRentalReadRepository;
            _bookRentalWriteRepository = bookRentalWriteRepository;
        }

        public void RentBook(Book book, int memberNumber)
        {
            //pozvati centralnu u vezi membera

            Book fromRepo = _bookReadRepository.GetByIsbn(book.ISBN);
            if (fromRepo == null) throw new NotFoundException("Book not found");
            if (fromRepo.AmountAvailable == 0) throw new BookNotAvailableException();
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
            //pozvati centralnu u vezi membera

            BookRental rental = _bookRentalReadRepository.GetByIsbnAndMemberNumber(isbn, memberNumber);
            if (rental == null) throw new NotFoundException("Book Rental not found");
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
