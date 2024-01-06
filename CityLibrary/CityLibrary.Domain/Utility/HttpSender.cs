using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CityLibrary.Domain.Exceptions;
using Newtonsoft.Json;

namespace CityLibrary.Domain.Utility
{
    public class HttpSender : IHttpSender
    {
        public async Task<HttpResponseMessage> Post(string url, object content)
        {
            string jsonBody = JsonConvert.SerializeObject(content);
            using (HttpClient client = new HttpClient())
            {
                StringContent body = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                return await client.PostAsync(url, body);
            }
        }

        public async Task<HttpResponseMessage> Put(string url, object content)
        {
            string jsonBody = JsonConvert.SerializeObject(content);
            using (HttpClient client = new HttpClient())
            {
                StringContent body = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                return await client.PutAsync(url, body);
            }
        }
    }
}
