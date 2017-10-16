using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertWebSites
{
    public class SubCategory
    {
        public string Url { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Url: {Url}\nName: {Name}\n";
        }
    }
}
