using Plugin.ExternalMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ullu.Models;
using ullu.Services;
using ullu.Toasts;
using Xamarin.Forms;

namespace ullu.Components
{
    public partial class ParallaxView : ContentView
    {
        public ParallaxView()
        {
            InitializeComponent();
            outerScrollView.Scrolled += (sender, e) => Parallax();
            Parallax();
            tgr.Tapped += navigateIconTapped;
            navigateIcon.GestureRecognizers.Add(tgr);
        }
        double _imageHeight;
        void Parallax()
        {
            if (_imageHeight <= 0)
                _imageHeight = img.Height;

            var y = outerScrollView.ScrollY * .4;
            if (y >= 0)
            {
                //Move the Image's Y coordinate a fraction of the ScrollView's Y position
                img.Scale = 1;
                img.TranslationY = y;
            }
            else
            {
                //Calculate a scale that equalizes the height vs scroll
                double newHeight = _imageHeight + (outerScrollView.ScrollY * -1);
                img.Scale = newHeight / _imageHeight;
                img.TranslationY = outerScrollView.ScrollY / 2;
            }
        }

        TapGestureRecognizer tgr = new TapGestureRecognizer();
        private async void navigateIconTapped(object sender, EventArgs e)
        {
            tgr.Tapped -= navigateIconTapped;
            var s = (KeyValuePair<string, Store>)BindingContext;
            Store str = s.Value;
            if (str.Latitude != 0 && str.Longitude != 0)
            {
                var success = await CrossExternalMaps.Current.NavigateTo(str.Name, str.Latitude, str.Longitude);
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
