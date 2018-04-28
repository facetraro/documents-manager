using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentsMangerEntities;

namespace DocumentsManagerTesting
{
    [TestClass]
    public class StyleColorTest
    {
        [TestMethod]
        public void EqualColorTest()
        {
            StyleColor testColor = new StyleColor();
            testColor.TextColor = TextColor.Black;
            Assert.IsTrue(testColor.Equals(testColor));
        }
    }
}
