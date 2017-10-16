using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace AdvertWebSites
{
    public class Parser
    {
        public static HttpClient HttpClient = new HttpClient();

        public static List<Category> ParseSiteCategory(WebSites site)
        {
            HtmlDocument dc = new HtmlDocument();
            var res = HttpClient.GetStringAsync(site.Url.Value).Result;
            dc.LoadHtml(res);
            var cat = dc.DocumentNode.SelectNodes("//nav[contains(@class,'main-CatalogNavigation')]/ul/li/a");
            foreach (var el in cat)
            {
                site.Categories.Add(new Category()
                {
                    Id = el.Attributes["href"].Value,
                    Name = el.InnerText
                });
            }

            return site.Categories;
        }
    }
}
