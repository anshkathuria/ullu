using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ullu.Models;
using ullu.Services;
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
            FireSharpClient FsClient = FireSharpClient.Instance;

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
            var pushKey = await FsClient.Push("stores/" + s + "/Reviews", r);

        }
    }
}
