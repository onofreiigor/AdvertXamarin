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
        [TestMethod()]
        public void ParseSiteCategoryTest()
        {
            WebSites ws = new WebSites()
            {
                Name = "test",
                Url = new Url("https://999.md/ro")
            };
            var res = Parser.ParseSiteCategory(ws);
            foreach (var el in res)
            {
                Console.WriteLine($"Id: {el.Id} \nName: {el.Name}\n");
            }
        }
    }
}