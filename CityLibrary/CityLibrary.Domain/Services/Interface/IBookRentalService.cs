﻿using System.Collections.Generic;
using CityLibrary.Domain.Model;

namespace CityLibrary.Domain.Services.Interface
{
    public interface IBookRentalService
    {
        public void RentBook(Book book, int memberNumber);
        public void ReturnBook(string isbn, int memberNumber);
        public IEnumerable<BookRental> GetAll();
    }
}
