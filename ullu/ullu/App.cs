using System.Diagnostics;
using ullu.Services;
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
