using DocumentsManager.FormatImportation;
using DocumentsManager.ImportedItemsParser;
using DocumentsManagerExampleInstances;
using DocumentsMangerEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.ImportedItemsParser
{

    [TestClass]
    public class FormatParserTest
    {
        private ImportedFormat ImportedFormatSetUp()
        {
            Format exampleFormat = FormatSetUp();
            ImportedFormat format = new ImportedFormat();
            format.Name = exampleFormat.Name;
            ImportedStyleClass exampleStyleClassOne = new ImportedStyleClass();
            exampleStyleClassOne.Name = "Example";
            exampleStyleClassOne.StyleAttributes.Add("Alineacion###derecha");
            ImportedStyleClass exampleStyleClassTwo = new ImportedStyleClass();
            exampleStyleClassTwo.Name = "AnotherExample";
            format.Styles.Add(exampleStyleClassOne);
            format.Styles.Add(exampleStyleClassTwo);
            return format;
        }
        private Format FormatSetUp()
        {
            return EntitiesExampleInstances.TestFormat();
        }
        [TestMethod]
        public void ParseSimpleFormat()
        {
            ImportedFormat importedFormat = new ImportedFormat();
            importedFormat.Name = "ExampleName";
            Format format = FormatParser.Parse(importedFormat);
            Assert.AreEqual(format.Name, importedFormat.Name);
            Assert.AreEqual(format.StyleClasses.Count, 0);
        }
        [TestMethod]
        public void ParseFormatWithStyleClass()
        {
            ImportedFormat importedFormat = ImportedFormatSetUp();
            Format format = FormatParser.Parse(importedFormat);
            Assert.AreEqual(format.Name, importedFormat.Name);
            Assert.AreEqual(format.StyleClasses.Count, 2);
        }

    }
}
