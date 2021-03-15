using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using MobilePhoneCardiography.Models;
using MobilePhoneCardiography.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MobilePhoneCardiography.ViewModels
{
    public class RecordingsViewModel : BaseViewModel
    {
        private Measurement _selectedMeasurement;

        public ObservableCollection<Measurement> Measurements { get; }
        public Command LoadMeasurementsCommand { get; }
        public Command AddMeasurementCommand { get; }
        public Command<Measurement> MeasurementTapped { get; }
        

        public RecordingsViewModel()
        {
            Title = "Recordings";

            NewRecordingCommand = new Command(OnNewRecordingClicked);

            Measurements = new ObservableCollection<Measurement>();
            LoadMeasurementsCommand = new Command(async () => await ExecuteLoadMeasurementsCommand());

            MeasurementTapped = new Command<Measurement>(OnItemSelected);

            AddMeasurementCommand = new Command(OnAddMeasurement);
        }


        public ICommand NewRecordingCommand { get; }

        private async void OnNewRecordingClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(MeasureView)}");
        }

        async Task ExecuteLoadMeasurementsCommand()
        {
            IsBusy = true;

            try
            {
                Measurements.Clear();
                var measurements = await DataStoreUserMeasurement.GetItemsAsync(true);
                foreach (var measurement in measurements)
                {
                    Measurements.Add(measurement);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedMeasurement = null;
        }

        public Measurement SelectedMeasurement
        {
            get => _selectedMeasurement;
            set
            {
                SetProperty(ref _selectedMeasurement, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddMeasurement(object obj)
        {
            await Shell.Current.GoToAsync(nameof(LoginSPView));
        }

        async void OnItemSelected(Measurement measurement)
        {
            if (measurement == null)
                return;

            // This will push the MeasurementDetailView onto the navigation stack
            //await Shell.Current.GoToAsync($"{nameof(MeasurementDetailView)}?{nameof(MeasurementDetailViewModel.ItemId)}={measurement.Id}");
            await Shell.Current.GoToAsync($"{nameof(MeasurementDetailView)}?{nameof(MeasurementDetailViewModel.ItemId)}={measurement.Id}");
        }
    }
}