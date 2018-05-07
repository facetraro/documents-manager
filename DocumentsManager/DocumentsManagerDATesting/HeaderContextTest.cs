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
            ClearDataBase.ClearAll();
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
            contextsc.Add(style);
            newText.StyleClass = style;
            newHeader.StyleClass = style;
            newHeader.Text = newText;
            sndHeader.StyleClass = style;
            context.Add(newHeader);
            context.Add(sndHeader);
            List<Header> allHeaderss = context.GetLazy();
            Assert.IsTrue(allHeaderss.Count==2);
            TearDown();
        }
        [TestMethod]
        public void RemoveHeaderTest()
        {
            HeaderContext context = new HeaderContext();
            Header newHeader = EntitiesExampleInstances.TestHeader();
            Text newText = EntitiesExampleInstances.TestText();
            StyleClass style = EntitiesExampleInstances.TestStyleClass();
            StyleClassContextHandler contextsc = new StyleClassContextHandler();
            contextsc.Add(style);
            newText.StyleClass = style;
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
            Header newHeader = EntitiesExampleInstances.TestHeader();
            Text newText = EntitiesExampleInstances.TestText();
            StyleClass style = EntitiesExampleInstances.TestStyleClass();
            StyleClassContextHandler contextsc = new StyleClassContextHandler();
            contextsc.Add(style);
            newText.StyleClass = style;
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
            Header newHeader = EntitiesExampleInstances.TestHeader();
            Text newText = EntitiesExampleInstances.TestText();
            StyleClass style = EntitiesExampleInstances.TestStyleClass();
            StyleClassContextHandler contextsc = new StyleClassContextHandler();
            contextsc.Add(style);
            newText.StyleClass = style;
            newHeader.StyleClass = style;
            newHeader.Text = newText;
            context.Add(newHeader);
            context.Remove(Guid.NewGuid());
            List<Header> allHeaders = context.GetLazy();
            Assert.IsTrue(allHeaders.Contains(newHeader));
            TearDown();
        }
        [TestMethod]
        public void ModifyHeaderTest()
        {
            HeaderContext context = new HeaderContext();
            Header newHeader = EntitiesExampleInstances.TestHeader();
            StyleClass style = EntitiesExampleInstances.TestStyleClass();
            StyleClass style2 = EntitiesExampleInstances.TestStyleClass();
            newHeader.StyleClass = style;
            StyleClassContextHandler contextsc = new StyleClassContextHandler();
            contextsc.Add(style);
            contextsc.Add(style2);
            context.Add(newHeader);
            Text newText = EntitiesExampleInstances.TestText();
            newText.WrittenText = "newText";
            newText.StyleClass = style;
            newHeader.Text = newText;
            newHeader.StyleClass = style2;
            context.Modify(newHeader);
            Header dbHeader = context.GetById(newHeader.Id);
            StyleClass dbStyle = contextsc.GetById(style2.Id);
            Assert.AreEqual(dbHeader.Text.WrittenText,newText.WrittenText);
            Assert.AreEqual(dbHeader.StyleClass,dbStyle);
            TearDown();
        }
    }
}
