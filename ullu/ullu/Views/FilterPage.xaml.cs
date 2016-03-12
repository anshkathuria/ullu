using System;
using System.Collections.Generic;
using System.Diagnostics;
using ullu.ViewModels;
using Xamarin.Forms;

namespace ullu.Views
{
    public partial class FilterPage : ContentPage
    {
        List<string> getCategories = new List<string>();

        public FilterPage()
        {
            InitializeComponent();
            BindingContext = new FilterViewModel();
        }
        private async void ApplyBtn(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.IsEnabled = false;
            await Navigation.PopAsync();
            btn.IsEnabled = true;
        }
        private void OnBtnClicked(object s, EventArgs e)
        {
            Button btn = s as Button;
            if (!(btn.BorderColor == Color.Green))
            {
                btn.BorderColor = Color.Green;
                getCategories.Add(btn.Text);
                Debug.WriteLine("getCategories" + getCategories);
            }
            else
            {
                btn.BorderColor = Color.White;
                getCategories.Remove(btn.Text);
                Debug.WriteLine("getCategories" + getCategories);

            }
        }
        private void OnRatingClicked(object s, EventArgs e)
        {
            Button btn = s as Button;

            if (btn.BorderColor == Color.Default)
            {
                btn.Image = "star_selected";
                btn.BorderColor = Color.Green;
            }
            else
            {
                btn.Image = "star_outline";
                btn.BorderColor = Color.Default;
            }
        }
        private void OnDistanceClicked(object s, EventArgs e)
        {
            Button btn = s as Button;

        }
    }
}
