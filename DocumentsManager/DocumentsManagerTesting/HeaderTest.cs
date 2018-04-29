using DocumentsMangerEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManagerTesting
{
    [TestClass]
    public class HeaderTest
    {
        [TestMethod]
        public void HeaderBuilderTestSameAttr()
        {
            Header aHeader = new Header();
            Guid id = Guid.NewGuid();
            Text text = ExampleInstances.TestText();
            StyleClass style = ExampleInstances.TestStyleClass();
            aHeader.Id = id;
            aHeader.Text = text;
            aHeader.StyleClass = style;
            Assert.AreEqual(aHeader.Id, id);
            Assert.AreEqual(aHeader.Text, text);
            Assert.AreEqual(aHeader.StyleClass, style);
        }
        [TestMethod]
        public void HeaderBuilderTestDifferentAttr()
        {
            Header aHeader = new Header();
            Guid id = Guid.NewGuid();
            Text text = ExampleInstances.TestText();
            StyleClass style = ExampleInstances.TestStyleClass();
            aHeader.Id = id;
            aHeader.Text = text;
            aHeader.StyleClass = style;
            Assert.AreEqual(aHeader.Id, id);
            Assert.AreNotEqual(aHeader.Text, "aDifferentText");
            Assert.AreNotEqual(aHeader.StyleClass, ExampleInstances.TestStyleClass());
        }
        [TestMethod]
        public void HeaderBuilderTestDifferentId()
        {
            Header aHeader = new Header();
            Guid id = Guid.NewGuid();
            Text text = ExampleInstances.TestText();
            StyleClass style = ExampleInstances.TestStyleClass();
            aHeader.Id = id;
            aHeader.Text = text;
            aHeader.StyleClass = style;
            Assert.AreNotEqual(aHeader.Id, Guid.NewGuid());
            Assert.AreEqual(aHeader.Text, text);
            Assert.AreEqual(aHeader.StyleClass, style);
        }
        [TestMethod]
        public void HeaderEqualsTestSameAttr()
        {
            Header aHeader = ExampleInstances.TestHeader();
            Header sameHeader = ExampleInstances.TestHeader();
            sameHeader.Id = aHeader.Id;
            Assert.IsTrue(aHeader.Equals(sameHeader));
        }
        [TestMethod]
        public void TextEqualsTestDifferentAttr()
        {
            Header aHeader = ExampleInstances.TestHeader();
            Header anotherHeader = ExampleInstances.TestHeader();
            anotherHeader.StyleClass = new StyleClass();
            anotherHeader.Text = ExampleInstances.TestText();
            Assert.IsFalse(aHeader.Equals(anotherHeader));
        }
        [TestMethod]
        public void TextEqualsTestDifferentID()
        {
            Header aHeader = ExampleInstances.TestHeader();
            Header anotherHeader = ExampleInstances.TestHeader();
            Assert.IsFalse(aHeader.Equals(anotherHeader));
        }
    }
}
