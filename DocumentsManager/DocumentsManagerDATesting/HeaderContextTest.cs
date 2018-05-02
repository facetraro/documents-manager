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
    public class HeaderContextTest
    {
        public void TearDown()
        {
            ClearTextDataBase();
        }
        private void ClearTextDataBase()
        {
            HeaderContext context = new HeaderContext();
            StyleClassContextHandler contextSC = new StyleClassContextHandler();
            TextContext contextT = new TextContext();
            context.ClearAll();
            contextT.ClearAll();
            contextSC.ClearAll();
        }
        [TestMethod]
        public void AddHeaderTest()
        {
            HeaderContext context = new HeaderContext();
            Header newHeader = EntitiesExampleInstances.TestHeader();
            StyleClass style = EntitiesExampleInstances.TestStyleClass();
            Text newText = EntitiesExampleInstances.TestText();
            StyleClassContextHandler contextsc = new StyleClassContextHandler();
            TextContext contextT = new TextContext();
            contextsc.Add(style);
            newText.StyleClass = style;
            contextT.Add(newText);
            newHeader.StyleClass = style;
            newHeader.Text = newText;
            context.Add(newHeader);
            List<Header> allHeaderss = context.GetLazy();
            Assert.IsTrue(allHeaderss.Contains(newHeader));
            TearDown();
        }
        [TestMethod]
        public void AddTwoHeaderTest()
        {
            HeaderContext context = new HeaderContext();
            Header newHeader = EntitiesExampleInstances.TestHeader();
            Header sndHeader = EntitiesExampleInstances.TestHeader();
            StyleClass style = EntitiesExampleInstances.TestStyleClass();
            Text newText = EntitiesExampleInstances.TestText();
            StyleClassContextHandler contextsc = new StyleClassContextHandler();
            TextContext contextT = new TextContext();
            contextsc.Add(style);
            newText.StyleClass = style;
            contextT.Add(newText);
            newHeader.StyleClass = style;
            newHeader.Text = newText;
            sndHeader.StyleClass = style;
            sndHeader.Text = newText;
            context.Add(newHeader);
            context.Add(sndHeader);
            List<Header> allHeaderss = context.GetLazy();
            Assert.IsTrue(allHeaderss.Count == 2);
            TearDown();
        }
        [TestMethod]
        public void RemoveHeaderTest()
        {
            HeaderContext context = new HeaderContext();
            TextContext contextT = new TextContext();
            Header newHeader = EntitiesExampleInstances.TestHeader();
            Text newText = EntitiesExampleInstances.TestText();
            StyleClass style = EntitiesExampleInstances.TestStyleClass();
            StyleClassContextHandler contextsc = new StyleClassContextHandler();
            contextsc.Add(style);
            newText.StyleClass = style;
            contextT.Add(newText);
            newHeader.StyleClass = style;
            newHeader.Text = newText;
            context.Add(newHeader);
            context.Remove(newHeader);
            List<Header> allHeaders = context.GetLazy();
            Assert.IsFalse(allHeaders.Contains(newHeader));
            TearDown();
        }
        [TestMethod]
        public void RemoveHeaderIdTest()
        {
            HeaderContext context = new HeaderContext();
            TextContext contextT = new TextContext();
            Header newHeader = EntitiesExampleInstances.TestHeader();
            Text newText = EntitiesExampleInstances.TestText();
            StyleClass style = EntitiesExampleInstances.TestStyleClass();
            StyleClassContextHandler contextsc = new StyleClassContextHandler();
            contextsc.Add(style);
            newText.StyleClass = style;
            contextT.Add(newText);
            newHeader.StyleClass = style;
            newHeader.Text = newText;
            context.Add(newHeader);
            context.Remove(newHeader.Id);
            List<Header> allHeaders = context.GetLazy();
            Assert.IsFalse(allHeaders.Contains(newHeader));
            TearDown();
        }
        [TestMethod]
        public void NotRemoveHeaderIdTest()
        {
            HeaderContext context = new HeaderContext();
            TextContext contextT = new TextContext();
            Header newHeader = EntitiesExampleInstances.TestHeader();
            Text newText = EntitiesExampleInstances.TestText();
            StyleClass style = EntitiesExampleInstances.TestStyleClass();
            StyleClassContextHandler contextsc = new StyleClassContextHandler();
            contextsc.Add(style);
            newText.StyleClass = style;
            contextT.Add(newText);
            newHeader.StyleClass = style;
            newHeader.Text = newText;
            context.Add(newHeader);
            context.Remove(Guid.NewGuid());
            List<Header> allHeaders = context.GetLazy();
            Assert.IsTrue(allHeaders.Contains(newHeader));
            TearDown();
        }
    }
}
