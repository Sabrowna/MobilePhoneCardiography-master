using MobilePhoneCardiography.ViewModels;
using MobilePhoneCardiography.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MobilePhoneCardiography
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MeasurementDetailView), typeof(MeasurementDetailView));
            Routing.RegisterRoute(nameof(LoginSPView), typeof(LoginSPView));
            Routing.RegisterRoute(nameof(FindPatientView), typeof(FindPatientView));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
