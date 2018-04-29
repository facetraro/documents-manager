using DocumentsManagerExampleInstances;
using DocumentsMangerEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManagerTesting
{
    [TestClass]
    public class FromatTest
    {
        [TestMethod]
        public void TestFormatBuilder() {
            Guid Id = Guid.NewGuid();
            string name = "DefaultFormatName";
            List<StyleClass> styles = new List<StyleClass>();
            styles.Add(EntitiesExampleInstances.TestStyleClass());
            Format format = EntitiesExampleInstances.TestFormat();
            format.Id = Id;
            format.StyleClasses = styles;
            Assert.AreEqual(format.Id,Id);
            Assert.AreEqual(format.Name,name);
            Assert.AreEqual(format.StyleClasses,styles);
        }
        [TestMethod]
        public void TestFormatBuilderNotSame()
        {
            
            Format format = EntitiesExampleInstances.TestFormat();
            Assert.AreNotEqual(format.Id, Guid.NewGuid());
            Assert.AreNotEqual(format.Name, "anotherName");
            Assert.AreNotEqual(format.StyleClasses, new List<StyleClass>());
        }
        [TestMethod]
        public void TestFormatEquals() {
            Format format = EntitiesExampleInstances.TestFormat();
            Assert.IsTrue(format.Equals(format));
        }
        [TestMethod]
        public void TestFormatNotEquals()
        {
            Format format = EntitiesExampleInstances.TestFormat();
            Format anotherFormat = EntitiesExampleInstances.TestFormat();
            anotherFormat.Name = "anotherFormatName";
            format.StyleClasses = new List<StyleClass>();
            Assert.IsFalse(format.Equals(anotherFormat));
        }
        [TestMethod]
        public void TestFormatDifferentButEquals()
        {
            Format format = EntitiesExampleInstances.TestFormat();
            Format anotherFormat = EntitiesExampleInstances.TestFormat();
            anotherFormat.Id = format.Id; 
            anotherFormat.Name = "anotherFormatName";
            format.StyleClasses = new List<StyleClass>();
            Assert.IsTrue(format.Equals(anotherFormat));
        }
    }
}
