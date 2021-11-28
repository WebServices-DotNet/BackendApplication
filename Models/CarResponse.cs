namespace CarFleetManager.Models
{
    public class CarResponse
    {
        public CarResponse(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}