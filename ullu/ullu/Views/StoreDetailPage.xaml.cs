using System;
using System.Collections.Generic;
using ullu.Models;
using Xamarin.Forms;

namespace ullu.Views
{
    public partial class StoreDetailPage : TabbedPage
    {
        private KeyValuePair<string, Store> keyValue;

        public StoreDetailPage()
        {
            InitializeComponent();

        }

        public StoreDetailPage(object x)
        {
            InitializeComponent();
            if(x != null)
            {
                keyValue = (KeyValuePair<string, Store>) x;
                this.BindingContext = keyValue;
            }
        }

        private void OnAddReviewClicked(object s, EventArgs e)
        {
            Navigation.PushAsync(new AddReviewPage());
        }
    }
}
