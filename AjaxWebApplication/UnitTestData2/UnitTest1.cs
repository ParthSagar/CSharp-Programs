using System;
using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestData2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestReturnDataNotNull()
        {
            var select = MyObj.GetData();
            Assert.IsNotNull(select);
        }

        [TestMethod]
        public void TestDataCount()
        {
            var select = MyObj.GetData();
            //Assert.IsFalse(select.Count != 0);
        }
    }
}
