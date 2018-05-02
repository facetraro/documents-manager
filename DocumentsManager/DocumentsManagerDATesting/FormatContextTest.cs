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
            Assert.AreEqual(allFormats.Count, 0);
        }
    }
}
