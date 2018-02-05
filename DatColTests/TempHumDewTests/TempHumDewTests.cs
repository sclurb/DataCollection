using DataCollection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatColTests.TempHumDewTests
{
    [TestClass]
    public class TempHumDewTests
    {
        [TestMethod]
        public void TempHumDewTest1()
        {
            TempHumDew test1 = new TempHumDew(6634, 1234);
            Assert.AreEqual(test1.TempC, 26.24, 0.01);
        }

        [TestMethod]
        public void TempHumDewTest2()
        {
            TempHumDew test1 = new TempHumDew(6634, 1234);
            Assert.AreEqual(test1.RH, 40.81, 0.01);
        }
    }
}
