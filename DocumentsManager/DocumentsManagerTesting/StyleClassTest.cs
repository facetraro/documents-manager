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
            testStyleClass.Id = Guid.NewGuid();
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
        [TestMethod]
        public void StyleClassEqualsTest()
        {
            StyleClass testStyleClass = TestStyleClass();
            Assert.AreEqual(testStyleClass, testStyleClass);
        }
        [TestMethod]
        public void StyleClassNotEqualsTest()
        {
            StyleClass testStyleClass = TestStyleClass();
            StyleClass anotherTestStyleClass = TestStyleClass();
            Assert.AreNotEqual(testStyleClass, anotherTestStyleClass);
        }
        [TestMethod]
        public void StyleClassEqualsDifferentTypeTest()
        {
            StyleClass testStyleClass = TestStyleClass();
            int otherObject = 10;
            Assert.AreNotEqual(testStyleClass, otherObject);
        }
    }
}
