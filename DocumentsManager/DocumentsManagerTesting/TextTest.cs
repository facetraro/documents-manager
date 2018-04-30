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
    public class TextTest
    {
        [TestMethod]
        public void TextBuilderTestSameAttr() {
            Text aText = new Text();
            Guid id = Guid.NewGuid();
            string text = "Default text test";
            StyleClass styleClass = EntitiesExampleInstances.TestStyleClass();
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
            Text aText = EntitiesExampleInstances.TestText();
            Guid id = Guid.NewGuid();
            aText.Id = id;
            Assert.AreEqual(aText.Id, id);
            Assert.AreNotEqual(aText.WrittenText, "aDifferentText");
            Assert.AreNotEqual(aText.StyleClass, EntitiesExampleInstances.TestStyleClass());
        }
        [TestMethod]
        public void TextBuilderTestDifferentId()
        {
            Text aText = new Text();
            Guid id = Guid.NewGuid();
            string text = "Default text test";
            StyleClass styleClass = EntitiesExampleInstances.TestStyleClass();
            aText.Id = id;
            aText.WrittenText = text;
            aText.StyleClass = styleClass;
            Assert.AreNotEqual(aText.Id, Guid.NewGuid());
            Assert.AreEqual(aText.WrittenText, text);
            Assert.AreEqual(aText.StyleClass, styleClass);
        }
        [TestMethod]
        public void TextEqualsTestSameAttr() {
            Text aText = EntitiesExampleInstances.TestText();
            Text sameText = EntitiesExampleInstances.TestText();
            sameText.Id = aText.Id;
            Assert.IsTrue(aText.Equals(sameText));
        }
        [TestMethod]
        public void TextEqualsTestDifferentAttr()
        {
            Text aText = EntitiesExampleInstances.TestText();
            Text anotherText = EntitiesExampleInstances.TestText();
            anotherText.StyleClass = new StyleClass();
            anotherText.WrittenText = "another Text";
            Assert.IsFalse(aText.Equals(anotherText));
        }
        [TestMethod]
        public void TextEqualsTestDifferentID()
        {
            Text aText = EntitiesExampleInstances.TestText();
            Text anotherText = EntitiesExampleInstances.TestText();
            Assert.IsFalse(aText.Equals(anotherText));
        }
        [TestMethod]
        public void TextHasSameText()
        {
            Text aText = EntitiesExampleInstances.TestText();
            Text anotherText = EntitiesExampleInstances.TestText();
            Assert.IsTrue(aText.HasSameText(anotherText));
        }
        [TestMethod]
        public void TextHasSameTextDifferent()
        {
            Text aText = EntitiesExampleInstances.TestText();
            Text anotherText = EntitiesExampleInstances.TestText();
            anotherText.WrittenText = "A different text";
            Assert.IsFalse(aText.HasSameText(anotherText));
        }
        [TestMethod]
        public void TextHasSameTextEmptyFirst()
        {
            Text aText = EntitiesExampleInstances.TestText();
            Text anotherText = EntitiesExampleInstances.TestText();
            aText.WrittenText = "";
            Assert.IsFalse(aText.HasSameText(anotherText));
        }
        [TestMethod]
        public void TextHasSameTextEmptySecond()
        {
            Text aText = EntitiesExampleInstances.TestText();
            Text anotherText = EntitiesExampleInstances.TestText();
            anotherText.WrittenText = "";
            Assert.IsFalse(aText.HasSameText(anotherText));
        }
        [TestMethod]
        public void TextHasSameTextBothEmpty()
        {
            Text aText = EntitiesExampleInstances.TestText();
            Text anotherText = EntitiesExampleInstances.TestText();
            aText.WrittenText = "";
            anotherText.WrittenText = "";
            Assert.IsTrue(aText.HasSameText(anotherText));
        }
    }

}
