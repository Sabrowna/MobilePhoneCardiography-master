using System;
using System.ComponentModel;
using MobilePhoneCardiography.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobilePhoneCardiography.Views
{
    public partial class MeasureView : ContentPage
    {
        MeasureViewModel _viewModel;
        public MeasureView()
        {
            InitializeComponent();
            BindingContext = _viewModel = new MeasureViewModel();
        }


    }
}