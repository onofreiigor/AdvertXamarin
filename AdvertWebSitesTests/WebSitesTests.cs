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
    public class WebSitesTests
    {
        [TestMethod()]
        public void AddWebSiteTest()
        {
            WebSites ws = WebSites.AddWebSite("test", new Url("888.md"));
            Assert.IsNotNull(ws);
        }
    }
}