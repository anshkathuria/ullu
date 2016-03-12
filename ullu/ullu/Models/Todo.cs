using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ullu.Models
{
    public class Todo : BaseModel
    {
        public string name { get; set; }
        public int priority { get; set; }
        public override void SetProperty(string key, string value)
        {
            switch (key)
            {
                case "name": name = value; break;
                case "priority": priority = Int32.Parse(value); break;
            }
        }
    }
}
