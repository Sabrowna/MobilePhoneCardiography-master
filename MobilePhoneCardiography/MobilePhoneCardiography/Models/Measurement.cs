using System;
using System.Collections.Generic;

namespace MobilePhoneCardiography.Models
{
    public class Measurement
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public List<short> SoundSamples{ get; set; }
        public long AmountOfSamples { get; set; }
        public int ProbabilityPercentage { get; set; }
        public int PatientID { get; set; }
        public int HealthProffesionalID { get; set; }
        public int PlacementOfDevice { get; set; }
    }
}