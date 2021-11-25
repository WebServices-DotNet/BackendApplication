namespace CarFleetManager.Models
{
    public class CarFleetDatabaseSettings : ICarFleetDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ICarFleetDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}