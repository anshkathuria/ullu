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

        private async void OnAddStoreBtnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddStorePage());
            
        }
        private async void OnFilterBtnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FilterPage());
          
        }
        private async void StoreDetailBtn(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.IsEnabled = false;
            await Navigation.PushAsync(new StoreDetailPage());
            btn.IsEnabled = true;
        }
    }
}
