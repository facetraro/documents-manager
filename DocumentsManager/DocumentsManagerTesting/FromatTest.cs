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
            string name = "FormatName";
            List<StyleClass> styles = new List<StyleClass>();
            StyleClass style = ExampleInstances.TestStyleClass();
            styles.Add(style);
            Format format = new Format();
            format.Id = Id;
            format.Name = name;
            format.StyleClasses = styles;
            Assert.AreEqual(format.Id,Id);
            Assert.AreEqual(format.Name,name);
            Assert.AreEqual(format.StyleClasses,styles);
        }
        [TestMethod]
        public void TestFormatBuilderNotSame()
        {
            Guid Id = Guid.NewGuid();
            string name = "FormatName";
            List<StyleClass> styles = new List<StyleClass>();
            StyleClass style = ExampleInstances.TestStyleClass();
            styles.Add(style);
            Format format = new Format();
            format.Id = Id;
            format.Name = name;
            format.StyleClasses = styles;
            Assert.AreNotEqual(format.Id, Guid.NewGuid());
            Assert.AreNotEqual(format.Name, "anotherName");
            Assert.AreNotEqual(format.StyleClasses, new List<StyleClass>());
        }
        [TestMethod]
        public void TestFormatEquals() {

            Format format = new Format();
            Guid Id = Guid.NewGuid();
            List<StyleClass> styles = new List<StyleClass>();
            StyleClass style = ExampleInstances.TestStyleClass();
            styles.Add(style);
            format.Id = Id;
            format.Name = "FormatName";
            format.StyleClasses = styles;
            Assert.IsTrue(format.Equals(format));
        }
        [TestMethod]
        public void TestFormatNotEquals()
        {
            Format format = new Format();
            List<StyleClass> styles = new List<StyleClass>();
            StyleClass style = ExampleInstances.TestStyleClass();
            styles.Add(style);
            format.Id = Guid.NewGuid(); ;
            format.Name = "FormatName";
            format.StyleClasses = styles;
            Format anotherFormat = new Format();
            anotherFormat.Id = Guid.NewGuid(); 
            anotherFormat.Name = "anotherFormatName";
            format.StyleClasses = new List<StyleClass>();
            Assert.IsFalse(format.Equals(anotherFormat));
        }
        [TestMethod]
        public void TestFormatDifferentButEquals()
        {
            Format format = new Format();
            List<StyleClass> styles = new List<StyleClass>();
            StyleClass style = ExampleInstances.TestStyleClass();
            styles.Add(style);
            format.Id = Guid.NewGuid(); ;
            format.Name = "FormatName";
            format.StyleClasses = styles;
            Format anotherFormat = new Format();
            anotherFormat.Id = format.Id; 
            anotherFormat.Name = "anotherFormatName";
            format.StyleClasses = new List<StyleClass>();
            Assert.IsTrue(format.Equals(anotherFormat));
        }
    }
}
