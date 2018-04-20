using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentsMangerEntities;

namespace DocumentsManagerTesting
{

    [TestClass]
    public class AttributeTest
    {
        [TestMethod]
        public void AttributeEquals()
        {
            DocumentsMangerEntities.Attribute fontSizeTest = new FontSize();
            fontSizeTest.Equals(fontSizeTest);
        }
    }
}
