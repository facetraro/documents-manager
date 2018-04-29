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
    public class ParragraphTest
    {
        [TestMethod]
        public void ParragraphBuilderTestSameAttr()
        {
            Parragraph aParragraph = new Parragraph();
            Guid id = Guid.NewGuid();
            Text aText = ExampleInstances.TestText();
            List<Text> texts = new List<Text>();
            texts.Add(aText);
            StyleClass style = ExampleInstances.TestStyleClass();
            aParragraph.Id = id;
            aParragraph.Texts = texts;
            aParragraph.StyleClass = style;
            Assert.AreEqual(aParragraph.Id, id);
            Assert.AreEqual(aParragraph.Texts, texts);
            Assert.AreEqual(aParragraph.StyleClass, style);
        }
        [TestMethod]
        public void ParragraphBuilderTestDifferentAttr()
        {
            Parragraph aParragraph = new Parragraph();
            Guid id = Guid.NewGuid();
            Text aText = ExampleInstances.TestText();
            List<Text> texts = new List<Text>();
            texts.Add(aText);
            StyleClass style = ExampleInstances.TestStyleClass();
            aParragraph.Id = id;
            aParragraph.Texts = texts;
            aParragraph.StyleClass = style;
            Assert.AreEqual(aParragraph.Id, id);
            Assert.AreNotEqual(aParragraph.Texts, new List<Text>());
            Assert.AreNotEqual(aParragraph.StyleClass, ExampleInstances.TestStyleClass());
        }
        [TestMethod]
        public void ParragraphBuilderTestDifferentId()
        {
            Parragraph aParragraph = new Parragraph();
            Guid id = Guid.NewGuid();
            Text text = ExampleInstances.TestText();
            StyleClass style = ExampleInstances.TestStyleClass();
            aParragraph.Id = id;
            aParragraph.Text = text;
            aParragraph.StyleClass = style;
            Assert.AreNotEqual(aParragraph.Id, Guid.NewGuid());
            Assert.AreEqual(aParragraph.Text, text);
            Assert.AreEqual(aParragraph.StyleClass, style);
        }
    }
}
