namespace CarFleetManager.Models
{
    public class StatisticsResponse
    {

        public void Accel(double last, double mean)
        {
            LastAccel = last;
            MeanAccel = mean;
        }
        
        public void Speed(double last, double mean)
        {
            LastSpeed = last;
            MeanSpeed = mean;
        }
        
        public void Engine(double last, double mean)
        {
            LastEngine = last;
            MeanEngine = mean;
        }
        
        public void Temperature(double last, double mean)
        {
            LastTemperature = last;
            MeanTemperature = mean;
        }

        public double LastAccel { get; set; }
        public double MeanAccel { get; set; }
        
        public double LastSpeed { get; set; }
        public double MeanSpeed { get; set; }
        
        public double LastTemperature { get; set; }
        public double MeanTemperature { get; set; }
        
        public double LastEngine { get; set; }
        public double MeanEngine { get; set; }
    }
}