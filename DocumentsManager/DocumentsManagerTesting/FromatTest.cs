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
            StyleClass style = TestStyleClass();
            styles.Add(style);
            Format format = new Format();
            format.Id = Id;
            format.Name = name;
            format.StyleClasses = styles;
            Assert.AreEqual(format.Id,Id);
            Assert.AreEqual(format.Name,name);
            Assert.AreEqual(format.StyleClass,styles);
        }
        [TestMethod]
        public void TestFormatBuilderNotSame()
        {
            Guid Id = Guid.NewGuid();
            string name = "FormatName";
            List<StyleClass> styles = new List<StyleClass>();
            StyleClass style = TestStyleClass();
            styles.Add(style);
            Format format = new Format();
            format.Id = Id;
            format.Name = name;
            format.StyleClasses = styles;
            Assert.AreNotEqual(format.Id, Guid.NewGuid);
            Assert.AreNotEqual(format.Name, "anotherName");
            Assert.AreNotEqual(format.StyleClass, new List<StyleClass>());
        }
    }
}
