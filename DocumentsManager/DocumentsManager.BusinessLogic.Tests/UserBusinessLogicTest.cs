using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentsMangerEntities;
using System.Collections.Generic;
using DocumentsManager.Exceptions;
using DocumentsManagerDATesting;
using DocumentsManager.Data.DA.Handler;
using System.Linq;

namespace DocumentsManager.BusinessLogic.Tests
{
    [TestClass]
    public class UserBusinessLogicTest
    {
        public void TearDown()
        {
            ClearDataBase.ClearAll();
        }
        public Document setUpAllSameStyle(FormatContext formatCtx, StyleClassContextHandler styleCtx)
        {
            TearDown();
            StyleClass style = new StyleClass
            {
                Name = "StyleTest",
                Id = Guid.NewGuid(),
                Attributes = new List<StyleAttribute>(),
                Based = null,
            };
            styleCtx.Add(style);
            Format format = new Format
            {
                Name = "formatTest",
                Id = Guid.NewGuid(),
                StyleClasses = new List<StyleClass>()
            };
            formatCtx.Add(format);
            Text footerText = CreateText(style);
            Text headerText = CreateText(style);
            Footer aFooter = new Footer
            {
                Id = Guid.NewGuid(),
                StyleClass = style,
                Text = footerText
            };
            Header aHeader = new Header
            {
                Id = Guid.NewGuid(),
                StyleClass = style,
                Text = headerText
            };
            List<Text> p1Texts = new List<Text>();
            p1Texts.Add(CreateText(style));
            Parragraph parragraph1 = new Parragraph
            {
                Id = Guid.NewGuid(),
                Document = null,
                StyleClass = style,
                Texts = p1Texts
            };
            List<Text> p2Texts = new List<Text>();
            p2Texts.Add(CreateText(style));
            p2Texts.Add(CreateText(style));
            Parragraph parragraph2 = new Parragraph
            {
                Id = Guid.NewGuid(),
                Document = null,
                StyleClass = style,
                Texts = p2Texts
            };
            List<Parragraph> parragraphs = new List<Parragraph>();
            parragraphs.Add(parragraph1);
            parragraphs.Add(parragraph2);
            Document aDocument = new Document
            {
                Id = Guid.NewGuid(),
                Footer = aFooter,
                Format = format,
                Header = aHeader,
                Parragraphs = parragraphs,
                StyleClass = style,
                Title = "Test Title"
            };
            UserBusinessLogic logic = new UserBusinessLogic();
            logic.AddDocument(aDocument);
            return aDocument;
        }

        public Text CreateText(StyleClass style)
        {
            Text testText = new Text
            {
                Id = Guid.NewGuid(),
                StyleClass = style,
                WrittenText = "TESTTEXT"
            };
            return testText;
        }
        [TestMethod]
        public void AddDocument()
        {
            StyleClassContextHandler styleCtx = new StyleClassContextHandler();
            FormatContext formatCtx = new FormatContext();
            Document aDocument = setUpAllSameStyle(formatCtx, styleCtx);
            DocumentBusinessLogic documentLogic = new DocumentBusinessLogic();
            IEnumerable<Document> allDocuments = documentLogic.GetAllDocuments();
            Assert.IsTrue(allDocuments.Contains(aDocument));
            Assert.IsTrue(allDocuments.Count() == 1);
            TearDown();
        }

    }
}