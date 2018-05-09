using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentsMangerEntities;
using System.Collections.Generic;
using DocumentsManager.Exceptions;
using DocumentsManager.Data.DA.Handler;
using DocumentsManagerDATesting;

namespace DocumentsManager.BusinessLogic.Tests
{
    [TestClass]
    public class DocumentBusinessLogicTest
    {
        [TestMethod]
        public void GetChartFromDocumentEmpty()
        {
            DateTime date1 = new DateTime(2018, 8, 1, 0, 0, 0);
            DateTime date2 = new DateTime(2018, 8, 12, 0, 0, 0);
            DocumentBusinessLogic logic = new DocumentBusinessLogic();
            ChartIntDate result = logic.GetChartFromDocument(new List<DateTime>(), date1, date2);
            ChartIntDate expected = new ChartIntDate();
            while (DateTime.Compare(date1, date2) < 0)
            {
                expected.AddTuple(0, date1);
                date1 = date1.AddDays(1);
            }
            Assert.IsTrue(expected.Equals(result));
        }
        [TestMethod]
        public void GetChartFromDocumentTest()
        {
            DateTime date1 = new DateTime(2018, 8, 1, 0, 0, 0);
            DateTime date2 = new DateTime(2018, 8, 12, 0, 0, 0);
            DocumentBusinessLogic logic = new DocumentBusinessLogic();
            ChartIntDate result = logic.GetChartFromDocument(SetUpDates(), date1, date2);
            ChartIntDate expected = ExpectedResult(date1);
            Assert.IsTrue(expected.Equals(result));
        }
        [TestMethod]
        public void GetChartFromDocumentWithValueOutOfBounds()
        {
            DateTime date1 = new DateTime(2018, 8, 1, 0, 0, 0);
            DateTime date2 = new DateTime(2018, 8, 12, 0, 0, 0);
            List<DateTime> allDates = SetUpDates();
            allDates.Add(new DateTime(2011, 8, 12, 0, 0, 0));
            ChartIntDate expected = ExpectedResult(date1);
            DocumentBusinessLogic logic = new DocumentBusinessLogic();
            ChartIntDate result = logic.GetChartFromDocument(allDates, date1, date2);
            Assert.IsTrue(expected.Equals(result));
        }
        [TestMethod]
        public void GetDocumentByIdTest()
        {
            DocumentContext contextDocument = new DocumentContext();
            DocumentContextTest testDocument = new DocumentContextTest();
            Document document = testDocument.setUp(contextDocument);
            DocumentBusinessLogic logic = new DocumentBusinessLogic();
            Document fullDocument = logic.GetDocumentById(document.Id);
            Assert.IsFalse(fullDocument.CreatorUser == null);
            Assert.IsFalse(fullDocument.Footer.Text == null);
            Assert.IsFalse(fullDocument.Footer.StyleClass == null);
            Assert.IsFalse(fullDocument.Header.Text == null);
            Assert.IsFalse(fullDocument.Header.StyleClass == null);
            Assert.IsFalse(fullDocument.Parragraphs[0].StyleClass == null);
            Assert.IsFalse(fullDocument.Parragraphs[0].Texts == null);
            Assert.IsFalse(fullDocument.Format.StyleClasses == null);
        }
        [ExpectedException(typeof(InvalidChartDatesException))]
        [TestMethod]
        public void GetChartFromDocumentException()
        {
            DateTime date1 = new DateTime(2018, 8, 1, 0, 0, 0);
            DateTime date2 = new DateTime(2018, 1, 12, 0, 0, 0);
            DocumentBusinessLogic logic = new DocumentBusinessLogic();
            ChartIntDate result = logic.GetChartFromDocument(new List<DateTime>(), date1, date2);
        }
        private ChartIntDate ExpectedResult(DateTime date1)
        {
            ChartIntDate expected = new ChartIntDate();
            for (int i = 0; i < 11; i++)
            {
                if (i == 2)
                {
                    expected.AddTuple(2, date1);
                }
                else if (i == 5)
                {
                    expected.AddTuple(1, date1);
                }
                else
                {
                    expected.AddTuple(0, date1);
                }
                date1 = date1.AddDays(1);
            }
            return expected;
        }
        private List<DateTime> SetUpDates()
        {
            List<DateTime> dates = new List<DateTime>();
            DateTime newDate = new DateTime(2018, 8, 3, 0, 0, 0);
            DateTime anotherDate = new DateTime(2018, 8, 6, 0, 0, 0);
            dates.Add(newDate);
            dates.Add(newDate);
            dates.Add(anotherDate);
            return dates;
        }
    }
}
