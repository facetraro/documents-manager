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
            testStyleClass.Underline = ApplyValue.NotSpecified;
            testStyleClass.Italics = ApplyValue.Apply;
            testStyleClass.Bold = ApplyValue.NoApply;
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
            ApplyValue underline = ApplyValue.NotSpecified;
            ApplyValue italics = ApplyValue.Apply;
            ApplyValue bold = ApplyValue.NoApply;
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
        [TestMethod]
        public void StyleClassBasedTest()
        {
            StyleClass testStyleClass = TestStyleClass();
            StyleClass childStyleClass = new StyleClass();
            childStyleClass.Based = testStyleClass;
            Assert.AreEqual(testStyleClass, childStyleClass.Based);
        }
        [TestMethod]
        public void GetBasedOnStyleClassTest()
        {
            StyleClass testStyleClass = TestStyleClass();
            StyleClass childStyleClass = new StyleClass();
            childStyleClass.Based = testStyleClass;
            StyleClass basedOnStyleClass = childStyleClass.GetBasedOnStyleClass();
            Assert.IsTrue(testStyleClass.Underline.Equals(basedOnStyleClass.Underline));
            Assert.IsTrue(testStyleClass.Italics.Equals(basedOnStyleClass.Italics));
            Assert.IsTrue(testStyleClass.Bold.Equals(basedOnStyleClass.Bold));
            Assert.IsTrue(testStyleClass.FontSize.Equals(basedOnStyleClass.FontSize));
            Assert.IsTrue(testStyleClass.Alignment.Equals(basedOnStyleClass.Alignment));
            Assert.IsTrue(testStyleClass.Color.Equals(basedOnStyleClass.Color));
            Assert.IsTrue(testStyleClass.Font.Equals(basedOnStyleClass.Font));
        }
        [TestMethod]
        public void GetBasedOnEmptyBasedTest()
        {
            StyleClass childStyleClass = TestStyleClass();
            StyleClass testStyleClass = new StyleClass();

            testStyleClass.Alignment = ApplyValue.NotSpecified;
            testStyleClass.Bold = ApplyValue.NotSpecified;
            testStyleClass.Color = ApplyValue.NotSpecified;
            testStyleClass.Font = ApplyValue.NotSpecified;
            testStyleClass.FontSize = ApplyValue.NotSpecified;
            testStyleClass.Italics = ApplyValue.NotSpecified;
            testStyleClass.Underline = ApplyValue.NotSpecified;
            childStyleClass.Based = testStyleClass;

            StyleClass basedOnStyleClass = childStyleClass.GetBasedOnStyleClass();
            Assert.IsTrue(childStyleClass.Underline.Equals(basedOnStyleClass.Underline));
            Assert.IsTrue(childStyleClass.Italics.Equals(basedOnStyleClass.Italics));
            Assert.IsTrue(childStyleClass.Bold.Equals(basedOnStyleClass.Bold));
            Assert.IsTrue(childStyleClass.FontSize.Equals(basedOnStyleClass.FontSize));
            Assert.IsTrue(childStyleClass.Alignment.Equals(basedOnStyleClass.Alignment));
            Assert.IsTrue(childStyleClass.Color.Equals(basedOnStyleClass.Color));
            Assert.IsTrue(childStyleClass.Font.Equals(basedOnStyleClass.Font));
        }
    }
}
