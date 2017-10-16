using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertWebSites
{
    public class Category
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public List<SubCategory> SubCategories { get; set; }

        public Category()
        {
            SubCategories = new List<SubCategory>();
        }

        public override string ToString()
        {
            return $"Url: {Url}\nName: {Name}\nSubCategory Count: {SubCategories.Count}\n";
        }
    }
}
