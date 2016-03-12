using System;
using ullu.ViewModels;
using Xamarin.Forms;

namespace ullu.Views
{
    public partial class AddStorePage : ContentPage
    {
        public AddStorePage()
        {
            InitializeComponent();
            BindingContext = new AddStoreViewModel();
        }
        private async void SaveBtn(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.IsEnabled = false;
            await Navigation.PopAsync();
            btn.IsEnabled = true;
        }
    }
}
