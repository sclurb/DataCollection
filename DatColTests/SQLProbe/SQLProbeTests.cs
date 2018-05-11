using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataCollectionCustomInstaller;
using System.Collections.Generic;

namespace DatColTests.SQLProbe
{
    [TestClass]
    class SQLProbeTests
    {

        [TestMethod]
        public void Select1_test()
        {
            SqlProbe test = new SqlProbe();
            List<string> list = new List<string>();
            list.Add("Ephot-NC/SQLEXpress2012");
            list.Add("Ephot-NC/SQLEXpress");

            string result = test.Select(list);

            Assert.AreEqual("yoMomma", result);
        }
    }
}
