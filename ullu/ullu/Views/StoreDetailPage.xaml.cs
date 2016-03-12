using System;

using Xamarin.Forms;

namespace ullu.Views
{
    public partial class StoreDetailPage : TabbedPage
    {
        public StoreDetailPage()
        {
            InitializeComponent();

        }
        private void OnAddReviewClicked(object s, EventArgs e)
        {
            Navigation.PushAsync(new AddReviewPage());
        }
    }
}
