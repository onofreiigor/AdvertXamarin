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
    public class DataBaseSqLiteTests
    {
        public WebSites WebSiteTest = new WebSites()
        {
            Name = "999.md",
            Url = "https://999.md",
            LangRo = "/ro",
            LangRu = "/ru"
        };

        [TestMethod()]
        public void InitConnectionSqLiteTest()
        {
            try
            {
                Assert.IsNotNull(DataBaseSqLite.InitConnectionSqLite());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        [TestMethod()]
        public void GenerateCategoryTest()
        {
            Parser.ParseSiteCategory(WebSiteTest);
            DataBaseSqLite.InitConnectionSqLite();
            try
            {
                DataBaseSqLite.GenerateCategory(WebSiteTest);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        [TestMethod()]
        public void DeleteAllFromTableWhereStateTest()
        {
            DataBaseSqLite.InitConnectionSqLite();
            DataBaseSqLite.DeleteAllFromTableWhereState("Category", "");
        }

        [TestMethod()]
        public void GetAllSiteOrByNameTest()
        {
            DataBaseSqLite.InitConnectionSqLite();
            List<WebSites> res = DataBaseSqLite.GetAllSiteOrByName("");
            foreach (var el in res)
            {
                Console.WriteLine(el);
            }
        }
    }
}