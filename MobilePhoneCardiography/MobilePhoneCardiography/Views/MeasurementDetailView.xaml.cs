using MobilePhoneCardiography.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MobilePhoneCardiography.Views
{
    public partial class MeasurementDetailView : ContentPage
    {
        public MeasurementDetailView()
        {
            InitializeComponent();
            BindingContext = new MeasurementDetailViewModel();
        }
    }
}