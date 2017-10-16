using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdvertWebSites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertWebSites.Tests
{
    [TestClass()]
    public class DataBaseSqLiteTests
    {
        [TestMethod()]
        public void InitConnectionSqLiteTest()
        {
            Assert.IsNotNull(DataBaseSqLite.InitConnectionSqLite());
        }
    }
}