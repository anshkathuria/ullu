using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using ullu.ActivityIndicator;
using ullu.Models;
using ullu.Services;
using ullu.Toasts;
using ullu.ViewModels;
using Utilities;
using Xamarin.Forms;

namespace ullu.Views
{
    public partial class HomePage : ContentPage
    {
        HomeViewModel ViewModel;
        public HomePage()
        {
            InitializeComponent();
            ViewModel = new HomeViewModel();
            BindingContext = ViewModel;
            searchFor.TextChanged += (sender, e) => FilterResults(searchFor.Text);
            searchFor.SearchButtonPressed += (sender, e) =>
            {
                FilterResults(searchFor.Text);
            };
        }

        private void FilterResults(string text)
        {
            storesListView.BeginRefresh();
            ViewModel.FilterResults(text);
            storesListView.EndRefresh();
        }

        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.RefreshData.Execute(this);
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
