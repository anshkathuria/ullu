using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.OS;


namespace ullu.Droid.SplashScreen
{
    [Activity(Label = "Ullu", Theme = "@style/Theme.Splash", Icon = "@drawable/icon", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.SplashLayout);
            System.Threading.ThreadPool.QueueUserWorkItem(o => LoadActivity());

            //TextView companyName = FindViewById<TextView>(Resource.Id.promusLabel);
            //companyName.TextSize = 18;
        }
        private void LoadActivity()
        {
            System.Threading.Thread.Sleep(3000); // Simulate a long pause
            RunOnUiThread(() => StartActivity(typeof(MainActivity)));
        }
    }
}