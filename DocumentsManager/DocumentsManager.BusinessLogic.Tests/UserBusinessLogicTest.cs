using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentsMangerEntities;
using System.Collections.Generic;
using DocumentsManager.Exceptions;

namespace DocumentsManager.BusinessLogic.Tests
{
    [TestClass]
    public class UserBusinessLogicTest
    {
        [TestMethod]
        public void GetChartFromDocumentsEmpty()
        {
            DateTime date1 = new DateTime(2018, 8, 1, 0, 0, 0);
            DateTime date2 = new DateTime(2018, 8, 12, 0, 0, 0);
            UserBusinessLogic logic = new UserBusinessLogic();
            ChartIntDate result = logic.GetChartFromDocuments(new List<Document>(), date1, date2);
            ChartIntDate expected = new ChartIntDate();
            while (DateTime.Compare(date1, date2) < 0)
            {
                expected.AddTuple(0, date1);
                date1 = date1.AddDays(1);
            }
            Assert.IsTrue(expected.Equals(result));
        }
        [TestMethod]
        public void GetChartFromDocuments()
        {
            DateTime date1 = new DateTime(2018, 8, 1, 0, 0, 0);
            DateTime date2 = new DateTime(2018, 8, 12, 0, 0, 0);
            UserBusinessLogic logic = new UserBusinessLogic();
            ChartIntDate result = logic.GetChartFromDocuments(SetUpDocuments(), date1, date2);
            ChartIntDate expected = ExpectedResult(date1);
            expected.AddValueToDate(new DateTime(2018, 8, 5, 0, 0, 0));
            expected.AddValueToDate(new DateTime(2018, 8, 5, 0, 0, 0));
            Assert.IsTrue(expected.Equals(result));
        }
        [TestMethod]
        public void GetChartFromDocumentsWithValueOutOfBounds()
        {
            DateTime date1 = new DateTime(2018, 8, 1, 0, 0, 0);
            DateTime date2 = new DateTime(2018, 8, 12, 0, 0, 0);
            List<Document> documents = SetUpDocuments();
            foreach (var item in documents)
            {
                if (item.CreationDate.Equals(new DateTime(2018, 8, 5, 0, 0, 0)))
                {
                    item.CreationDate = new DateTime(2011, 8, 5, 0, 0, 0);
                }
            }
            ChartIntDate expected = ExpectedResult(date1);
            UserBusinessLogic logic = new UserBusinessLogic();
            ChartIntDate result = logic.GetChartFromDocuments(documents, date1, date2);
            Assert.IsTrue(expected.Equals(result));
        }
        [ExpectedException(typeof(InvalidChartDatesException))]
        [TestMethod]
        public void GetChartFromDocumentsException()
        {
            DateTime date1 = new DateTime(2018, 8, 1, 0, 0, 0);
            DateTime date2 = new DateTime(2018, 1, 12, 0, 0, 0);
            UserBusinessLogic logic = new UserBusinessLogic();
            ChartIntDate result = logic.GetChartFromDocuments(new List<Document>(), date1, date2);
        }
        [TestMethod]
        public void CompareChartsBad()
        {
            DateTime date1 = new DateTime(2018, 8, 1, 0, 0, 0);
            DateTime date2 = new DateTime(2018, 8, 2, 0, 0, 0);
            ChartIntDate expected = ExpectedResult(date1);
            UserBusinessLogic logic = new UserBusinessLogic();
            ChartIntDate result = logic.GetChartFromDocuments(new List<Document>(), date1, date2);
            Assert.IsFalse(expected.Equals(result));
        }
        private ChartIntDate ExpectedResult(DateTime date1)
        {
            ChartIntDate expected = new ChartIntDate();
            for (int i = 0; i < 11; i++)
            {
                if (i == 2)
                {
                    expected.AddTuple(3, date1);
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
        private List<Document> SetUpDocuments()
        {
            Document newDocument = new Document();
            newDocument.CreationDate = new DateTime(2018, 8, 3, 0, 0, 0);
            Document anotherDocument = new Document();
            anotherDocument.CreationDate = new DateTime(2018, 8, 5, 0, 0, 0);
            Document lastDocument = new Document();
            lastDocument.CreationDate = new DateTime(2018, 8, 6, 0, 0, 0);
            List<Document> documents = new List<Document>();
            documents.Add(newDocument);
            documents.Add(anotherDocument);
            documents.Add(lastDocument);
            documents.Add(newDocument);
            documents.Add(anotherDocument);
            documents.Add(newDocument);
            return documents;
        }
    }
}
