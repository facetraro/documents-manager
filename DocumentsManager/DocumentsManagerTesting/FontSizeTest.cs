using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentsMangerEntities;

namespace DocumentsManagerTesting
{
    [TestClass]
    public class FontSizeTest
    {
        [TestMethod]
        public void NotEqualFontSizeTest()
        {
            FontSize fontSizeTest = new FontSize();
            fontSizeTest.Size = 10;
            FontSize anotherFontSize = new FontSize();
            anotherFontSize.Size = 20;
            Assert.IsFalse(fontSizeTest.Equals(fontSizeTest));
        }
    }
}
