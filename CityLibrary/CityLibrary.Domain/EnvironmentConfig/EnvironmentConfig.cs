using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace CityLibrary.Domain.EnvironmentConfig
{
    public class EnvironmentConfig : IEnvironmentConfig
    {
        public string CityName { get; }
        public string CentralLibraryUrl { get; }
        public string DatabaseConnectionString { get; }

        public EnvironmentConfig()
        {
            CityName = GetEnvironmentVariable("CITY_NAME", "Beograd");
            CentralLibraryUrl = GetEnvironmentVariable("CENTRAL_LIBRARY_URL", "localhost:5000");
            DatabaseConnectionString = GetEnvironmentVariable("CITY_LIBRARY_DB_CONNECTION_STRING", "null");
        }

        private string GetEnvironmentVariable(string variable, string defaultValue)
        {
            return Environment.GetEnvironmentVariable(variable) ?? defaultValue;
        }
    }
}
