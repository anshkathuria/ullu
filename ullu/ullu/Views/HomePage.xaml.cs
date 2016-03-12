using System;
using ullu.ViewModels;
using Xamarin.Forms;

namespace ullu.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = new HomeViewModel();
        }

        private async void ContinueBtn(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.IsEnabled = false;
            await Navigation.PushAsync(new AddStorePage());
            btn.IsEnabled = true;
        }
        private async void FilterBtn(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.IsEnabled = false;
            await Navigation.PushAsync(new FilterPage());
            btn.IsEnabled = true;
        }
    }
}
