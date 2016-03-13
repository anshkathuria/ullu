using System;
using System.Collections.Generic;
using ullu.Models;
using ullu.ViewModels;
using Xamarin.Forms;

namespace ullu.Views
{
    public partial class StoreDetailPage : TabbedPage
    {
        
        StoreDetailViewModel ViewModel;
        public StoreDetailPage()
        {
            InitializeComponent();

        }

        public StoreDetailPage(object x)
        {
            InitializeComponent();
            if(x != null)
            {
                ViewModel = new StoreDetailViewModel();
                ViewModel.KeyValue = (KeyValuePair<string, Store>)x;
                this.BindingContext = ViewModel;
            }
        }

        private void OnAddReviewClicked(object s, EventArgs e)
        {
            Navigation.PushAsync(new AddReviewPage());
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.RefreshData.Execute(this);
        }
    }
}
