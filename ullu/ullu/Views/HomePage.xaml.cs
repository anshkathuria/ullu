using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using ullu.ActivityIndicator;
using ullu.Models;
using ullu.Services;
using ullu.Toasts;
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
        Dictionary<string, Store> storesList;
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (CrossConnectivity.Current.IsConnected)
            {
                FireSharpClient FsClient = FireSharpClient.Instance;
                var hud = DependencyService.Get<IHUDProvider>();
                hud.DisplayProgress("Getting Data");
                storesList = await FsClient.GetAll<Store>("stores");
                if(storesList == null || storesList.Count == 0)
                {
                    var msg = "No Results :(";
                    msg.ToToast(ToastNotificationType.Error);
                }
                else
                {
                    storesListView.ItemsSource = storesList;
                }
                hud.Dismiss();
            }
            else
            {
                var hud = DependencyService.Get<IHUDProvider>();
                hud.DisplayError("Please Connect to Internet.");
            }

        }

        private async void OnAddStoreBtnClicked(object sender, EventArgs e)
        {
            ToolbarItem t = sender as ToolbarItem;
            t.Clicked -= OnAddStoreBtnClicked;
            await Navigation.PushAsync(new AddStorePage());
            t.Clicked += OnAddStoreBtnClicked;

        }
        private async void OnFilterBtnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FilterPage());
        }
        public async void OpenStore(object sender, SelectedItemChangedEventArgs e)
        {
            var x = storesListView.SelectedItem;
            if(x!=null)
            {
                storesListView.SelectedItem = null;
                await Navigation.PushAsync(new StoreDetailPage(x));
            }
        }
    }
}
