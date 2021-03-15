using MobilePhoneCardiography.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobilePhoneCardiography.Services
{
    public class MockDataStoreMeasurement : IDataStore<Measurement>
    {
        readonly List<Measurement> measurements;

        public MockDataStoreMeasurement()
        {
            measurements = new List<Measurement>()
            {
                new Measurement { Id = 1, SoundSamples = new List<short>(){1,2,3,4,5,6}, StartTime = DateTime.Now, 
                    AmountOfSamples = 6, ProbabilityPercentage = 85, PatientID = 1, HealthProffesionalID = 1, PlacementOfDevice = 1},
                new Measurement { Id = 2, SoundSamples = new List<short>(){2,2,3,4,5,6}, StartTime = DateTime.Now, 
                    AmountOfSamples = 6, ProbabilityPercentage = 85, PatientID = 1, HealthProffesionalID = 1, PlacementOfDevice = 1},
                new Measurement { Id = 3, SoundSamples = new List<short>(){3,3,3,4,5,6}, StartTime = DateTime.Now, 
                    AmountOfSamples = 6, ProbabilityPercentage = 85, PatientID = 1, HealthProffesionalID = 1, PlacementOfDevice = 1},

            };
        }

        public async Task<bool> AddItemAsync(Measurement measurement)
        {
            measurements.Add(measurement);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Measurement measurement)
        {
            var oldMeasurement = measurements.Where((Measurement arg) => arg.Id == measurement.Id).FirstOrDefault();
            measurements.Remove(oldMeasurement);
            measurements.Add(measurement);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(long id)
        {
            var oldMeasurement = measurements.Where((Measurement arg) => arg.Id == id).FirstOrDefault();
            measurements.Remove(oldMeasurement);

            return await Task.FromResult(true);
        }

        public async Task<Measurement> GetItemAsync(long id)
        {
            return await Task.FromResult(measurements.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Measurement>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(measurements);
        }
    }
}