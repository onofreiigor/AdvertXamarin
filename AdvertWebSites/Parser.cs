using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using AdvertWebSites.Models;
using HtmlAgilityPack;
using Timer = System.Timers.Timer;

namespace AdvertWebSites
{
    public class Parser
    {
        public static HttpClient HttpClient = new HttpClient();

        public static List<Advert> SearchOnSite(WebSites site, string searchString)
        {
            HtmlDocument dc = new HtmlDocument();
            List<Advert> resList = new List<Advert>();
            var res = HttpClient.GetStringAsync(site.Url + site.LangRo + "/search?query=" + searchString).Result;
            dc.LoadHtml(res);
            var cat = dc.DocumentNode.SelectNodes("//li[contains(@class,'ads-list-photo-item')]");
            foreach (var el in cat)
            {
                try
                {
                    resList.Add(new Advert
                    {
                        Url = el.SelectSingleNode("//div[contains(@class, 'ads-list-photo-item-thumb')]/a").Attributes["href"].Value.Substring(4),
                        Description = el.SelectSingleNode("//div[contains(@class, 'ads-list-photo-item-title ')]/a").InnerText,
                        ImgPath = el.SelectSingleNode("//div[contains(@class, 'ads-list-photo-item-thumb')]/a/img").Attributes["src"].Value,
                        Price = el.SelectSingleNode("//div[contains(@class, ' ads-list-photo-item-price  ')]").InnerText
                    });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }

            return resList;
        }

        public static void ParseSiteCategory(WebSites site)
        {
            HtmlDocument dc = new HtmlDocument();
            var res = HttpClient.GetStringAsync(site.Url + site.LangRo).Result;
            dc.LoadHtml(res);
            var cat = dc.DocumentNode.SelectNodes("//nav[contains(@class,'main-CatalogNavigation')]/ul/li/a");
            foreach (var el in cat)
            {
                site.Categories.Add(new Category
                {
                    Url = el.Attributes["href"].Value.Substring(3),
                    Name = el.InnerText
                });
            }
        }

        public static void ParseSubCategory(WebSites site)
        {
            HtmlDocument dc = new HtmlDocument();
            foreach (Category cat in site.Categories)
            {
                try
                {
                    var res = HttpClient.GetStringAsync(site.Url + site.LangRo + cat.Url).Result;
                    dc.LoadHtml(res);
                    var subCat = dc.DocumentNode.SelectNodes("//ul/li[contains(@class,'category__subCategories-collection ')]/a");
                    foreach (var el in subCat)
                    {
                        cat.SubCategories.Add(new SubCategory
                        {
                            Url = el.Attributes["href"].Value.Substring(3),
                            Name = el.InnerText
                        });
                    }
                    Thread.Sleep(2000);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
