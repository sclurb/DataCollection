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
            Assert.AreEqual( 26.24, test1.TempC, 0.01);
            TempHumDew test2 = new TempHumDew(0xf4f4, 0xf4f4);
            Assert.AreEqual(0, test2.TempC, 0.01);

        }

        [TestMethod]
        public void TempHumDewTest2()
        {
            TempHumDew test1 = new TempHumDew(6634, 1234);
            Assert.AreEqual( 40.81, test1.RH, 0.01);
            TempHumDew test2 = new TempHumDew(0xf4f4, 0xf4f4);
            Assert.AreEqual(0, test2.RH, 0.01);
        }

        [TestMethod]
        public void TempHumDewTest3()
        {
            TempHumDew test1 = new TempHumDew(6634, 1234);
            Assert.AreEqual( 40.94, test1.RHT, 0.01);
            TempHumDew test2 = new TempHumDew(0xf4f4, 0xf4f4);
            Assert.AreEqual(0, test2.RHT, 0.01);
        }

        [TestMethod]
        public void TempHumDewTest4()
        {
            TempHumDew test1 = new TempHumDew(6634, 1234);
            Assert.AreEqual(11.91, test1.DewC, 0.01);
            TempHumDew test2 = new TempHumDew(0xf4f4, 0xf4f4);
            Assert.AreEqual(0, test2.DewC, 0.01);
        }

        [TestMethod]
        public void TempHumDewTest5()
        {
            TempHumDew test1 = new TempHumDew(6634, 1234);
            Assert.AreEqual(53.45, test1.DewF, 0.01);
            TempHumDew test2 = new TempHumDew(0xf4f4, 0xf4f4);
            Assert.AreEqual(0, test2.DewF, 0.01);
        }

        [TestMethod]
        public void TempHumDewTest6()
        {
            TempHumDew test1 = new TempHumDew(6634, 1234);
            Assert.AreEqual(79.23, test1.TempF, 0.01);
            TempHumDew test2 = new TempHumDew(0xf4f4, 0xf4f4);
            Assert.AreEqual(0, test2.TempF, 0.01);
        }
    }
}
