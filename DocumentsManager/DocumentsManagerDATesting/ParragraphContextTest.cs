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
    public class ParragraphContextTest
    {
        public void TearDown()
        {
            ClearParragraphDataBase();
        }
        private void ClearParragraphDataBase()
        {
            ParragraphContext context = new ParragraphContext();
            StyleClassContextHandler contextSC = new StyleClassContextHandler();
            TextContext contextT = new TextContext();
            context.ClearAll();
            contextT.ClearAll();
            contextSC.ClearAll();
        }

        [TestMethod]
        public void AddParragraphTest()
        {
            ParragraphContext context = new ParragraphContext();
            Parragraph newParragraph = EntitiesExampleInstances.TestParragraph();
            StyleClass style = EntitiesExampleInstances.TestStyleClass();
            Text newText = EntitiesExampleInstances.TestText();
            StyleClassContextHandler contextsc = new StyleClassContextHandler();
            contextsc.Add(style);
            newText.StyleClass = style;
            newParragraph.StyleClass = style;
            newParragraph.AddText(newText);
            context.Add(newParragraph);
            List<Parragraph> allnewParragraphs = context.GetLazy();
            Assert.IsTrue(allnewParragraphs.Contains(newParragraph));
            TearDown();
        }
        [TestMethod]
        public void AddTwoParragraphsTest()
        {
            ParragraphContext context = new ParragraphContext();
            Parragraph newParragraph = EntitiesExampleInstances.TestParragraph();
            Parragraph sndParragraph = EntitiesExampleInstances.TestParragraph();
            StyleClass style = EntitiesExampleInstances.TestStyleClass();
            Text newText = EntitiesExampleInstances.TestText();
            Text newSndText = EntitiesExampleInstances.TestText();
            StyleClassContextHandler contextsc = new StyleClassContextHandler();
            contextsc.Add(style);
            newText.StyleClass = style;
            newParragraph.StyleClass = style;
            newParragraph.AddText(newText);
            sndParragraph.StyleClass = style; 
            sndParragraph.AddText(newSndText);
            context.Add(newParragraph);
            context.Add(sndParragraph);
            List<Parragraph> allParragraphs = context.GetLazy();
            Assert.IsTrue(allParragraphs.Contains(sndParragraph) && allParragraphs.Contains(newParragraph));
            TearDown();
        }
        [TestMethod]
        public void RemoveParragraphTest()
        {
            ParragraphContext context = new ParragraphContext();
            Parragraph newParragraph = EntitiesExampleInstances.TestParragraph();
            Text newText = EntitiesExampleInstances.TestText();
            StyleClass style = EntitiesExampleInstances.TestStyleClass();
            StyleClassContextHandler contextsc = new StyleClassContextHandler();
            contextsc.Add(style);
            newText.StyleClass = style;
            newParragraph.StyleClass = style;
            newParragraph.AddText(newText);
            context.Add(newParragraph);
            context.Remove(newParragraph);
            List<Parragraph> allParragraphs = context.GetLazy();
            Assert.IsFalse(allParragraphs.Contains(newParragraph));
            TearDown();
        }
        [TestMethod]
        public void RemoveParragraphIdTest()
        {
            ParragraphContext context = new ParragraphContext();
            Parragraph newParragraph = EntitiesExampleInstances.TestParragraph();
            Text newText = EntitiesExampleInstances.TestText();
            StyleClass style = EntitiesExampleInstances.TestStyleClass();
            StyleClassContextHandler contextsc = new StyleClassContextHandler();
            contextsc.Add(style);
            newText.StyleClass = style;
            newParragraph.StyleClass = style;
            newParragraph.AddText(newText);
            context.Add(newParragraph);
            context.Remove(newParragraph.Id);
            List<Parragraph> allParragraphs = context.GetLazy();
            Assert.IsFalse(allParragraphs.Contains(newParragraph));
            TearDown();
        }
        [TestMethod]
        public void NotRemovParragraphIdTest()
        {
            ParragraphContext context = new ParragraphContext();
            Parragraph newParragraph = EntitiesExampleInstances.TestParragraph();
            Text newText = EntitiesExampleInstances.TestText();
            StyleClass style = EntitiesExampleInstances.TestStyleClass();
            StyleClassContextHandler contextsc = new StyleClassContextHandler();
            contextsc.Add(style);
            newText.StyleClass = style;
            newParragraph.StyleClass = style;
            newParragraph.AddText(newText);
            context.Add(newParragraph);
            context.Remove(Guid.NewGuid());
            List<Parragraph> allParragraphs = context.GetLazy();
            Assert.IsTrue(allParragraphs.Contains(newParragraph));
            TearDown();
        }

    }
}
