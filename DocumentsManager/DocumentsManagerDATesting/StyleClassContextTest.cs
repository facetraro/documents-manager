using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentsMangerEntities;
using System.Collections.Generic;
using DocumentsManagerDataAccess;
using DocumentsManagerExampleInstances;
using System.Linq;

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
            Assert.IsTrue(allStyles.Count == 0);
            TearDown();
        }
        [TestMethod]
        public void GetStyleByIdTest()
        {
            StyleClassContext context = new StyleClassContext();
            StyleClass newStyle = EntitiesExampleInstances.TestStyleClass();
            context.Add(newStyle);
            StyleClass obtainedStyleClass = context.GetById(newStyle.Id);
            Assert.IsTrue(obtainedStyleClass.Equals(newStyle));
            Assert.IsTrue(obtainedStyleClass.Attributes.Count == newStyle.Attributes.Count);
            foreach (var item in obtainedStyleClass.Attributes)
            {
                Assert.IsTrue(newStyle.GetAttributeByName(item.Name).Equals(item));
            }
            TearDown();
        }
        [TestMethod]
        public void GetAttributesByStyleClassTest()
        {
            StyleClassContext context = new StyleClassContext();
            StyleClass newStyle = EntitiesExampleInstances.TestStyleClass();
            context.Add(newStyle);
            List<StyleAttribute> allAttributes = context.GetAttributes(newStyle);
            Assert.IsTrue(allAttributes.Count == newStyle.Attributes.Count);
            foreach (var item in allAttributes)
            {
                Assert.IsTrue(newStyle.GetAttributeByName(item.Name).Equals(item));
            }
            TearDown();
        }
        [TestMethod]
        public void RemoveAttributesStyleClassTest()
        {
            StyleClassContext context = new StyleClassContext();
            StyleClass newStyle = EntitiesExampleInstances.TestStyleClass();
            context.Add(newStyle);
            context.Remove(newStyle);
            List<StyleAttribute> allAttributes = context.GetAllAttributes();
            Assert.IsTrue(allAttributes.Count == 0);
            TearDown();
        }
    }
}
