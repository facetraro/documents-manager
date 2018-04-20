using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentsMangerEntities;

namespace DocumentsManagerTesting
{

    [TestClass]
    public class StyleAttributeTest
    {
        [TestMethod]
        public void StyleAttributeEquals()
        {
            StyleAttribute fontSizeTest = new FontSize();
            fontSizeTest.Equals(fontSizeTest);
        }
    }
}
