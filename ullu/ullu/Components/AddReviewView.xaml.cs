using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ullu.ActivityIndicator;
using ullu.Models;
using ullu.Services;
using ullu.Toasts;
using ullu.ViewModels;
using Xamarin.Forms;

namespace ullu.Components
{
    public partial class AddReviewView : ContentView
    {
        public AddReviewView()
        {
            InitializeComponent();
            starOne.IsStarred = true;
        }
        private async void OnAddReviewBtnClicked(object sender, EventArgs e)
        {
            var s = BindingContext as string;
            int rating;
            if (starFive.IsStarred)
                rating = 5;
            else if (starFour.IsStarred)
                rating = 4;
            else if (starThree.IsStarred)
                rating = 3;
            else if (starTwo.IsStarred)
                rating = 2;
            else
                rating = 1;
            var r = new Review
            {
                Rating = rating,
                Description = feedbackEntry.Text,
                Date = DateTime.Now.ToString("MMM dd")
            };
            if (CrossConnectivity.Current.IsConnected)
            {
                FireSharpClient FsClient = FireSharpClient.Instance;

                var hud = DependencyService.Get<IHUDProvider>();
                hud.DisplayProgress("Sending Data");
                var pushKey = await FsClient.Push("stores/" + s + "/Reviews", r);
                if (pushKey == null)
                {
                    var msg = "Server Error :(";
                    msg.ToToast(ToastNotificationType.Error);
                }
                else
                {
                    var msg = "Review Received! Thank You";
                    msg.ToToast(ToastNotificationType.Success);
                    var x = this.Parent;
                    var y = this.ParentView;
                    var z = this.ParentView.BindingContext;
                   //(BindingContext as StoreDetailViewModel).RefreshData.Execute(this);
                }
                hud.Dismiss();
            }
            else
            {
                var hud = DependencyService.Get<IHUDProvider>();
                hud.DisplayError("Please Connect to Internet.");
            }

        }
    }
}
