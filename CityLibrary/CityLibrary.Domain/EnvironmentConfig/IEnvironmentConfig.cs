namespace CityLibrary.Domain.EnvironmentConfig
{
    public interface IEnvironmentConfig
    {
        string CityName { get; }
        string CentralLibraryUrl { get; }
        string DatabaseConnectionString { get; }
    }
}
