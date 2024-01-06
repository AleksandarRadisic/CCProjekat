using System;

namespace CityLibrary.Domain.Model
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Writer { get; set; }
        public string ISBN { get; set; }
        public int AmountAvailable { get; set; }
    }
}
