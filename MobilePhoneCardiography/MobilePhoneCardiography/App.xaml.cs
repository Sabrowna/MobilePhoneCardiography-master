using MobilePhoneCardiography.Services;
using MobilePhoneCardiography.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobilePhoneCardiography
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            DependencyService.Register<MockDataStoreUser>();
            DependencyService.Register<MockDataStorePatient>();
            DependencyService.Register<MockDataStoreMeasurement>();
            MainPage = new AppShell();


        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
