using System;

namespace CarFleetManager.Models
{
    public class SampleDataResponse
    {
        public SampleDataResponse(double value, DateTime createDate)
        {
            Value = value;
            CreateDate = createDate;
        }
        public double Value { get; set; }
        public DateTime CreateDate { get; set; }
    }
}