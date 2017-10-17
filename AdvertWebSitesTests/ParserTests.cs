using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdvertWebSites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AdvertWebSites.Tests
{
    [TestClass()]
    public class ParserTests
    {
        public WebSites WebSiteTest = new WebSites()
        {
            Name = "test",
            Url = "https://999.md",
            LangRo = "/ro",
            LangRu = "/ru"
        };

        [TestMethod()]
        public void ParseSiteCategoryTest()
        {
            Parser.ParseSiteCategory(WebSiteTest);

            foreach (var el in WebSiteTest.Categories)
            {
                Console.WriteLine(el.ToString());
            }
        }

        [TestMethod()]
        public void ParseSubCategoryTest()
        {
            Parser.ParseSiteCategory(WebSiteTest);
            Parser.ParseSubCategory(WebSiteTest);

            foreach (Category cat in WebSiteTest.Categories)
            {
                foreach (SubCategory subCat in cat.SubCategories)
                {
                    Console.WriteLine(subCat);
                }
            }
        }

        [TestMethod()]
        public void SearchOnSiteTest()
        {
            var list = Parser.SearchOnSite(WebSiteTest, "adsl");
            foreach (var el in list)
            {
                Console.WriteLine(el);
            }
        }
    }
}