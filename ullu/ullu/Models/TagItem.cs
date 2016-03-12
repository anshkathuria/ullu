using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ullu.Models
{
    [ImplementPropertyChanged]
    public class TagItem : BaseModel
    {
        public string Name { get; set; }
        public override void SetProperty(string key, string value)
        {
            switch (key)
            {
                case "Name": Name = value; break;  
            }
        }
    }
}
