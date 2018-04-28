using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DocumentsManagerTesting
{
    [TestClass]
    public class ItalicsTest
    {

        [TestMethod]
        public void EqualBoldTest()
        {
            Italics testItalics = new Italics();
            testItalics.Applies = ApplyValue.Apply;
            Assert.IsTrue(testItalics.Equals(testItalics));
        }
       
    }
}
