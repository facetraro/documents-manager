﻿using DocumentsMangerEntities;
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
            Text text = ExampleInstances.TestText();
            StyleClass style = ExampleInstances.TestStyleClass();
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
            Text text = ExampleInstances.TestText();
            StyleClass style = ExampleInstances.TestStyleClass();
            aFooter.Id = id;
            aFooter.Text = text;
            aFooter.StyleClass = style;
            Assert.AreEqual(aFooter.Id, id);
            Assert.AreNotEqual(aFooter.Text, "aDifferentText");
            Assert.AreNotEqual(aFooter.StyleClass, ExampleInstances.TestStyleClass());
        }
        [TestMethod]
        public void FooterBuilderTestDifferentId()
        {
            Footer aFooter = new Footer();
            Guid id = Guid.NewGuid();
            Text text = ExampleInstances.TestText();
            StyleClass style = ExampleInstances.TestStyleClass();
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
            Footer aFooter = ExampleInstances.TestFooter();
            Footer sameFooter = ExampleInstances.TestFooter();
            sameFooter.Id = aFooter.Id;
            Assert.IsTrue(aFooter.Equals(sameFooter));
        }
        [TestMethod]
        public void FooterEqualsTestDifferentAttr()
        {
            Footer aFooter = ExampleInstances.TestFooter();
            Footer anotheraFooter = ExampleInstances.TestFooter();
            anotheraFooter.StyleClass = new StyleClass();
            anotheraFooter.Text = ExampleInstances.TestText();
            Assert.IsFalse(aFooter.Equals(anotheraFooter));
        }
        [TestMethod]
        public void FooterEqualsTestDifferentID()
        {
            Footer aFooter = ExampleInstances.TestFooter();
            Footer anotheraFooter = ExampleInstances.TestFooter();
            Assert.IsFalse(aFooter.Equals(anotheraFooter));
        }
    }
}
