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
            Assert.IsTrue(fontSizeTest.Equals(fontSizeTest));
        }
        [TestMethod]
        public void StyleAttributeNotEquals()
        {
            StyleAttribute fontSizeTest = new FontSize();
            StyleAttribute anotherAttribute = new StyleColor();
            Assert.IsFalse(anotherAttribute.Equals(fontSizeTest));
        }
        [TestMethod]
        public void StyleAttributeConstructor()
        {
            StyleAttribute testAttribute = new Alignment();
            Assert.IsTrue(testAttribute.Name.Equals("Alineación"));
        }
        [TestMethod]
        public void StyleAttributeFontSizeConstructor()
        {
            StyleAttribute testAttribute = new FontSize();
            Assert.IsTrue(testAttribute.Name.Equals("Tamaño"));
        }
        [TestMethod]
        public void StyleAttributeItalicsConstructor()
        {
            StyleAttribute testAttribute = new Italics();
            Assert.IsTrue(testAttribute.Name.Equals("Cursiva"));
        }
    }
}
