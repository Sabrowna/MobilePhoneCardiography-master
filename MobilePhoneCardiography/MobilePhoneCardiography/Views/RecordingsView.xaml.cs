using System;
using System.ComponentModel;
using MobilePhoneCardiography.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobilePhoneCardiography.Views
{
    public partial class RecordingsView : ContentPage
    {
        RecordingsViewModel _viewModel;
        public RecordingsView()
        {
            InitializeComponent();
            BindingContext = _viewModel = new RecordingsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}