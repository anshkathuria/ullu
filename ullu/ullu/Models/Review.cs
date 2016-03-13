using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ullu.Models
{
    [ImplementPropertyChanged]
    public class Review 
    {
        public int Rating { get; set; }
        public string Description { get; set; }

        public string Date { get; set; }
    }
}
