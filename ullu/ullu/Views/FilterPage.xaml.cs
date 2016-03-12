using System;
using ullu.ViewModels;
using Xamarin.Forms;

namespace ullu.Views
{
    public partial class FilterPage : ContentPage
    {
        public FilterPage()
        {
            InitializeComponent();
            BindingContext = new FilterViewModel();
        }
        private async void ApplyBtn(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.IsEnabled = false;
            await Navigation.PopAsync();
            btn.IsEnabled = true;
        }
    }
}
