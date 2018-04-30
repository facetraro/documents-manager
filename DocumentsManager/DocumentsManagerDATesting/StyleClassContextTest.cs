using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentsMangerEntities;
using System.Collections.Generic;
using DocumentsManagerDataAccess;
using DocumentsManagerExampleInstances;

namespace DocumentsManagerDATesting
{
    [TestClass]
    public class StyleClassContextTest
    {
        public void TearDown()
        {
            StyleClassContext context = new StyleClassContext();
            context.ClearAll();
        }
        [TestMethod]
        public void AddStyleClassTest()
        {
            StyleClassContext context = new StyleClassContext();
            StyleClass newStyle = EntitiesExampleInstances.TestStyleClass();
            context.Add(newStyle);
            List<StyleClass> allStyles = context.GetLazy();
            Assert.IsTrue(allStyles.Contains(newStyle));
            TearDown();
        }
        [TestMethod]
        public void RemoveStyleClassTest()
        {
            StyleClassContext context = new StyleClassContext();
            StyleClass newStyle = EntitiesExampleInstances.TestStyleClass();
            context.Add(newStyle);
            context.Remove(newStyle);
            List<StyleClass> allStyles = context.GetLazy();
            Assert.IsTrue(allStyles.Count==0);
            TearDown();
        }
    }
}
