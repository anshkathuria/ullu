using System;
using Android.Widget;
using ullu.Toasts;
using Xamarin.Forms;
using System.Threading.Tasks;

[assembly: Dependency(typeof(ullu.Droid.Toasts.ToastNotifier))]

namespace ullu.Droid.Toasts
{
    public class ToastNotifier : IToastNotifier
    {
        public Task<bool> Notify(ToastNotificationType type, string title, string description, TimeSpan duration, object context = null)
        {
            var taskCompletionSource = new TaskCompletionSource<bool>();
            Toast.MakeText(Forms.Context, description, ToastLength.Short).Show();
            return taskCompletionSource.Task;
        }

        public void HideAll()
        {
        }
    }
}