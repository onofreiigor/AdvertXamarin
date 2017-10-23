using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using HtmlAgilityPack;
using ListPageParser.Models;

namespace ListPageParser
{
    public class Parser
    {
        public static HttpClient HttpClient = new HttpClient();

        public static List<Advert> SearchOnSite(WebSite site, string searchString)
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
    }
}
