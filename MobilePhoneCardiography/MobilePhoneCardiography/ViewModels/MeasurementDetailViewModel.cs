using MobilePhoneCardiography.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobilePhoneCardiography.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class MeasurementDetailViewModel : BaseViewModel
    {
        private int itemId;        
        private List<short> _soundSamples;
        private DateTime _startTime;
        private long _amountOfSamples;
        private int _probabilityPercentage;
        private int _patientID;
        private int _healthProffesionalID;
        private int _placementOfDevice;

        public int Id { get; set; }

        public List<short> SoundSamples
        {
            get => _soundSamples;
            set => SetProperty(ref _soundSamples, value);
        }
        public DateTime StartTime
        {
            get => _startTime;
            set => SetProperty(ref _startTime, value);
        }

        public long AmountOfSamples
        {
            get => _amountOfSamples;
            set => SetProperty(ref _amountOfSamples, value);
        }

        public int ProbabilityPercentage
        {
            get => _probabilityPercentage;
            set => SetProperty(ref _probabilityPercentage, value);
        }

        public int PlacementOfDevice
        {
            get => _placementOfDevice;
            set => SetProperty(ref _placementOfDevice, value);
        }

        public int PatientID
        {
            get => _patientID;
            set => SetProperty(ref _patientID, value);
        }

        public int HealthProffesionalID
        {
            get => _healthProffesionalID;
            set => SetProperty(ref _healthProffesionalID, value);
        }

        public int ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = await DataStoreUserMeasurement.GetItemAsync(itemId);
                Id = item.Id;
                StartTime = item.StartTime;
                SoundSamples = item.SoundSamples;
                AmountOfSamples = item.AmountOfSamples;
                ProbabilityPercentage = item.ProbabilityPercentage;
                PatientID = item.PatientID;
                HealthProffesionalID = item.HealthProffesionalID;
                PlacementOfDevice = item.PlacementOfDevice;

            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
