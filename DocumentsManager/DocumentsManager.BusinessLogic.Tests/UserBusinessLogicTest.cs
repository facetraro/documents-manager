﻿using System;
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
            AdminUser admin = new AdminUser
            {
                Id = Guid.NewGuid(),
                Email = "test@email.com",
                Name = "testName",
                Password = "testPassword",
                Surname = "testSurname",
                Username = "testUsername"
            };
            AdminBusinessLogic adminLogic = new AdminBusinessLogic();
            adminLogic.Add(admin);
            logic.AddDocument(aDocument, admin);
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
        public void AddDocumentTest()
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
        [TestMethod]
        public void ModifyTitleDocumentTest()
        {
            StyleClassContextHandler styleCtx = new StyleClassContextHandler();
            FormatContext formatCtx = new FormatContext();
            Document aDocument = setUpAllSameStyle(formatCtx, styleCtx);
            aDocument.Title = "new Title";
            DocumentBusinessLogic documentLogic = new DocumentBusinessLogic();
            UserBusinessLogic logic = new UserBusinessLogic();
            UserContext uContext = new UserContext();
            AdminUser admin = new AdminUser
            {
                Id = Guid.NewGuid(),
                Email = "modifier@email.com",
                Name = "testName",
                Password = "testPassword",
                Surname = "testSurname",
                Username = "modifierUsername"
            };
            uContext.Add(admin);
            logic.ModifyDocumentTitle(aDocument, admin);
            Assert.IsTrue(documentLogic.GetDocumentById(aDocument.Id).Title.Equals("new Title"));
            TearDown();
        }
        [TestMethod]
        public void ModifyParragraphsDocumentTest()
        {
            StyleClassContextHandler styleCtx = new StyleClassContextHandler();
            FormatContext formatCtx = new FormatContext();
            Document aDocument = setUpAllSameStyle(formatCtx, styleCtx);
            Text modifiedText = new Text
            {
                Id = Guid.NewGuid(),
                StyleClass = aDocument.StyleClass,
                WrittenText = "MODIFIED"
            };
            List<Text> texts = new List<Text>();
            texts.Add(modifiedText);
            Parragraph parragraph = new Parragraph
            {
                Id = Guid.NewGuid(),
                Document = aDocument,
                StyleClass = aDocument.StyleClass,
                Texts = texts
            };
            UserContext uContext = new UserContext();
            AdminUser admin = new AdminUser
            {
                Id = Guid.NewGuid(),
                Email = "modifier@email.com",
                Name = "testName",
                Password = "testPassword",
                Surname = "testSurname",
                Username = "modifierUsername"
            };
            uContext.Add(admin);
            List<Parragraph> parragraphs = new List<Parragraph>();
            parragraphs.Add(parragraph);
            aDocument.Parragraphs = parragraphs;
            UserBusinessLogic logic = new UserBusinessLogic();
            logic.ModifyParragraphs(aDocument, admin);
            
            DocumentBusinessLogic documentLogic = new DocumentBusinessLogic();
            Assert.IsTrue(documentLogic.GetDocumentById(aDocument.Id).Parragraphs.Count==1);
            Assert.IsTrue(documentLogic.GetDocumentById(aDocument.Id).Parragraphs.ElementAt(0).Equals(parragraph));
            TearDown();
        }
        [TestMethod]
        public void ModifyParragraphsDocumentTestTwice()
        {
            StyleClassContextHandler styleCtx = new StyleClassContextHandler();
            FormatContext formatCtx = new FormatContext();
            Document aDocument = setUpAllSameStyle(formatCtx, styleCtx);
            Text modifiedText = new Text
            {
                Id = Guid.NewGuid(),
                StyleClass = aDocument.StyleClass,
                WrittenText = "MODIFIED"
            };
            List<Text> texts = new List<Text>();
            texts.Add(modifiedText);
            Parragraph parragraph = new Parragraph
            {
                Id = Guid.NewGuid(),
                Document = aDocument,
                StyleClass = aDocument.StyleClass,
                Texts = texts
            };
            UserContext uContext = new UserContext();
            AdminUser admin = new AdminUser
            {
                Id = Guid.NewGuid(),
                Email = "modifier@email.com",
                Name = "testName",
                Password = "testPassword",
                Surname = "testSurname",
                Username = "modifierUsername"
            };
            uContext.Add(admin);
            List<Parragraph> parragraphs = new List<Parragraph>();
            parragraphs.Add(parragraph);
            aDocument.Parragraphs = parragraphs;
            UserBusinessLogic logic = new UserBusinessLogic();
            logic.ModifyParragraphs(aDocument, admin);
            aDocument.Parragraphs = new List<Parragraph>();
            logic.ModifyParragraphs(aDocument, admin);

            DocumentBusinessLogic documentLogic = new DocumentBusinessLogic();
            Assert.IsTrue(documentLogic.GetDocumentById(aDocument.Id).Parragraphs.Count == 0);
            TearDown();
        }
    }
}