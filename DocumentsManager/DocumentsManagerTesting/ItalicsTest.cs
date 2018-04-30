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
        [TestMethod]
        public void NotEqualItalicsTest()
        {
            Italics testItalics = new Italics();
            testItalics.Applies = ApplyValue.Apply;
            Italics anotherTestItalics = new Italics();
            anotherTestItalics.Applies = ApplyValue.NoApply;
            Assert.IsFalse(testItalics.Equals(anotherTestItalics));
        }
    }
}
