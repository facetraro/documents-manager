using DocumentsManagerExampleInstances;
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
            Text text = EntitiesExampleInstances.TestText();
            StyleClass style = EntitiesExampleInstances.TestStyleClass();
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
            Text text = EntitiesExampleInstances.TestText();
            StyleClass style = EntitiesExampleInstances.TestStyleClass();
            aHeader.Id = id;
            aHeader.Text = text;
            aHeader.StyleClass = style;
            Assert.AreEqual(aHeader.Id, id);
            Assert.AreNotEqual(aHeader.Text, "aDifferentText");
            Assert.AreNotEqual(aHeader.StyleClass, EntitiesExampleInstances.TestStyleClass());
        }
        [TestMethod]
        public void HeaderBuilderTestDifferentId()
        {
            Header aHeader = new Header();
            Guid id = Guid.NewGuid();
            Text text = EntitiesExampleInstances.TestText();
            StyleClass style = EntitiesExampleInstances.TestStyleClass();
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
            Header aHeader = EntitiesExampleInstances.TestHeader();
            Header sameHeader = EntitiesExampleInstances.TestHeader();
            sameHeader.Id = aHeader.Id;
            Assert.IsTrue(aHeader.Equals(sameHeader));
        }
        [TestMethod]
        public void HeaderEqualsTestDifferentAttr()
        {
            Header aHeader = EntitiesExampleInstances.TestHeader();
            Header anotherHeader = EntitiesExampleInstances.TestHeader();
            anotherHeader.StyleClass = new StyleClass();
            anotherHeader.Text = EntitiesExampleInstances.TestText();
            Assert.IsFalse(aHeader.Equals(anotherHeader));
        }
        [TestMethod]
        public void HeaderEqualsTestDifferentID()
        {
            Header aHeader = EntitiesExampleInstances.TestHeader();
            Header anotherHeader = EntitiesExampleInstances.TestHeader();
            Assert.IsFalse(aHeader.Equals(anotherHeader));
        }
    }
}
