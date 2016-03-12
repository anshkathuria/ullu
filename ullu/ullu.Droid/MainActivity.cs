using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using ullu.Droid.Controls;
using ImageCircle.Forms.Plugin.Droid;

namespace ullu.Droid
{
    [Activity(Label = "ullu", Icon = "@drawable/icon", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            ImageCircleRenderer.Init();
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

            TagEntryRenderer.Init();
            //Hide the xamarin logo
            var color = new ColorDrawable(Color.Transparent);
            ActionBar.SetIcon(color);
        }
    }
}

