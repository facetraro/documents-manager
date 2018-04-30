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
    public class FooterTest
    {
        [TestMethod]
        public void FooterBuilderTestSameAttr()
        {
            Footer aFooter = new Footer();
            Guid id = Guid.NewGuid();
            Text text = EntitiesExampleInstances.TestText();
            StyleClass style = EntitiesExampleInstances.TestStyleClass();
            aFooter.Id = id;
            aFooter.Text = text;
            aFooter.StyleClass = style;
            Assert.AreEqual(aFooter.Id, id);
            Assert.AreEqual(aFooter.Text, text);
            Assert.AreEqual(aFooter.StyleClass, style);
        }
        [TestMethod]
        public void FooterBuilderTestDifferentAttr()
        {
            Footer aFooter = new Footer();
            Guid id = Guid.NewGuid();
            Text text = EntitiesExampleInstances.TestText();
            StyleClass style = EntitiesExampleInstances.TestStyleClass();
            aFooter.Id = id;
            aFooter.Text = text;
            aFooter.StyleClass = style;
            Assert.AreEqual(aFooter.Id, id);
            Assert.AreNotEqual(aFooter.Text, "aDifferentText");
            Assert.AreNotEqual(aFooter.StyleClass, EntitiesExampleInstances.TestStyleClass());
        }
        [TestMethod]
        public void FooterBuilderTestDifferentId()
        {
            Footer aFooter = new Footer();
            Guid id = Guid.NewGuid();
            Text text = EntitiesExampleInstances.TestText();
            StyleClass style = EntitiesExampleInstances.TestStyleClass();
            aFooter.Id = id;
            aFooter.Text = text;
            aFooter.StyleClass = style;
            Assert.AreNotEqual(aFooter.Id, Guid.NewGuid());
            Assert.AreEqual(aFooter.Text, text);
            Assert.AreEqual(aFooter.StyleClass, style);
        }
        [TestMethod]
        public void FooterEqualsTestSameAttr()
        {
            Footer aFooter = EntitiesExampleInstances.TestFooter();
            Footer sameFooter = EntitiesExampleInstances.TestFooter();
            sameFooter.Id = aFooter.Id;
            Assert.IsTrue(aFooter.Equals(sameFooter));
        }
        [TestMethod]
        public void FooterEqualsTestDifferentAttr()
        {
            Footer aFooter = EntitiesExampleInstances.TestFooter();
            Footer anotheraFooter = EntitiesExampleInstances.TestFooter();
            anotheraFooter.StyleClass = new StyleClass();
            anotheraFooter.Text = EntitiesExampleInstances.TestText();
            Assert.IsFalse(aFooter.Equals(anotheraFooter));
        }
        [TestMethod]
        public void FooterEqualsTestDifferentID()
        {
            Footer aFooter = EntitiesExampleInstances.TestFooter();
            Footer anotheraFooter = EntitiesExampleInstances.TestFooter();
            Assert.IsFalse(aFooter.Equals(anotheraFooter));
        }
    }
}
