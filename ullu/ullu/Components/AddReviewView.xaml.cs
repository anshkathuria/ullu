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

            var s = BindingContext;
            var r = new Review
            {
                Rating = 4,
                Description = "Test Description",
                Date = DateTime.Now.ToString("MMM dd")
            };

            var pushKey = await FsClient.Push("stores/" + s + "/reviews", r);

        }
    }
}
