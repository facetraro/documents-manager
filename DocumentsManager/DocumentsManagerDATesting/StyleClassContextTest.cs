using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentsMangerEntities;
using System.Collections.Generic;
using DocumentsManagerDataAccess;
using DocumentsManagerExampleInstances;
using System.Linq;
using DocumentsManager.Data.DA.Handler;

namespace DocumentsManagerDATesting
{
    [TestClass]
    public class StyleClassContextTest
    {
        public void TearDown()
        {
            StyleClassContextHandler context = new StyleClassContextHandler();
            context.ClearAll();
        }
        [TestMethod]
        public void AddStyleClassTest()
        {
            StyleClassContextHandler context = new StyleClassContextHandler();
            StyleClass newStyle = EntitiesExampleInstances.TestStyleClass();
            context.Add(newStyle);
            List<StyleClass> allStyles = context.GetLazy();
            Assert.IsTrue(allStyles.Contains(newStyle));
            TearDown();
        }
        [TestMethod]
        public void RemoveStyleClassTest()
        {
            StyleClassContextHandler context = new StyleClassContextHandler();
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
            StyleClassContextHandler context = new StyleClassContextHandler();
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
            StyleClassContextHandler context = new StyleClassContextHandler();
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
            StyleClassContextHandler context = new StyleClassContextHandler();
            StyleClass newStyle = EntitiesExampleInstances.TestStyleClass();
            context.Add(newStyle);
            context.Remove(newStyle);
            List<StyleAttribute> allAttributes = context.GetAllAttributes();
            Assert.IsTrue(allAttributes.Count == 0);
            TearDown();
        }
        [TestMethod]
        public void ModifyStyleClassTest()
        {
            StyleClassContextHandler context = new StyleClassContextHandler();
            StyleClass newStyle = EntitiesExampleInstances.TestStyleClass();
            context.Add(newStyle);
            StyleAttribute toRemove = newStyle.Attributes[2];
            newStyle.Attributes.Remove(toRemove);
            context.Modify(newStyle);
            List<StyleAttribute> allAttributes = context.GetAttributes(newStyle);
            Assert.IsTrue(allAttributes.Count == newStyle.Attributes.Count);
            foreach (var item in allAttributes)
            {
                Assert.IsTrue(newStyle.GetAttributeByName(item.Name).Equals(item));
            }
            TearDown();
        }
        [TestMethod]
        public void DeleteStyleClassBased()
        {
            StyleClassContextHandler context = new StyleClassContextHandler();
            StyleClass newStyle = EntitiesExampleInstances.TestStyleClass();
            StyleAttribute toRemove = newStyle.Attributes[2];
            newStyle.Attributes.Remove(toRemove);
            StyleClass fatherStyle = EntitiesExampleInstances.TestStyleClass();
            newStyle.Based = fatherStyle;
            context.Add(fatherStyle);
            context.Add(newStyle);
            context.Remove(fatherStyle);
            Assert.AreEqual(context.GetLazy().Count, 1);
            TearDown();
        }
    }
}
