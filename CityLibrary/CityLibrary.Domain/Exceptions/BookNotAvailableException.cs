using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLibrary.Domain.Exceptions
{
    public class BookNotAvailableException : Exception
    {
        public BookNotAvailableException() : base("Book is not available at the current time") { }
    }
}
