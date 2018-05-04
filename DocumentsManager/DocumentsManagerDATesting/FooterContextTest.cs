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
    public class FooterContextTest
    {
        public void TearDown()
        {
            ClearFooterDataBase();
        }
        private void ClearFooterDataBase()
        {
            FooterContext context = new FooterContext();
            StyleClassContextHandler contextSC = new StyleClassContextHandler();
            TextContext contextT = new TextContext();
            context.ClearAll();
            contextT.ClearAll();
            contextSC.ClearAll();
        }
        [TestMethod]
        public void AddFooterTest()
        {
            FooterContext context = new FooterContext();
            Footer newFooter = EntitiesExampleInstances.TestFooter();
            StyleClass style = EntitiesExampleInstances.TestStyleClass();
            Text newText = EntitiesExampleInstances.TestText();
            StyleClassContextHandler contextsc = new StyleClassContextHandler();
            TextContext contextT = new TextContext();
            contextsc.Add(style);
            newText.StyleClass = style;
            contextT.Add(newText);
            newFooter.StyleClass = style;
            newFooter.Text = newText;
            context.Add(newFooter);
            List<Footer> allFooters = context.GetLazy();
            Assert.IsTrue(allFooters.Contains(newFooter));
            TearDown();
        }
        [TestMethod]
        public void AddTwoFootersTest()
        {
            FooterContext context = new FooterContext();
            Footer newFooter = EntitiesExampleInstances.TestFooter();
            Footer sndFooter = EntitiesExampleInstances.TestFooter();
            StyleClass style = EntitiesExampleInstances.TestStyleClass();
            Text newText = EntitiesExampleInstances.TestText();
            StyleClassContextHandler contextsc = new StyleClassContextHandler();
            TextContext contextT = new TextContext();
            contextsc.Add(style);
            newText.StyleClass = style;
            contextT.Add(newText);
            newFooter.StyleClass = style;
            newFooter.Text = newText;
            sndFooter.StyleClass = style;
            sndFooter.Text = newText;
            context.Add(newFooter);
            context.Add(sndFooter);
            List<Footer> allFooters = context.GetLazy();
            Assert.IsTrue(allFooters.Count == 2);
            TearDown();
        }
        [TestMethod]
        public void RemoveFooterTest()
        {
            FooterContext context = new FooterContext();
            TextContext contextT = new TextContext();
            Footer newFooter = EntitiesExampleInstances.TestFooter();
            Text newText = EntitiesExampleInstances.TestText();
            StyleClass style = EntitiesExampleInstances.TestStyleClass();
            StyleClassContextHandler contextsc = new StyleClassContextHandler();
            contextsc.Add(style);
            newText.StyleClass = style;
            contextT.Add(newText);
            newFooter.StyleClass = style;
            newFooter.Text = newText;
            context.Add(newFooter);
            context.Remove(newFooter);
            List<Footer> allFooters = context.GetLazy();
            Assert.IsFalse(allFooters.Contains(newFooter));
            TearDown();
        }
        [TestMethod]
        public void RemoveFooterIdTest()
        {
            FooterContext context = new FooterContext();
            TextContext contextT = new TextContext();
            Footer newFooter = EntitiesExampleInstances.TestFooter();
            Text newText = EntitiesExampleInstances.TestText();
            StyleClass style = EntitiesExampleInstances.TestStyleClass();
            StyleClassContextHandler contextsc = new StyleClassContextHandler();
            contextsc.Add(style);
            newText.StyleClass = style;
            contextT.Add(newText);
            newFooter.StyleClass = style;
            newFooter.Text = newText;
            context.Add(newFooter);
            context.Remove(newFooter.Id);
            List<Footer> allFooter = context.GetLazy();
            Assert.IsFalse(allFooter.Contains(newFooter));
            TearDown();
        }
        [TestMethod]
        public void NotRemoveFooterIdTest()
        {
            FooterContext context = new FooterContext();
            TextContext contextT = new TextContext();
            Footer newFooter = EntitiesExampleInstances.TestFooter();
            Text newText = EntitiesExampleInstances.TestText();
            StyleClass style = EntitiesExampleInstances.TestStyleClass();
            StyleClassContextHandler contextsc = new StyleClassContextHandler();
            contextsc.Add(style);
            newText.StyleClass = style;
            contextT.Add(newText);
            newFooter.StyleClass = style;
            newFooter.Text = newText;
            context.Add(newFooter);
            context.Remove(Guid.NewGuid());
            List<Footer> allFooter = context.GetLazy();
            Assert.IsTrue(allFooter.Contains(newFooter));
            TearDown();
        }
    }
}
