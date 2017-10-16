﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace AdvertWebSites
{
    public class Parser
    {
        public static HttpClient HttpClient = new HttpClient();

        public static void ParseSiteCategory(WebSites site)
        {
            HtmlDocument dc = new HtmlDocument();
            var res = HttpClient.GetStringAsync(site.Url.Value + site.LangRo).Result;
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

        public static void ParseSubCategory(Url siteUrl, Category cat)
        {
            HtmlDocument dc = new HtmlDocument();
            var res = HttpClient.GetStringAsync(siteUrl.Value + cat).Result;
            dc.LoadHtml(res);
            var subCat = dc.DocumentNode.SelectNodes("//nav[contains(@class,'main-CatalogNavigation')]/ul/li/a");
        }
    }
}
