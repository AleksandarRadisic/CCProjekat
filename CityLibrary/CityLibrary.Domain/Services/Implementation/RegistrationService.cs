using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityLibrary.Domain.EnvironmentConfig;
using CityLibrary.Domain.Model;
using CityLibrary.Domain.Services.Interface;

namespace CityLibrary.Domain.Services.Implementation
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IEnvironmentConfig _environmentConfig;
        public RegistrationService(IEnvironmentConfig environmentConfig)
        {
            _environmentConfig = environmentConfig;
        }


        public void RegisterMember(Member newMember)
        {
            //Pozvati central library da sacuva
        }
    }
}
