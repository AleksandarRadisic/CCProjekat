using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CityLibrary.Domain.Utility
{
    public interface IHttpSender
    {
        public Task<HttpResponseMessage> Post(string url, object content);
        public Task<HttpResponseMessage> Put(string url, object content);
    }
}
