using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentsMangerEntities;
using System.Linq;
using System.Collections.Generic;
using DocumentsManagerExampleInstances;

namespace DocumentsManagerTesting
{

    [TestClass]
    public class StyleClassTest
    {
        [TestMethod]
        public void StyleClassConstructorTest()
        {
            Underline underline = new Underline();
            underline.Applies = ApplyValue.NoApply;
            Italics italics = new Italics();
            italics.Applies = ApplyValue.Apply;
            Bold bold = new Bold();
            bold.Applies = ApplyValue.NoApply;
            FontSize fontSize = new FontSize();
            fontSize.Size = 10;
            Alignment alignment = new Alignment();
            alignment.TextAlignment = TextAlignment.Center;
            StyleColor color = new StyleColor();
            color.TextColor = TextColor.Red;
            Font font = new Font();
            font.FontType = FontType.Arial;
            StyleClass testStyleClass = EntitiesExampleInstances.TestStyleClass();
          
            Assert.IsTrue(testStyleClass.GetAttributeByName(underline.Name).Equals(underline));
            Assert.IsTrue(testStyleClass.GetAttributeByName(italics.Name).Equals(italics));
            Assert.IsTrue(testStyleClass.GetAttributeByName(bold.Name).Equals(bold));
            Assert.IsTrue(testStyleClass.GetAttributeByName(fontSize.Name).Equals(fontSize));
            Assert.IsTrue(testStyleClass.GetAttributeByName(alignment.Name).Equals(alignment));
            Assert.IsTrue(testStyleClass.GetAttributeByName(color.Name).Equals(color));
            Assert.IsTrue(testStyleClass.GetAttributeByName(font.Name).Equals(font));      
        }
        [TestMethod]
        public void StyleClassEqualsTest()
        {
            StyleClass testStyleClass = EntitiesExampleInstances.TestStyleClass();
            Assert.AreEqual(testStyleClass, testStyleClass);
        }
        [TestMethod]
        public void StyleClassNotEqualsTest()
        {
            StyleClass testStyleClass = EntitiesExampleInstances.TestStyleClass();
            StyleClass anotherTestStyleClass = EntitiesExampleInstances.TestStyleClass();
            Assert.AreNotEqual(testStyleClass, anotherTestStyleClass);
        }
        [TestMethod]
        public void StyleClassEqualsDifferentTypeTest()
        {
            StyleClass testStyleClass = EntitiesExampleInstances.TestStyleClass();
            int otherObject = 10;
            Assert.AreNotEqual(testStyleClass, otherObject);
        }
        [TestMethod]
        public void StyleClassBasedTest()
        {
            StyleClass testStyleClass = EntitiesExampleInstances.TestStyleClass();
            StyleClass childStyleClass = new StyleClass();
            childStyleClass.Based = testStyleClass;
            Assert.AreEqual(testStyleClass, childStyleClass.Based);
        }
        [TestMethod]
        public void GetBasedOnStyleClassTest()
        {
            StyleClass testStyleClass = EntitiesExampleInstances.TestStyleClass();
            StyleClass childStyleClass = new StyleClass();
            childStyleClass.Based = testStyleClass;
            StyleClass basedOnStyleClass = childStyleClass.GetBasedOnStyleClass();
            Assert.IsTrue(basedOnStyleClass.Attributes.SequenceEqual(testStyleClass.Attributes));
        }
        [TestMethod]
        public void GetBasedOnEmptyBasedTest()
        {
            StyleClass childStyleClass = EntitiesExampleInstances.TestStyleClass();
            StyleClass testStyleClass = new StyleClass();
            childStyleClass.Based = testStyleClass;
            StyleClass basedOnStyleClass = childStyleClass.GetBasedOnStyleClass();
            Assert.IsTrue(basedOnStyleClass.Attributes.SequenceEqual(childStyleClass.Attributes));
        }
        [TestMethod]
        public void GetSomeAttributesFromBasedTest()
        {
            StyleClass childStyleClass = new StyleClass();
            Font fontAttribute = new Font();
            fontAttribute.FontType = FontType.CourierNew;
            StyleColor colorAttribute = new StyleColor();
            colorAttribute.TextColor = TextColor.Blue;
            Alignment alignmentAttribute = new Alignment();
            alignmentAttribute.TextAlignment = TextAlignment.Right;
            childStyleClass.Attributes.Add(fontAttribute);
            childStyleClass.Attributes.Add(colorAttribute);
            childStyleClass.Attributes.Add(alignmentAttribute);
            StyleClass testStyleClass = EntitiesExampleInstances.TestStyleClass();
            testStyleClass.Attributes.Remove(testStyleClass.GetAttributeByName(alignmentAttribute.Name));
            testStyleClass.Attributes.Remove(testStyleClass.GetAttributeByName(colorAttribute.Name));
            testStyleClass.Attributes.Remove(testStyleClass.GetAttributeByName(fontAttribute.Name));
            childStyleClass.Based = testStyleClass;
            List<StyleAttribute> expectedAttributes = childStyleClass.Based.Attributes;
            expectedAttributes.Add(fontAttribute);
            expectedAttributes.Add(colorAttribute);
            expectedAttributes.Add(alignmentAttribute);
            StyleClass basedOnStyleClass = childStyleClass.GetBasedOnStyleClass();
            Assert.IsTrue(basedOnStyleClass.Attributes.SequenceEqual(expectedAttributes));
        }
    }
}
