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
    public class FormatContextTest
    {
        private void TearDown()
        {
            ClearFormatDataBase();
            ClearStyleClassDataBase();
        }

        private void ClearStyleClassDataBase()
        {
            StyleClassContextHandler contextStyleClass = new StyleClassContextHandler();
            contextStyleClass.ClearAll();
        }

        private void ClearFormatDataBase()
        {
            FormatContext context = new FormatContext();
            context.ClearAll();
        }

        [TestMethod]
        public void AddFormatTest()
        {
            FormatContext context = new FormatContext();
            StyleClassContextHandler contextStyle = new StyleClassContextHandler();
            Format newFormat = EntitiesExampleInstances.TestFormat();
            StyleClass anotherStyle = EntitiesExampleInstances.TestStyleClass();
            anotherStyle.Name = "anotherStyle";
            newFormat.StyleClasses.Add(anotherStyle);
            foreach (var item in newFormat.StyleClasses)
            {
                contextStyle.Add(item);
            }
            context.Add(newFormat);
            List<Format> allFormats = context.GetLazy();
            Assert.IsTrue(allFormats.Contains(newFormat));
            TearDown();
        }
        [TestMethod]
        public void RemoveFormatTest()
        {
            FormatContext context = new FormatContext();
            StyleClassContextHandler contextStyle = new StyleClassContextHandler();
            Format newFormat = EntitiesExampleInstances.TestFormat();
            StyleClass anotherStyle = EntitiesExampleInstances.TestStyleClass();
            anotherStyle.Name = "anotherStyle";
            newFormat.StyleClasses.Add(anotherStyle);
            foreach (var item in newFormat.StyleClasses)
            {
                contextStyle.Add(item);
            }
            context.Add(newFormat);
            context.Remove(newFormat);
            List<Format> allFormats = context.GetLazy();
            Assert.AreEqual(0, allFormats.Count);
            TearDown();
        }
        [TestMethod]
        public void GetFormatTest()
        {
            FormatContext context = new FormatContext();
            StyleClassContextHandler contextStyle = new StyleClassContextHandler();
            Format newFormat = EntitiesExampleInstances.TestFormat();
            StyleClass anotherStyle = EntitiesExampleInstances.TestStyleClass();
            anotherStyle.Name = "anotherStyle";
            newFormat.StyleClasses.Add(anotherStyle);
            foreach (var item in newFormat.StyleClasses)
            {
                contextStyle.Add(item);
            }
            context.Add(newFormat);
            Format format = context.GetById(newFormat.Id);
            Assert.AreEqual(newFormat, format);
            TearDown();
        }
    }
}
