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
            aText.WrittenText = text;
            aText.StyleClass = styleClass;
            Assert.AreEqual(aText.Id,id);
            Assert.AreEqual(aText.WrittenText, text);
            Assert.AreEqual(aText.StyleClass,styleClass);
        }
        [TestMethod]
        public void TextBuilderTestDifferentAttr()
        {
            Text aText = ExampleInstances.TestText();
            Guid id = Guid.NewGuid();
            aText.Id = id;
            Assert.AreEqual(aText.Id, id);
            Assert.AreNotEqual(aText.WrittenText, "aDifferentText");
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
            aText.WrittenText = text;
            aText.StyleClass = styleClass;
            Assert.AreNotEqual(aText.Id, Guid.NewGuid());
            Assert.AreEqual(aText.WrittenText, text);
            Assert.AreEqual(aText.StyleClass, styleClass);
        }
        [TestMethod]
        public void TextEqualsTestSameAttr() {
            Text aText = ExampleInstances.TestText();
            Text sameText = ExampleInstances.TestText();
            sameText.Id = aText.Id;
            Assert.AreEqual(aText, sameText);
        }
        [TestMethod]
        public void TextEqualsTestDifferentAttr()
        {
            Text aText = ExampleInstances.TestText();
            Text anotherText = ExampleInstances.TestText();
            anotherText.StyleClass = new StyleClass();
            anotherText.WrittenText = "another Text";
            Assert.AreNotEqual(aText, anotherText);
        }
        [TestMethod]
        public void TextEqualsTestDifferentID()
        {
            Text aText = ExampleInstances.TestText();
            Text anotherText = ExampleInstances.TestText();
            Assert.AreNotEqual(aText, anotherText);
        }
     }
}
