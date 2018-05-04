using DocumentsManager.Data.DA.Handler;
using DocumentsManagerExampleInstances;
using DocumentsMangerEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManagerDATesting
{
    [TestClass]
    public class TextContextTest
    {
        public void TearDown()
        {
            ClearDataBase.ClearAll();
        }
        [TestMethod]
        public void AddTextTest()
        {
            TextContext context = new TextContext();
            Text newText = EntitiesExampleInstances.TestText();
            StyleClass style = EntitiesExampleInstances.TestStyleClass();
            StyleClassContextHandler contextsc = new StyleClassContextHandler();
            contextsc.Add(style);
            newText.StyleClass = style;
            context.Add(newText);
            List<Text> allTexts = context.GetLazy();
            Assert.IsTrue(allTexts.Contains(newText));
            TearDown();
        }
        [TestMethod]
        public void AddTwoTextTest()
        {
            TextContext context = new TextContext();
            Text newText = EntitiesExampleInstances.TestText();
            Text sndNewText = EntitiesExampleInstances.TestText();
            StyleClass style = EntitiesExampleInstances.TestStyleClass();
            newText.StyleClass = style;
            sndNewText.StyleClass = style;
            StyleClassContextHandler contextsc = new StyleClassContextHandler();
            contextsc.Add(style);
            context.Add(newText);
            context.Add(sndNewText);
            List<Text> allTexts = context.GetLazy();
            Assert.IsTrue(allTexts.Count==2);
            TearDown();
        }
        [TestMethod]
        public void RemoveTextTest()
        {
            TextContext context = new TextContext();
            Text newText = EntitiesExampleInstances.TestText();
            StyleClass style = EntitiesExampleInstances.TestStyleClass();
            StyleClassContextHandler contextsc = new StyleClassContextHandler();
            contextsc.Add(style);
            newText.StyleClass = style;
            context.Add(newText);
            context.Remove(newText);
            List<Text> allTexts = context.GetLazy();
            Assert.IsFalse(allTexts.Contains(newText));
            TearDown();
        }
        [TestMethod]
        public void RemoveTextIdTest()
        {
            TextContext context = new TextContext();
            Text newText = EntitiesExampleInstances.TestText();
            StyleClass style = EntitiesExampleInstances.TestStyleClass();
            StyleClassContextHandler contextsc = new StyleClassContextHandler();
            contextsc.Add(style);
            newText.StyleClass = style;
            context.Add(newText);
            context.Remove(newText.Id);
            List<Text> allTexts = context.GetLazy();
            Assert.IsFalse(allTexts.Contains(newText));
            TearDown();
        }
        [TestMethod]
        public void NotRemoveTextIdTest()
        {
            TextContext context = new TextContext();
            Text newText = EntitiesExampleInstances.TestText();
            StyleClass style = EntitiesExampleInstances.TestStyleClass();
            StyleClassContextHandler contextsc = new StyleClassContextHandler();
            contextsc.Add(style);
            newText.StyleClass = style;
            context.Add(newText);
            context.Remove(Guid.NewGuid());
            List<Text> allTexts = context.GetLazy();
            Assert.IsTrue(allTexts.Contains(newText));
            TearDown();
        }
        //[TestMethod]
        //public void ModifyTextTest()
        //{
        //    TextContext context = new TextContext();
        //    Text newText = EntitiesExampleInstances.TestText();
        //    StyleClass style = EntitiesExampleInstances.TestStyleClass();
        //    StyleClass style2 = EntitiesExampleInstances.TestStyleClass();
        //    newText.StyleClass = style;
        //    StyleClassContextHandler contextsc = new StyleClassContextHandler();
        //    contextsc.Add(style);
        //    contextsc.Add(style2);
        //    context.Add(newText);
        //    newText.WrittenText = "newText";
        //    newText.StyleClass = contextsc.GetById(style2.Id);
        //    context.Modify(newText);
        //    Text dbText = context.GetById(newText.Id);
        //    StyleClass dbStyle = contextsc.GetById(style2.Id);
        //    Assert.IsTrue(dbText.WrittenText.Equals(newText.WrittenText));
        //    Assert.IsTrue(dbText.StyleClass.Equals(dbStyle));
        //    TearDown();
        //}
    }
}
