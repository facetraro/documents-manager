using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentsMangerEntities;

namespace DocumentsManagerTesting
{
    [TestClass]
    public class ItalicsTest
    {
        [TestMethod]
        public void EqualItalicsTest()
        {
            Italics testItalics = new Italics();
            testItalics.Applies = ApplyValue.Apply;
            Assert.IsTrue(testItalics.Equals(testItalics));
        }
    }
}
