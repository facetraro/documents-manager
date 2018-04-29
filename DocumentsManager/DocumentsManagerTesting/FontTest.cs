using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentsMangerEntities;

namespace DocumentsManagerTesting
{
    [TestClass]
    public class FontTest
    {
        [TestMethod]
        public void EqualFontTypeTest()
        {
            Font testFont = new Font();
            testFont.FontType = DocumentsMangerEntities.FontType.Arial;
            Font anotherFont = new Font();
            testFont.FontType = DocumentsMangerEntities.FontType.TimesNewRoman;
            Assert.IsFalse(testFont.Equals(anotherFont));
        }
        [TestMethod]
        public void NotEqualFontTypeTest()
        {
            Font testFont = new Font();
            testFont.FontType = DocumentsMangerEntities.FontType.Arial;
            Assert.IsFalse(testFont.Equals("Not a Font"));
        }
    }
}
