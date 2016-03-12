using Plugin.ExternalMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ullu
{
    public partial class TestParallaxPage : ContentPage
    {
        public TestParallaxPage()
        {
            InitializeComponent();
            outerScrollView.Scrolled += (sender, e) => Parallax();
            Parallax();
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

        async void OnMapsButtonClicked(object sender, EventArgs e)
        {
            var success = await CrossExternalMaps.Current.NavigateTo("Space Needle", 47.6204, -122.3491);
        }
    }
}
