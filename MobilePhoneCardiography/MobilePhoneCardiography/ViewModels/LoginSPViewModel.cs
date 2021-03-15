using MobilePhoneCardiography.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using MobilePhoneCardiography.Views;
using Xamarin.Forms;

namespace MobilePhoneCardiography.ViewModels
{
    public class LoginSPViewModel : BaseViewModel
    {
        private string _username;
        private string _password;

        public LoginSPViewModel()
        {
            LoginCommand = new Command(OnLogin, ValidateSave);
            ForgotPWCommand = new Command(OnForgotPW);
            this.PropertyChanged +=
                (_, __) => LoginCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(_username)
                && !String.IsNullOrWhiteSpace(_password);
        }

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public Command LoginCommand { get; }
        public Command ForgotPWCommand { get; }

        private async void OnForgotPW()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnLogin()
        {
            User newUser = new User()
            {
                Id = Guid.NewGuid().ToString(),
                Username = Username,
                Password = Password
            };

            await DataStoreUser.AddItemAsync(newUser);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync($"//{nameof(RecordingsView)}");
        }
    }
}
