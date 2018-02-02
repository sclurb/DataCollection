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
            TempHumDew test1 = new TempHumDew(2456, 1234);
        }
    }
}
