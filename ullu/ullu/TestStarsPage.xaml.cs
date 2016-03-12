using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ullu
{
    public partial class TestStarsPage : ContentPage
    {
        List<string> getCategories = new List<string>();
        public TestStarsPage()
        {
            InitializeComponent();
        }
        private void OnBtnClicked(object s, EventArgs e)
        {
            Button btn = s as Button;
            if (btn.BackgroundColor == Color.Transparent)
            {
                btn.BackgroundColor = Color.Blue;
                getCategories.Add(btn.Text);
                Debug.WriteLine("getCategories" + getCategories);
            }
            else
            {
                btn.BackgroundColor = Color.Transparent;
                getCategories.Remove(btn.Text);
                Debug.WriteLine("getCategories" + getCategories);

            }
        }
    }
}
