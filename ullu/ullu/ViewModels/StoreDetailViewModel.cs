using Plugin.Connectivity;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ullu.ActivityIndicator;
using ullu.Models;
using ullu.Services;
using ullu.Toasts;
using Utilities;
using Xamarin.Forms;

namespace ullu.ViewModels
{
    [ImplementPropertyChanged]
    public class StoreDetailViewModel : BaseViewModel
    {
        public KeyValuePair<string, Store> KeyValue { get; set; }
        public ObservableDictionary<string, Review> reviewsList { get; set; }
        public async void GetData()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                FireSharpClient FsClient = FireSharpClient.Instance;
                var hud = DependencyService.Get<IHUDProvider>();
                hud.DisplayProgress("Getting Reviews");
                var reviewsDict = await FsClient.GetAll<Review>("stores/"+ KeyValue.Key + "/reviews");
                if (reviewsDict == null || reviewsDict.Count == 0)
                {
                    var msg = "No Reviews :(";
                    msg.ToToast(ToastNotificationType.Error);
                }
                else
                {
                    reviewsList = new ObservableDictionary<string, Review>(reviewsDict);
                }
                hud.Dismiss();
            }
            else
            {
                var hud = DependencyService.Get<IHUDProvider>();
                hud.DisplayError("Please Connect to Internet.");
            }
        }

        private Command refreshData;
        public ICommand RefreshData
        {
            get
            {
                return refreshData ?? (refreshData = new Command(GetData));
            }
        }
    }
}
