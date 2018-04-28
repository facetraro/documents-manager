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
        [TestMethod]
        public void NotEqualBoldTest()
        {
            Bold testBold = new Bold();
            testBold.Applies = ApplyValue.Apply;
            Bold anotherBold = new Bold();
            anotherBold.Applies = ApplyValue.NoApply;
            Assert.IsFalse(testBold.Equals(anotherBold));
        }
    }
}
