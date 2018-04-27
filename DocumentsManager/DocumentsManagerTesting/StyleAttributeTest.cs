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
        [TestMethod]
        public void StyleAttributeUnderlineConstructor()
        {
            StyleAttribute testAttribute = new Underline();
            Assert.IsTrue(testAttribute.Name.Equals("Subrayado"));
        }
        [TestMethod]
        public void StyleAttributeBoldConstructor()
        {
            StyleAttribute testAttribute = new Bold();
            Assert.IsTrue(testAttribute.Name.Equals("Negrita"));
        }
        [TestMethod]
        public void StyleAttributeFontConstructor()
        {
            StyleAttribute testAttribute = new Font();
            Assert.IsTrue(testAttribute.Name.Equals("Tipo de Letra"));
        }
        [TestMethod]
        public void StyleAttributeColorConstructor()
        {
            StyleAttribute testAttribute = new StyleColor();
            Assert.IsTrue(testAttribute.Name.Equals("Color"));
        }
        [TestMethod]
        public void StyleAttributeEqualsDifferentObject()
        {
            StyleAttribute fontSizeTest = new FontSize();
            Assert.IsFalse(fontSizeTest.Equals("Not a StyleAttribute"));
        }
    }
}
