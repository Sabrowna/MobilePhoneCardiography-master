using MobilePhoneCardiography.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobilePhoneCardiography.Services
{
    public class MockDataStorePatient : IDataStore<Patient>
    {
        readonly List<Patient> patients;

        public MockDataStorePatient()
        {
            patients = new List<Patient>()
            {
                new Patient{ SocSec = "1234567890", FirstName = "John", LastName= "Doe" },
                new Patient{ SocSec = "2234567890", FirstName = "Jim", LastName= "Smith" }
            };
        }

        public async Task<bool> AddItemAsync(Patient patient)
        {
            patients.Add(patient);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Patient Patient)
        {
            var oldPatient = patients.Where((Patient arg) => arg.SocSec == Patient.SocSec).FirstOrDefault();
            patients.Remove(oldPatient);
            patients.Add(Patient);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(long socSec)
        {
            var oldPatient = patients.Where((Patient arg) => Convert.ToInt64(arg.SocSec) == socSec).FirstOrDefault();
            patients.Remove(oldPatient);

            return await Task.FromResult(true);
        }

        public async Task<Patient> GetItemAsync(long socSec)
        {
            return await Task.FromResult(patients.FirstOrDefault(s => Convert.ToInt64(s.SocSec) == socSec));
        }

        public async Task<IEnumerable<Patient>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(patients);
        }
    }
}