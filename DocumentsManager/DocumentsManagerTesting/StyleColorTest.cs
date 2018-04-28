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
        [TestMethod]
        public void NotEqualColorTest()
        {
            StyleColor testColor = new StyleColor();
            testColor.TextColor = TextColor.Black;
            StyleColor anotherColor = new StyleColor();
            anotherColor.TextColor = TextColor.Blue;
            Assert.IsFalse(testColor.Equals(anotherColor));
        }
    }
}
