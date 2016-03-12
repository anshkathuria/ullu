using DLToolkit.Forms.Controls;
using Plugin.Connectivity;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using ullu.ActivityIndicator;
using ullu.Constants;
using ullu.Models;
using ullu.Services;
using ullu.Toasts;
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
            ToolbarItem i  = sender as ToolbarItem;
            i.Clicked -= SaveBtn;
            var hud = DependencyService.Get<IHUDProvider>();
            hud.DisplayProgress("Saving Data");
            await Task.Delay(500);
            if (!String.IsNullOrWhiteSpace(nameEntry.Text) && categoryPicker.SelectedIndex >=0 && !String.IsNullOrWhiteSpace(addressEntry.Text) && !String.IsNullOrWhiteSpace(landmarkEntry.Text) && ViewModel.Items.Count > 0)
            {
                if (CrossConnectivity.Current.IsConnected)
                {
                    FireSharpClient FsClient = FireSharpClient.Instance;
                    if (IsLocation == false)
                    {
                        GoogleMapsService googleMapsService = GoogleMapsService.Instance;
                        var l = await googleMapsService.GetLocationFromAddress(addressEntry.Text);
                        if (l != null)
                        {
                            CurrentLatitude = l.lat;
                            CurrentLongitude = l.lng;
                        }
                        else
                        {
                            var addressInvalid = "Address is not available on Google Maps";
                            addressInvalid.ToToast(ToastNotificationType.Error);
                        }
                    }
                    Store s = new Store
                    {
                        Name = nameEntry.Text,
                        Category = AppConstants.CATEGORIES[categoryPicker.SelectedIndex],
                        Address = addressEntry.Text,
                        IsLocation = this.IsLocation,
                        Latitude = this.CurrentLatitude,
                        Longitude = this.CurrentLongitude,
                        Landmark = landmarkEntry.Text
                    };
                    List<string> tempList = new List<string>();
                    foreach (var item in ViewModel.Items)
                    {
                        tempList.Add(item.Name);
                    }
                    s.Tags = tempList.ToArray();
                    var pushKey = await FsClient.Push("stores", s);
                    hud.Dismiss();
                    await Navigation.PopAsync();
                    var msg = "Your data has been saved.";
                    msg.ToToast(ToastNotificationType.Error);
                }
                else
                {
                    hud.Dismiss();
                    var msg = "Make sure you're connected to Internet.";
                    msg.ToToast(ToastNotificationType.Error);
                }
            }
            else
            {
                hud.Dismiss();
                var msg = "Please Fill All the Fields";
                msg.ToToast(ToastNotificationType.Error);
            }
            hud.Dismiss();
            i.Clicked += SaveBtn;
        }

        private bool IsLocation = false;
        private double CurrentLatitude;
        private double CurrentLongitude;

        public async void OnGetCurrentLocation(object s, EventArgs e)
        {
            if (CrossGeolocator.Current.IsGeolocationEnabled)
            {
                try
                {
                    var locator = CrossGeolocator.Current;
                    locator.DesiredAccuracy = 50;

                    var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
                    IsLocation = true;
                    CurrentLatitude = position.Latitude;
                    CurrentLongitude = position.Longitude;
                    Debug.WriteLine("Position Status: {0}", position.Timestamp);
                    Debug.WriteLine("Position Latitude: {0}", CurrentLatitude);
                    Debug.WriteLine("Position Longitude: {0}", CurrentLongitude);
                    addressEntry.Text = String.Format("{0}, {1}", CurrentLatitude, CurrentLongitude);
                }
                catch (Exception ex)
                {
                    var msg = "Unable to get location, may need to increase timeout";
                    msg.ToToast(ToastNotificationType.Error);
                }
            }
            else
            {
                var msg = "Please Turn On Your GPS";
                msg.ToToast(ToastNotificationType.Error);
            }
            
        }
    }
}
