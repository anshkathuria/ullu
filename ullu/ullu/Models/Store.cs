using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ullu.Models
{
    [ImplementPropertyChanged]
    public class Store
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Address { get; set; }
        public bool IsLocation { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Landmark { get; set; }
        public string[] Tags { get; set; }
        
    }
}
