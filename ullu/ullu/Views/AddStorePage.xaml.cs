using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ullu.Views
{
    public partial class AddStorePage : ContentPage
    {
        public AddStorePage()
        {
            InitializeComponent();
        }
        private async void SaveBtn(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.IsEnabled = false;
            await Navigation.PopAsync();
            btn.IsEnabled = true;
        }
    }
}
