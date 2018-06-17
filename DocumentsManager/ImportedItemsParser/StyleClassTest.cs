using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentsManager.FormatImportation;
using DocumentsMangerEntities;
using DocumentsManager.ImportedItemsParser;
using DocumentsManager.Exceptions;

namespace ImportedItemsParser
{
    [TestClass]
    public class StyleClassTest
    {
        private static string Type = "TipoLetra";
        private static string FontSize = "TamanioLetra";
        private static string Italics = "Cursiva";
        private static string Aligment = "Alineacion";
        private static string Color = "Color";
        private static string Border = "Borde";
        private static string Bold = "Negrita";
        private static string Underlined = "Subrayado";
        [TestMethod]
        public void SimpleStyleClassTest()
        {
            ImportedStyleClass importedStyleClass = new ImportedStyleClass();
            importedStyleClass.Name = "ExampleName";
            StyleClass style = StyleClassParser.Parse(importedStyleClass);
            Assert.AreEqual(style.Name, importedStyleClass.Name);
            Assert.AreEqual(style.Attributes.Count, 0);
        }
        [TestMethod]
        public void AdvancedStyleClassTest()
        {
            ImportedStyleClass importedStyleClass = new ImportedStyleClass();
            importedStyleClass.Name = "ExampleName";
            importedStyleClass.StyleAttributes.Add(Type+"###arial");
            importedStyleClass.StyleAttributes.Add(FontSize + "###2");
            importedStyleClass.StyleAttributes.Add(Aligment + "###justificado");
            importedStyleClass.StyleAttributes.Add(Color + "###0,0,128");
            importedStyleClass.StyleAttributes.Add(Underlined);
            StyleClass style = StyleClassParser.Parse(importedStyleClass);  
            Assert.AreEqual(style.Name, importedStyleClass.Name);
            Assert.AreEqual(style.Attributes.Count, 5);
        }
        [TestMethod]
        public void SecondAdvancedStyleClassTest()
        {
            ImportedStyleClass importedStyleClass = new ImportedStyleClass();
            importedStyleClass.Name = "ExampleName";
            importedStyleClass.StyleAttributes.Add(Type + "###timesnewroman");
            importedStyleClass.StyleAttributes.Add(FontSize + "###10");
            importedStyleClass.StyleAttributes.Add(Aligment + "###izquierda");
            importedStyleClass.StyleAttributes.Add(Color + "###0,0,0");
            importedStyleClass.StyleAttributes.Add(Bold);
            StyleClass style = StyleClassParser.Parse(importedStyleClass);
            Assert.AreEqual(style.Name, importedStyleClass.Name);
            Assert.AreEqual(style.Attributes.Count, 5);
        }
        [TestMethod]
        public void ThirdAdvancedStyleClassTest()
        {
            ImportedStyleClass importedStyleClass = new ImportedStyleClass();
            importedStyleClass.Name = "ExampleName";
            importedStyleClass.StyleAttributes.Add(Type + "###courier-new");
            importedStyleClass.StyleAttributes.Add(FontSize + "###12");
            importedStyleClass.StyleAttributes.Add(Aligment + "###centrado");
            importedStyleClass.StyleAttributes.Add(Color + "###128,0,0");
            importedStyleClass.StyleAttributes.Add(Italics);
            importedStyleClass.StyleAttributes.Add(Border);
            StyleClass style = StyleClassParser.Parse(importedStyleClass);
            Assert.AreEqual(style.Name, importedStyleClass.Name);
            Assert.AreEqual(style.Attributes.Count, 6);
        }
        [ExpectedException(typeof(StyleAttributeNotRecognized))]
        [TestMethod]
        public void StyleClassTestBadFontType()
        {
            ImportedStyleClass importedStyleClass = new ImportedStyleClass();
            importedStyleClass.Name = "ExampleName";
            importedStyleClass.StyleAttributes.Add(Type + "###new-font");
            StyleClass style = StyleClassParser.Parse(importedStyleClass);
        }
        [ExpectedException(typeof(StyleAttributeNotRecognized))]
        [TestMethod]
        public void StyleClassTestBadFontSize()
        {
            ImportedStyleClass importedStyleClass = new ImportedStyleClass();
            importedStyleClass.Name = "ExampleName";
            importedStyleClass.StyleAttributes.Add(FontSize + "###five");
            StyleClass style = StyleClassParser.Parse(importedStyleClass);
        }
        [ExpectedException(typeof(StyleAttributeNotRecognized))]
        [TestMethod]
        public void StyleClassTestBadAlignment()
        {
            ImportedStyleClass importedStyleClass = new ImportedStyleClass();
            importedStyleClass.Name = "ExampleName";
            importedStyleClass.StyleAttributes.Add(Aligment + "###top");
            StyleClass style = StyleClassParser.Parse(importedStyleClass);
        }
        [ExpectedException(typeof(StyleAttributeNotRecognized))]
        [TestMethod]
        public void StyleClassTestBadColor()
        {
            ImportedStyleClass importedStyleClass = new ImportedStyleClass();
            importedStyleClass.Name = "ExampleName";
            importedStyleClass.StyleAttributes.Add(Color + "###120,134,3");
            StyleClass style = StyleClassParser.Parse(importedStyleClass);
        }
    }
}
