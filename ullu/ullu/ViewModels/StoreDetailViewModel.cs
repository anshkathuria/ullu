using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ullu.Models;

namespace ullu.ViewModels
{
    [ImplementPropertyChanged]
    public class StoreDetailViewModel : BaseViewModel
    {
        public KeyValuePair<string, Store> KeyValue { get; set; }
    }
}
