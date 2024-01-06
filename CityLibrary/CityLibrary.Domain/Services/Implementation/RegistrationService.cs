using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CityLibrary.Domain.EnvironmentConfig;
using CityLibrary.Domain.Exceptions;
using CityLibrary.Domain.Model;
using CityLibrary.Domain.Services.Interface;
using CityLibrary.Domain.Utility;

namespace CityLibrary.Domain.Services.Implementation
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IEnvironmentConfig _environmentConfig;
        private readonly IHttpSender _httpSender;
        public RegistrationService(IEnvironmentConfig environmentConfig, IHttpSender httpSender)
        {
            _environmentConfig = environmentConfig;
            _httpSender = httpSender;
        }


        public string RegisterMember(Member newMember)
        {
            var response = _httpSender.Post("http://" + _environmentConfig.CentralLibraryUrl + "/api/Registration", newMember).Result;
            if (!response.IsSuccessStatusCode)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.NotFound: throw new NotFoundException(response.Content.ReadAsStringAsync().Result);
                    case HttpStatusCode.Conflict: throw new ConflictException(response.Content.ReadAsStringAsync().Result);
                    default: throw new Exception(response.Content.ReadAsStringAsync().Result);
                }
            }
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
