using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentsMangerEntities;

namespace DocumentsManagerTesting
{
    [TestClass]
    public class AlignmentTest
    {
        [TestMethod]
        public void NotEqualAlignmentTest()
        {
            Alignment alignmentTest = new Alignment();
            alignmentTest.TextAlignment = TextAlignment.Justify;
            Alignment anotherAlignment = new Alignment();
            anotherAlignment.TextAlignment = TextAlignment.Center;
            Assert.IsFalse(alignmentTest.Equals(anotherAlignment));
        }   
    }
}
