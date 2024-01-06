using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace CentralLibrary.Domain.EnvironmentConfig
{
    public class EnvironmentConfig : IEnvironmentConfig
    {
        public string DatabaseConnectionString { get; }

        public EnvironmentConfig()
        {
            DatabaseConnectionString = GetEnvironmentVariable("CENTRAL_LIBRARY_DB_CONNECTION_STRING", "null");
        }

        private string GetEnvironmentVariable(string variable, string defaultValue)
        {
            return Environment.GetEnvironmentVariable(variable) ?? defaultValue;
        }
    }
}
