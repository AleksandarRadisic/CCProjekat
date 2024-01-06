using System;
using System.Collections.Generic;
using System.Linq;
using CityLibrary.Domain.Model;
using CityLibrary.Domain.PersistenceInterfaces;
using CityLibrary.Persistence.EfStructures;
using CityLibrary.Persistence.Repositories.Base.Implementation;
using Microsoft.EntityFrameworkCore;

namespace CityLibrary.Persistence.Repositories.Implementation
{
    public class BookRentalReadRepository : BaseReadRepository<Guid, BookRental>, IBookRentalReadRepository
    {
        public BookRentalReadRepository(AppDbContext context) : base(context)
        {
        }

        public BookRental GetActiveByIsbnAndMemberNumber(string isbn, int memberNumber)
        {
            return GetSet().Include(br => br.Book)
                .FirstOrDefault(br => br.Book.ISBN == isbn && br.MemberNumber == memberNumber && br.ReturnDate == DateTime.MinValue);
        }

        public IEnumerable<BookRental> GetAll()
        {
            return GetSet().Include(br => br.Book).ToList();
        }
    }
}
