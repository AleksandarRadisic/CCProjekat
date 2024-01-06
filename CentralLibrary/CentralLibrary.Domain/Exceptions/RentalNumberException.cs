using System;

namespace CentralLibrary.Domain.Exceptions
{
    public class RentalNumberException : Exception
    {
        public RentalNumberException(string message) : base(message) { }
    }
}
