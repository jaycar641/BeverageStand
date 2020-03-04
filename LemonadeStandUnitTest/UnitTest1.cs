using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LemonadeStand;

namespace LemonadeStandUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        
        



        [TestMethod]
        public void TestMethod1()
        {

            Store store = new Store();

            int test1 = 0;
            int test2 = 0;

            int expectedResult = 0;
            int actualResults = 0;


            
            Assert.AreEqual(expectedResult, actualResults);
            


        }
    }
}
