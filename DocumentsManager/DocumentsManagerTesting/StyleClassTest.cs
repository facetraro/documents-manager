using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentsMangerEntities;

namespace DocumentsManagerTesting
{
    [TestClass]
    public class StyleClassTest
    {
        [TestMethod]
        public void StyleClassConstructorTest()
        {
            bool underline = true;
            bool italics = false;
            bool bold = false;
            int fontSize = 10;
            TextAlignment alignment = TextAlignment.Center;
            TextColor color = TextColor.Red;
            FontType fontType = FontType.Arial;

            StyleClass testStyleClass = new StyleClass();
            testStyleClass.Underline = underline;
            testStyleClass.Italics = italics;
            testStyleClass.Bold = bold;
            testStyleClass.FontSize = fontSize;
            testStyleClass.Alignment = alignment;
            testStyleClass.Color = color;
            testStyleClass.Font = fontType;

            Assert.IsTrue(testStyleClass.Underline.Equals(underline));
            Assert.IsTrue(testStyleClass.Italics.Equals(italics));
            Assert.IsTrue(testStyleClass.Bold.Equals(bold));
            Assert.IsTrue(testStyleClass.FontSize.Equals(fontSize));
            Assert.IsTrue(testStyleClass.Alignment.Equals(alignment));
            Assert.IsTrue(testStyleClass.Color.Equals(color));
            Assert.IsTrue(testStyleClass.Font.Equals(fontType));
        }
    }
}
