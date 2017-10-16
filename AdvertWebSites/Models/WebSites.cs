using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AdvertWebSites
{
    public class WebSites
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Url Url { get; set; }
        public List<Category> Categories { get; set; }

        public WebSites()
        {
            Categories = new List<Category>();
        }

        public static WebSites AddWebSite(string name, Url url)
        {
            WebSites ws = new WebSites()
            {
                Id = 1,
                Name = name,
                Url = url
            };

            return ws;
        }
    }
}
