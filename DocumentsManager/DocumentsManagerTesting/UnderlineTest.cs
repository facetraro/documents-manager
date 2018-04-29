using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentsMangerEntities;

namespace DocumentsManagerTesting
{
    [TestClass]
    public class UnderlineTest
    {
        [TestMethod]
        public void NotEqualUnderlineTest()
        {
            Underline underlineTest = new Underline();
            underlineTest.Applies = ApplyValue.Apply;
            Underline anotherUnderline = new Underline();
            anotherUnderline.Applies = ApplyValue.NoApply;
            Assert.IsFalse(underlineTest.Equals(anotherUnderline));
        }
    }
}
