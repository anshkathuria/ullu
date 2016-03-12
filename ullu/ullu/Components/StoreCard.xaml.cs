using Plugin.ExternalMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ullu.Models;
using ullu.Toasts;
using Xamarin.Forms;

namespace ullu.Components
{
    public partial class StoreCard : ContentView
    {
        TapGestureRecognizer tgr = new TapGestureRecognizer();
        public StoreCard()
        {
            InitializeComponent();
            tgr.Tapped += navigateIconTapped;
            navigateIcon.GestureRecognizers.Add(tgr);
        }

        private async void navigateIconTapped(object sender, EventArgs e)
        {
            tgr.Tapped -= navigateIconTapped;
            Store s = this.BindingContext as Store;
            if (s.Latitude != 0 && s.Longitude != 0)
            {
                var success = await CrossExternalMaps.Current.NavigateTo(s.Name, s.Latitude, s.Longitude);
            }
            else
            {
                var msg = "Location Not Available";
                msg.ToToast(ToastNotificationType.Error);
            }
            tgr.Tapped += navigateIconTapped;
        }
    }
}
