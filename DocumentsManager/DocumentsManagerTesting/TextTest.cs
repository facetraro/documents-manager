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
    public class TextTest
    {
        [TestMethod]
        public void TextBuilderTestSameAttr() {
            Text aText = new Text();
            Guid id = Guid.NewGuid();
            string text = "Default text test";
            StyleClass styleClass = ExampleInstances.TestStyleClass();
            aText.Id = id;
            aText.Text = text;
            aText.StyleClass = styleClass;
            Assert.AreEqual(aText.Id,id);
            Assert.AreEqual(aText.Text,text);
            Assert.AreEqual(aText.StyleClass,styleClass);
        }
        [TestMethod]
        public void TextBuilderTestDifferentAttr()
        {
            Text aText = new Text();
            Guid id = Guid.NewGuid();
            string text = "Default text test";
            StyleClass styleClass = ExampleInstances.TestStyleClass();
            aText.Id = id;
            aText.Text = text;
            aText.StyleClass = styleClass;
            Assert.AreEqual(aText.Id, id);
            Assert.AreNotEqual(aText.Text, "aDifferentText");
            Assert.AreNotEqual(aText.StyleClass, ExampleInstances.TestStyleClass());
        }
        [TestMethod]
        public void TextBuilderTestDifferentId()
        {
            Text aText = new Text();
            Guid id = Guid.NewGuid();
            string text = "Default text test";
            StyleClass styleClass = ExampleInstances.TestStyleClass();
            aText.Id = id;
            aText.Text = text;
            aText.StyleClass = styleClass;
            Assert.AreNotEqual(aText.Id, Guid.NewGuid());
            Assert.AreEqual(aText.Text, "text");
            Assert.AreEqual(aText.StyleClass, styleClass);
        }
    }
}
