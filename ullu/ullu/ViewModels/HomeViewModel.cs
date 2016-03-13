using Plugin.Connectivity;
using PropertyChanged;
using System.Linq;
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
    public class HomeViewModel : BaseViewModel
    {
        private Task GetDataTask;
        public HomeViewModel()
        {
        }
        public async void GetData()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                FireSharpClient FsClient = FireSharpClient.Instance;
                var hud = DependencyService.Get<IHUDProvider>();
                hud.DisplayProgress("Getting Data");
                var storesDict = await FsClient.GetAll<Store>("stores");
                if (storesDict == null || storesDict.Count == 0)
                {
                    var msg = "No Results :(";
                    msg.ToToast(ToastNotificationType.Error);
                }
                else
                {
                    storesList = new ObservableDictionary<string, Store>(storesDict);
                    filteredStoresList = storesList;
                }
                hud.Dismiss();
            }
            else
            {
                var hud = DependencyService.Get<IHUDProvider>();
                hud.DisplayError("Please Connect to Internet.");
            }
        }
        public ObservableDictionary<string, Store> storesList { get; set; }
        public ObservableDictionary<string, Store> filteredStoresList { get; set; }

        public void FilterResults(string query)
        {
            filteredStoresList = new ObservableDictionary<string, Store>(
                                storesList.Where(x => (x.Value.Name.ToLower().Contains(query.ToLower())) ||
                                                      (x.Value.Tags.Contains(query)) ||
                                                      (x.Value.Category.ToLower().Contains(query.ToLower())) ||
                                                      (x.Value.Landmark.ToLower().Contains(query.ToLower()))
                                                 ).ToDictionary(x => x.Key, x => x.Value));
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
