using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityLibrary.Domain.Model;

namespace CityLibrary.Domain.Services.Interface
{
    public interface IBookService
    {
        public IEnumerable<Book> GetAll();
    }
}
