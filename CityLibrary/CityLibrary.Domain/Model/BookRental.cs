﻿using System;

namespace CityLibrary.Domain.Model
{
    public class BookRental
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int MemberNumber { get; set; }
    }
}
