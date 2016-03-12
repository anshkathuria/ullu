using System.Diagnostics;
using ullu.Services;
using ullu.Utilities;
using Xamarin.Forms;

namespace ullu
{
    public class App : Application
    {
        GoogleMapsService googleMapsService = GoogleMapsService.Instance;
        public App()
        {

            //TestGoogle();
            // The root page of your application
            //var d = GeoDistance.distance(32.9697, -96.80322, 29.46786, -98.53506, 'K');
            //Debug.WriteLine(d);
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        new Label {
                            XAlign = TextAlignment.Center,
                            Text = "Welcome to Xamarin Forms!"
                        }
                    }
                }
            };
        }
        private async void TestGoogle()
        {
            var l = await googleMapsService.GetLocationFromAddress("1600 Amphitheatre Parkway, Mountain View, CA").ConfigureAwait(false);
            Debug.WriteLine(l.lat);
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
