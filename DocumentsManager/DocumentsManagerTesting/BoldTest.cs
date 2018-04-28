using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentsMangerEntities;

namespace DocumentsManagerTesting
{
    [TestClass]
    public class BoldTest
    {
        [TestMethod]
        public void EqualBoldTest()
        {
            Bold testBold = new Bold();
            testBold.Applies = ApplyValue.Apply;
            Assert.IsTrue(testBold.Equals(testBold));
        }
    }
}
