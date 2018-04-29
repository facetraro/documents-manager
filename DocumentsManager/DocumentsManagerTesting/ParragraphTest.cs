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
            Text aText = ExampleInstances.TestText();
            List<Text> texts = new List<Text>();
            texts.Add(aText);
            StyleClass style = ExampleInstances.TestStyleClass();
            aParragraph.Id = id;
            aParragraph.Texts = texts;
            aParragraph.StyleClass = style;
            Assert.AreNotEqual(aParragraph.Id, Guid.NewGuid());
            Assert.AreEqual(aParragraph.Texts, texts);
            Assert.AreEqual(aParragraph.StyleClass, style);
        }
        [TestMethod]
        public void ParragraphEqualsTestSameAttr()
        {
            Parragraph aParragraph = ExampleInstances.TestParragraph();
            Parragraph sameParragraph = ExampleInstances.TestParragraph();
            sameParragraph.Id = aParragraph.Id;
            Assert.IsTrue(aParragraph.Equals(sameParragraph));
        }
        [TestMethod]
        public void ParragraphEqualsTestDifferentAttr()
        {
            Parragraph aParragraph = ExampleInstances.TestParragraph();
            Parragraph anotheraParragraph = ExampleInstances.TestParragraph();
            anotheraParragraph.StyleClass = new StyleClass();
            anotheraParragraph.Texts = new List<Text>();
            Assert.IsFalse(aParragraph.Equals(anotheraParragraph));
        }
        [TestMethod]
        public void ParragraphEqualsTestDifferentID()
        {
            Parragraph aParragraph = ExampleInstances.TestParragraph();
            Parragraph anotheraParragraph = ExampleInstances.TestParragraph();
            Assert.IsFalse(aParragraph.Equals(anotheraParragraph));
        }
        [TestMethod]
        public void ParragraphAddTextTest() {
            Parragraph aParragraph = ExampleInstances.TestParragraph();
            Text aText = ExampleInstances.TestText();
            aParragraph.AddText(aText);
            Assert.IsTrue(aParragraph.Texts.Count == 2);
        }
        [TestMethod]
        public void ParragraphAddTextTestMultiple()
        {
            Parragraph aParragraph = ExampleInstances.TestParragraph();
            Text aText = ExampleInstances.TestText();
            aParragraph.AddText(aText);
            aParragraph.AddText(aText);
            aParragraph.AddText(aText);
            aParragraph.AddText(aText);
            Assert.IsTrue(aParragraph.Texts.Count == 5);
        }
    }
}
