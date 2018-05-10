using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentsMangerEntities;
using System.Collections.Generic;
using DocumentsManager.Exceptions;
using DocumentsManager.Data.DA.Handler;
using DocumentsManagerDATesting;
using DocumentsManagerExampleInstances;
using System.Linq;

namespace DocumentsManager.BusinessLogic.Tests
{
    [TestClass]
    public class DocumentBusinessLogicTest
    {
        public void TearDown() {
            ClearDataBase.ClearAll();
        }
        public Document InitializeDocumentDataBase(DocumentContext context) {
            ClearDataBase.ClearAll();
            FormatContext contextFormat = new FormatContext();
            HeaderContext hContext = new HeaderContext();
            FooterContext fContext = new FooterContext();
            TextContext tContext = new TextContext();
            Document newDocument = EntitiesExampleInstances.TestDocument();
            newDocument.Title = "PrintableDocument";
            newDocument.Header.Text.WrittenText = "HEADER";
            newDocument.Footer.Text.WrittenText = "FOOTER";
            StyleClass style = EntitiesExampleInstances.TestStyleClass();
            StyleClassContextHandler contextsc = new StyleClassContextHandler();
            UserContext uContext = new UserContext();
            User creatorUser = EntitiesExampleInstances.TestAdminUser();
            uContext.Add(creatorUser);
            contextsc.Add(style);
            contextsc.Add(newDocument.Footer.StyleClass);
            contextsc.Add(newDocument.Header.StyleClass);
            foreach (var item in newDocument.Format.StyleClasses)
            {
                contextsc.Add(item);
            }
            contextFormat.Add(newDocument.Format);
            foreach (var item in newDocument.Parragraphs)
            {
                contextsc.Add(item.StyleClass);
            }
            newDocument.StyleClass = style;
            newDocument.Parragraphs.ElementAt(0).Document = newDocument;
            context.Add(newDocument);
            Format format = contextFormat.GetById(newDocument.Format.Id);
            Header header = hContext.GetById(newDocument.Header.Id);
            Footer footer = fContext.GetById(newDocument.Footer.Id);
            Text footerText = tContext.GetById(footer.Text.Id);
            //Add to format styles of header and footer Text.
            format.StyleClasses.Add(header.StyleClass);
            format.StyleClasses.Add(footerText.StyleClass);
            contextFormat.Modify(format);
            return context.GetById(newDocument.Id);
        }
        [TestMethod]
        public void GetDocumentByIdTest()
        {
            DocumentContext contextDocument = new DocumentContext();
            DocumentContextTest testDocument = new DocumentContextTest();
            Document document = testDocument.setUp(contextDocument);
            DocumentBusinessLogic logic = new DocumentBusinessLogic();
            Document fullDocument = logic.GetDocumentById(document.Id);
            Assert.IsFalse(fullDocument.Footer.Text == null);
            Assert.IsFalse(fullDocument.Footer.StyleClass == null);
            Assert.IsFalse(fullDocument.Header.Text == null);
            Assert.IsFalse(fullDocument.Header.StyleClass == null);
            Assert.IsFalse(fullDocument.Parragraphs[0].StyleClass == null);
            Assert.IsFalse(fullDocument.Parragraphs[0].Texts == null);
            Assert.IsFalse(fullDocument.Format.StyleClasses == null);
            TearDown();
        }

        [TestMethod]
        public void PrintDocumentTest()
        {
            DocumentBusinessLogic documentBL = new DocumentBusinessLogic();
            StyleClassBusinessLogic styleClassBL = new StyleClassBusinessLogic();
            DocumentContextTest test = new DocumentContextTest();
            DocumentContext dContext = new DocumentContext();
            FooterContext fContext = new FooterContext();
            HeaderContext hContext = new HeaderContext();
            ParragraphContext pContext = new ParragraphContext();
            TextContext tContext = new TextContext();
            Document testDocument = dContext.GetById(test.setUp(dContext).Id);
            Header header = hContext.GetById(testDocument.Header.Id);
            Footer footer = fContext.GetById(testDocument.Footer.Id);
            string parragraphText = "DefaultText";
            string parragraph = "<br>" + styleClassBL.GetHtmlText(new StyleClass(), parragraphText);
            string printedDocument = documentBL.PrintDocument(testDocument);
            string openHtml = "<html>";
            string openBody = "<body>";
            string documentTitle = "<title>" + testDocument.Title + "</title>";
            string headerText = "<head>" + styleClassBL.GetHtmlText(new StyleClass(), header.Text.WrittenText) + "</head>";
            string footerText = "<footer>" + styleClassBL.GetHtmlText(new StyleClass(), footer.Text.WrittenText) + "</footer>";
            string closeHtml = "</html>";
            string closeBody = "</body>";
            string expectedResult = openHtml + openBody + documentTitle + headerText + parragraph + footerText + closeBody + closeHtml;
            Assert.AreEqual(printedDocument, expectedResult);
            TearDown();
        }
        [TestMethod]
        public void PrintCompleteDocumentTest()
        {
            DocumentBusinessLogic documentBL = new DocumentBusinessLogic();
            StyleClassBusinessLogic styleClassBL = new StyleClassBusinessLogic();
            DocumentContextTest test = new DocumentContextTest();
            DocumentContext dContext = new DocumentContext();
            FooterContext fContext = new FooterContext();
            HeaderContext hContext = new HeaderContext();
            ParragraphContext pContext = new ParragraphContext();
            TextContext tContext = new TextContext();
            Document testDocument = dContext.GetById(InitializeDocumentDataBase(dContext).Id);
            Header header = hContext.GetById(testDocument.Header.Id);
            Footer footer = fContext.GetById(testDocument.Footer.Id);
            string parragraphText = "DefaultText";
            string parragraph = "<br>" + styleClassBL.GetHtmlText(new StyleClass(), parragraphText) ;
            string printedDocument = documentBL.PrintDocument(testDocument);
            string expectedResult = "<html><body><title>PrintableDocument</title><head><p style=\" text-align: center ;  color: red ;  text-decoration: underline ;  font-size: 10pt; font-family: arial ; \"><em><strong>HEADER</em></strong></p></head><br><p>DefaultText</p><footer><p style=\" text-align: center ;  color: red ;  text-decoration: underline ;  font-size: 10pt; font-family: arial ; \"><em><strong>FOOTER</em></strong></p></footer></body></html>";
            Assert.AreEqual(printedDocument.Trim(), expectedResult.Trim());
            TearDown();
        }

    }
}
