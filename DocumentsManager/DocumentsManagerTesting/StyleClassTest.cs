using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentsMangerEntities;

namespace DocumentsManagerTesting
{

    [TestClass]
    public class StyleClassTest
    {
        StyleClass TestStyleClass()
        {
            StyleClass testStyleClass = new StyleClass();
            testStyleClass.Underline = true;
            testStyleClass.Italics = false;
            testStyleClass.Bold = false;
            testStyleClass.FontSize = 10;
            testStyleClass.Alignment = TextAlignment.Center;
            testStyleClass.Color = TextColor.Red;
            testStyleClass.Font = FontType.Arial;
            return testStyleClass;
        }
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
            StyleClass testStyleClass = TestStyleClass();
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
