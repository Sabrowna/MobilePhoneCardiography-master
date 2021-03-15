using MobilePhoneCardiography.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MobilePhoneCardiography.Views;
using Xamarin.Forms;

namespace MobilePhoneCardiography.ViewModels
{
    public class FindPatientViewModel : BaseViewModel
    {
        private string _firstName;
        private string _lastName;
        private string _socSec;
        private string _socSecSearch;
        private bool confirmVisible;
        private bool cancelVisible;
        private bool findPatientVisible = true;
        private bool consentVisible;
        private string consentFrameOpacity = "0";

        public FindPatientViewModel()
        {
            FindPatientCommand = new Command(OnSearch, ValidateBlankEntry);
            CancelCommand = new Command(Cancel);
            ConfirmCommand = new Command(Confirm);
            this.PropertyChanged +=
                (_, __) => FindPatientCommand.ChangeCanExecute();
        }

        private async void Confirm()
        {

            //Load Measurements for patient

            //Change view to recordings view
            await Shell.Current.GoToAsync($"//{nameof(RecordingsView)}");
        }

        private bool ValidateBlankEntry()
        {
            return !String.IsNullOrWhiteSpace(_socSecSearch);
        }

        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }

        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        public string SocSecSearch
        {
            get => _socSecSearch;
            set => SetProperty(ref _socSecSearch, value);
        }

        public string SocSec
        {
            get => _socSec;
            set => SetProperty(ref _socSec, value);
        }

        public bool ConfirmVisible
        {
            get => confirmVisible;
            set => SetProperty(ref confirmVisible, value);
        }

        public bool CancelVisible
        {
            get => cancelVisible;
            set => SetProperty(ref cancelVisible, value);
        }

        public bool FindPatientVisible
        {
            get => findPatientVisible;
            set => SetProperty(ref findPatientVisible, value);
        }

        public bool ConsentVisible
        {
            get => consentVisible;
            set => SetProperty(ref consentVisible, value);
        }
        public string ConsentFrameOpacity
        {
            get => consentFrameOpacity;
            set => SetProperty(ref consentFrameOpacity, value);
        }

        public Command FindPatientCommand { get; }
        public Command ConfirmCommand{ get; }
        public Command CancelCommand{ get; }



        private void ToggleButtons()
        {
            if (findPatientVisible)
            {
                FindPatientVisible = false;
                ConfirmVisible = true;
                CancelVisible = true;
            }
            else
            {
                FindPatientVisible = true;
                ConfirmVisible = false;
                CancelVisible = false;
            }
        }

        private void Cancel()
        {
            SocSecSearch = "";
            FirstName = "";
            LastName = "";
            ConsentVisible = false;
            ConsentFrameOpacity = "0";
            ToggleButtons();
        }

        private async void OnSearch()
        {
            ConsentVisible = true;
            ConsentFrameOpacity = "100";
            ToggleButtons();
            //User newUser = new User()
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    Username = FirstName,
            //    Password = LastName
            //};
            var patient= await DataStorePatient.GetItemAsync(Convert.ToInt64(SocSecSearch));

            SocSec = patient.SocSec;
            FirstName = patient.FirstName;
            LastName = patient.LastName;



            //await DataStoreUser.AddItemAsync(newUser);

            //// This will pop the current page off the navigation stack
            //await Shell.Current.GoToAsync($"//{nameof(RecordingsView)}");
        }
    }
}
