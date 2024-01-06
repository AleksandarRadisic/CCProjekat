using System;
using System.Collections.Generic;
using System.Linq;
using CityLibrary.Domain.Model;
using CityLibrary.Domain.PersistenceInterfaces;
using CityLibrary.Persistence.EfStructures;
using CityLibrary.Persistence.Repositories.Base.Implementation;
using Microsoft.EntityFrameworkCore;

namespace JobCandidates.Persistence.Repositories.Implementation
{
    public class BookReadRepository : BaseReadRepository<Guid, Book>, IBookReadRepository
    {
        public BookReadRepository(AppDbContext context) : base(context)
        {
        }

        public Book GetByIsbn(string isbn)
        {
            return GetSet().FirstOrDefault(b => b.ISBN == isbn);
        }

        public IEnumerable<Book> GetAll()
        {
            return GetSet().ToList();
        }
    }
}
