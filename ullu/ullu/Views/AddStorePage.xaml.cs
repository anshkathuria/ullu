using DLToolkit.Forms.Controls;
using System;
using ullu.Constants;
using ullu.Models;
using ullu.ViewModels;
using Xamarin.Forms;

namespace ullu.Views
{
    public partial class AddStorePage : ContentPage
    {
        AddStoreViewModel ViewModel;
        public AddStorePage()
        {
            InitializeComponent();
            ViewModel = new AddStoreViewModel();
            BindingContext = ViewModel;
            foreach(string category in AppConstants.CATEGORIES)
            {
                categoryPicker.Items.Add(category);
            }
            var tagEntryView = new TagEntryView()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                TagValidatorFactory = new Func<string, object>((arg) => ViewModel.ValidateAndReturn(arg)),
                TagViewFactory = new Func<View>(() => new TagItemView())
            };
            tagEntryView.SetBinding<AddStoreViewModel>(TagEntryView.TagItemsProperty, v => v.Items);
            tagEntryView.TagTapped += (sender, e) => {
                if (e.Item != null)
                    ViewModel.RemoveTag((TagItem)e.Item);
            };
            tagEntryWrapper.Children.Add(tagEntryView);

        }
        class TagItemView : Frame
        {
            public TagItemView()
            {
                BackgroundColor = Color.FromHex("#2196F3");
                OutlineColor = Color.Transparent;
                Padding = 10;

                var label = new Label();
                label.SetBinding<TagItem>(Label.TextProperty, v => v.Name);

                Content = label;
            }
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
