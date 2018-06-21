using DataCollectionCustomInstaller;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DatColTests.Process_Tests
{
    [TestClass]
    public class Processtests
    {
        [TestMethod]
        public void TestArrangeTemps()
        {
            TempHumidityProcessing test1 = new TempHumidityProcessing();
            byte[] testByte = new byte[35];
            testByte[0] = 0x40;
            testByte[1] = 0x10;
            testByte[2] = 0x07;
            testByte[3] = 0xba;
            testByte[4] = 0x07;
            testByte[5] = 0x8d;
            testByte[6] = 0x07;
            testByte[7] = 0x5f;
            testByte[8] = 0x07;
            testByte[9] = 0x32;
            testByte[10] = 0x07;
            testByte[11] = 0x05;
            testByte[12] = 0x06;
            testByte[13] = 0xd8;
            testByte[14] = 0x06;
            testByte[15] = 0xaa;
            testByte[16] = 0x06;
            testByte[17] = 0x7d;
            testByte[18] = 0x06;
            testByte[19] = 0x50;
            testByte[20] = 0x06;
            testByte[21] = 0x4c;
            testByte[22] = 0x06;
            testByte[23] = 0x1e;
            testByte[24] = 0x05;
            testByte[25] = 0xf1;
            testByte[26] = 0x05;
            testByte[27] = 0xc4;
            testByte[28] = 0x05;
            testByte[29] = 0x97;
            testByte[30] = 0x05;
            testByte[31] = 0x69;
            testByte[32] = 0x05;
            testByte[33] = 0x3c;
            testByte[34] = 0xFF;

            double[] testDouble = new double[16];
            testDouble[0] = 1978;
            testDouble[1] = 1933;
            testDouble[2] = 1887;
            testDouble[3] = 1842;
            testDouble[4] = 1797;
            testDouble[5] = 1752;
            testDouble[6] = 1706;
            testDouble[7] = 1661;
            testDouble[8] = 1616;
            testDouble[9] = 1612;
            testDouble[10] = 1566;
            testDouble[11] = 1521;
            testDouble[12] = 1476;
            testDouble[13] = 1431;
            testDouble[14] = 1385;
            testDouble[15] = 1340;

            double[] returntest = test1.ArrangeTemps(testByte);

            for (int i = 0; i < 16; i++)
            {
                Assert.AreEqual(testDouble[i], returntest[i]);
            }
        }


        [TestMethod]
        public void TestArrangeHumids()
        {
            TempHumidityProcessing test1 = new TempHumidityProcessing();
            byte[] testByte = new byte[19];
            testByte[0] = 0x40;
            testByte[1] = 0x20;
            testByte[2] = 0x19;
            testByte[3] = 0xdc;
            testByte[4] = 0x04;
            testByte[5] = 0xc4;
            testByte[6] = 0x19;
            testByte[7] = 0xe6;
            testByte[8] = 0x04;
            testByte[9] = 0xce;
            testByte[10] = 0x19;
            testByte[11] = 0xf0;
            testByte[12] = 0x04;
            testByte[13] = 0xd8;
            testByte[14] = 0x19;
            testByte[15] = 0xfa;
            testByte[16] = 0x04;
            testByte[17] = 0xe2;
            testByte[18] = 0xff;

            double[] testDouble = new double[8];
            testDouble[0] = 6620;
            testDouble[1] = 1220;
            testDouble[2] = 6630;
            testDouble[3] = 1230;
            testDouble[4] = 6640;
            testDouble[5] = 1240;
            testDouble[6] = 6650;
            testDouble[7] = 1250;

            double[] returntest = test1.ArrangeHumids(testByte);

            for (int i = 0; i < 8; i++)
            {
                Assert.AreEqual(testDouble[i], returntest[i]);
            }

        }

        [TestMethod]
        public void TestArrangeAuxs()
        {
            TempHumidityProcessing test1 = new TempHumidityProcessing();
            byte[] testByte = new byte[19];
            testByte[0] = 0x40;
            testByte[1] = 0x30;
            testByte[2] = 0x04;
            testByte[3] = 0x0b;
            testByte[4] = 0x08;
            testByte[5] = 0x17;
            testByte[6] = 0x0c;
            testByte[7] = 0x23;
            testByte[8] = 0x10;
            testByte[9] = 0x2e;
            testByte[10] = 0x14;
            testByte[11] = 0x3a;
            testByte[12] = 0x18;
            testByte[13] = 0x46;
            testByte[14] = 0x1c;
            testByte[15] = 0x52;
            testByte[16] = 0x20;
            testByte[17] = 0x5d;
            testByte[18] = 0xff;

            double[] testDouble = new double[8];
            testDouble[0] = 1035;
            testDouble[1] = 2071;
            testDouble[2] = 3107;
            testDouble[3] = 4142;
            testDouble[4] = 5178;
            testDouble[5] = 6214;
            testDouble[6] = 7250;
            testDouble[7] = 8285;

            double[] returntest = test1.ArrangeAuxs(testByte);

            for (int i = 0; i < 8; i++)
            {
                Assert.AreEqual(testDouble[i], returntest[i]);
            }
        }

        [TestMethod]
        public void TestProcTemps()
        {
            double[] testDouble = new double[16];
            testDouble[0] = 1978;
            testDouble[1] = 1933;
            testDouble[2] = 1887;
            testDouble[3] = 1842;
            testDouble[4] = 1797;
            testDouble[5] = 1752;
            testDouble[6] = 1706;
            testDouble[7] = 1661;
            testDouble[8] = 1616;
            testDouble[9] = 0xfff;          // 
            testDouble[10] = 1566;
            testDouble[11] = 1521;
            testDouble[12] = 1476;
            testDouble[13] = 1431;
            testDouble[14] = 1385;
            testDouble[15] = 1340;

            double[] temperatures = new double[16];
            temperatures[0] = 71.11;
            temperatures[1] = 72.2;
            temperatures[2] = 73.32;
            temperatures[3] = 74.41;
            temperatures[4] = 75.51;
            temperatures[5] = 76.6;
            temperatures[6] = 77.72;
            temperatures[7] = 78.81;
            temperatures[8] = 79.91;
            temperatures[9] = 0;
            temperatures[10] = 81.12;
            temperatures[11] = 82.21;
            temperatures[12] = 83.31;
            temperatures[13] = 84.4;
            temperatures[14] = 85.52;
            temperatures[15] = 86.61;

            TempHumidityProcessing test1 = new TempHumidityProcessing();

            double[] testReturn = test1.ProcTemps(testDouble);

            for (int i = 0; i < 16; i++)
            {
                Assert.AreEqual(temperatures[i], testReturn[i]);

            }
        }

        [TestMethod]
        public void TestProcAuxs()
        {
            double[] testDouble = new double[16];
            testDouble[0] = 1035.733;
            testDouble[1] = 2071.466;
            testDouble[2] = 3107.198;
            testDouble[3] = 4142.931;
            testDouble[4] = 5178.664;
            testDouble[5] = 6214.397;
            testDouble[6] = 7250.129;
            testDouble[7] = 8285.162;


            double[] temperatures = new double[16];
            temperatures[0] = 1;
            temperatures[1] = 2;
            temperatures[2] = 3;
            temperatures[3] = 4;
            temperatures[4] = 5;
            temperatures[5] = 6;
            temperatures[6] = 7;
            temperatures[7] = 8;


            TempHumidityProcessing test1 = new TempHumidityProcessing();

            double[] testReturn = test1.ProcAuxs(testDouble);

            for (int i = 0; i < 8; i++)
            {
                Assert.AreEqual(temperatures[i], testReturn[i], .001);

            }
        }


    }
}
