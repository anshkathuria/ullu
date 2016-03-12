using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using System;
using ullu.ActivityIndicator;
using Xamarin.Forms;

[assembly: Dependency(typeof(ullu.Droid.Activityindicator.HUDProvider))]

namespace ullu.Droid.Activityindicator
{
    public class HUDProvider : IHUDProvider
    {
        public void DisplayProgress(string message)
        {
            AndroidHUD.AndHUD.Shared.Show(Forms.Context, message);
        }

        public void DisplaySuccess(string message)
        {
            AndroidHUD.AndHUD.Shared.ShowSuccess(Forms.Context, message, AndroidHUD.MaskType.Black, TimeSpan.FromSeconds(1));
        }

        public void DisplayError(string message)
        {
            AndroidHUD.AndHUD.Shared.ShowError(Forms.Context, message, AndroidHUD.MaskType.Black, TimeSpan.FromSeconds(1));
        }

        public void Dismiss()
        {
            AndroidHUD.AndHUD.Shared.Dismiss(Forms.Context);
        }
    }
}