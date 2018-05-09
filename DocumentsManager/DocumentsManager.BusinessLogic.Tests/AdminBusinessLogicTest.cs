using DocumentsManager.Data.DA.Handler;
using DocumentsManager.Exceptions;
using DocumentsManagerDATesting;
using DocumentsManagerExampleInstances;
using DocumentsMangerEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.BusinessLogic.Tests
{
    [TestClass]
    public class AdminBusinessLogicTest
    {
        public void TearDown()
        {
            ClearDataBase.ClearAll();
        }
        [TestMethod]
        public void GetAdminsTest()
        {
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            UserContext uContext = new UserContext();
            AdminUser anAdmin = EntitiesExampleInstances.TestAdminUser();
            uContext.Add(anAdmin);
            bool expectedResult = true;
            bool result = adminBL.GetAllAdmins().Contains(anAdmin);
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [TestMethod]
        public void GetAdminsTestSeveral()
        {
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            UserContext uContext = new UserContext();
            AdminUser anAdmin = EntitiesExampleInstances.TestAdminUser();
            AdminUser anotherAdmin = EntitiesExampleInstances.TestAdminUser();
            uContext.Add(anAdmin);
            uContext.Add(anotherAdmin);
            bool expectedResult = true;
            IEnumerable<AdminUser> allAdmins = adminBL.GetAllAdmins();
            bool resultOne = allAdmins.Contains(anAdmin);
            bool resultTwo = allAdmins.Contains(anotherAdmin);
            Assert.AreEqual(expectedResult, resultOne && resultTwo);
            TearDown();
        }
        [TestMethod]
        public void GetAdminsTestEmpty()
        {
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            bool expectedResult = true;
            bool result = adminBL.GetAllAdmins().Count() == 0;
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [TestMethod]
        public void GetChartFromDatesEmpty()
        {
            DateTime date1 = new DateTime(2018, 8, 1, 0, 0, 0);
            DateTime date2 = new DateTime(2018, 8, 12, 0, 0, 0);
            AdminBusinessLogic logic = new AdminBusinessLogic();
            ChartIntDate result = logic.GetChartFromDates(new List<DateTime>(), date1, date2);
            ChartIntDate expected = new ChartIntDate();
            while (DateTime.Compare(date1, date2) < 0)
            {
                expected.AddTuple(0, date1);
                date1 = date1.AddDays(1);
            }
            Assert.IsTrue(expected.Equals(result));
        }
        [TestMethod]
        public void GetChartFromDates()
        {
            DateTime date1 = new DateTime(2018, 8, 1, 0, 0, 0);
            DateTime date2 = new DateTime(2018, 8, 12, 0, 0, 0);
            AdminBusinessLogic logic = new AdminBusinessLogic();
            List<DateTime> dates = new List<DateTime>();
            dates.Add(new DateTime(2018, 8, 1, 0, 0, 0));
            dates.Add(new DateTime(2018, 8, 1, 0, 0, 0));
            ChartIntDate result = logic.GetChartFromDates(dates, date1, date2);
            ChartIntDate expected = new ChartIntDate();
            expected.AddTuple(2, date1);
            date1 = date1.AddDays(1);
            while (DateTime.Compare(date1, date2) < 0)
            {
                expected.AddTuple(0, date1);
                date1 = date1.AddDays(1);
            }
            Assert.IsTrue(expected.Equals(result));
        }
        [ExpectedException(typeof(InvalidChartDatesException))]
        [TestMethod]
        public void GetChartFromDatesException()
        {
            DateTime date1 = new DateTime(2018, 8, 1, 0, 0, 0);
            DateTime date2 = new DateTime(2017, 8, 12, 0, 0, 0);
            AdminBusinessLogic logic = new AdminBusinessLogic();
            ChartIntDate result = logic.GetChartFromDates(new List<DateTime>(), date1, date2);
        }
        [TestMethod]
        public void GetChartCreationByUserEmpty()
        {
            DateTime date1 = new DateTime(2018, 8, 1, 0, 0, 0);
            DateTime date2 = new DateTime(2018, 8, 12, 0, 0, 0);
            AdminBusinessLogic logic = new AdminBusinessLogic();
            ChartIntDate result = logic.GetChartCreationByUser(new AdminUser(), date1, date2);
            ChartIntDate expected = new ChartIntDate();
            while (DateTime.Compare(date1, date2) < 0)
            {
                expected.AddTuple(0, date1);
                date1 = date1.AddDays(1);
            }
            Assert.IsTrue(expected.Equals(result));
        }
        [TestMethod]
        public void GetChartCreationByUser()
        {
            DateTime date1 = DateTime.Today;
            DateTime date2 = DateTime.Today.AddDays(10);
            UserBusinessLogic userLogic = new UserBusinessLogic();
            DocumentContextTest documentContext = new DocumentContextTest();
            DocumentContext context = new DocumentContext();
            UserContext userContext = new UserContext();
            User newUser = EntitiesExampleInstances.TestAdminUser();
            userContext.Add(newUser);
            DocumentBusinessLogic documentLogic = new DocumentBusinessLogic();
            Document documentInBD = documentContext.setUp(context);
            userLogic.ModifyDocument(newUser, documentInBD, ModifyState.Added);
            AdminBusinessLogic logic = new AdminBusinessLogic();
            ChartIntDate result = logic.GetChartCreationByUser(newUser, date1, date2);
            ChartIntDate expected = new ChartIntDate();
            expected.AddTuple(1, date1);
            date1 = date1.AddDays(1);
            while (DateTime.Compare(date1, date2) < 0)
            {
                expected.AddTuple(0, date1);
                date1 = date1.AddDays(1);
            }
            Assert.IsTrue(expected.Equals(result));
            TearDown();
        }
        [TestMethod]
        public void GetChartModificationsByUser()
        {
            DateTime date1 = DateTime.Today;
            DateTime date2 = DateTime.Today.AddDays(10);
            UserBusinessLogic userLogic = new UserBusinessLogic();
            DocumentContextTest documentContext = new DocumentContextTest();
            DocumentContext context = new DocumentContext();
            UserContext userContext = new UserContext();
            User newUser = EntitiesExampleInstances.TestAdminUser();
            userContext.Add(newUser);
            DocumentBusinessLogic documentLogic = new DocumentBusinessLogic();
            Document documentInBD = documentContext.setUp(context);
            userLogic.ModifyDocument(newUser, documentInBD, ModifyState.Added);
            AdminBusinessLogic logic = new AdminBusinessLogic();
            ChartIntDate result = logic.GetChartModificationsByUser(newUser, date1, date2);
            ChartIntDate expected = new ChartIntDate();
            expected.AddTuple(1, date1);
            date1 = date1.AddDays(1);
            while (DateTime.Compare(date1, date2) < 0)
            {
                expected.AddTuple(0, date1);
                date1 = date1.AddDays(1);
            }
            Assert.IsTrue(expected.Equals(result));
            TearDown();
        }
        [TestMethod]
        public void GetChartCreationByUserAdvanced()
        {
            DateTime date1 = DateTime.Today;
            DateTime date2 = DateTime.Today.AddDays(10);
            UserBusinessLogic userLogic = new UserBusinessLogic();
            DocumentContextTest documentContext = new DocumentContextTest();
            DocumentContext context = new DocumentContext();
            UserContext userContext = new UserContext();
            User newUser = EntitiesExampleInstances.TestAdminUser();
            userContext.Add(newUser);
            DocumentBusinessLogic documentLogic = new DocumentBusinessLogic();
            Document documentInBD = documentContext.setUp(context);
            Document anotherDocumentInBD = documentContext.setUp(context);
            userLogic.ModifyDocument(newUser, documentInBD, ModifyState.Added);
            userLogic.ModifyDocument(newUser, documentInBD, ModifyState.Modified);
            userLogic.ModifyDocument(newUser, anotherDocumentInBD, ModifyState.Added);
            AdminBusinessLogic logic = new AdminBusinessLogic();
            ChartIntDate result = logic.GetChartCreationByUser(newUser, date1, date2);
            ChartIntDate expected = new ChartIntDate();
            expected.AddTuple(2, date1);
            date1 = date1.AddDays(1);
            while (DateTime.Compare(date1, date2) < 0)
            {
                expected.AddTuple(0, date1);
                date1 = date1.AddDays(1);
            }
            Assert.IsTrue(expected.Equals(result));
            TearDown();
        }
        [TestMethod]
        public void GetChartModificationsByUserAdvanced()
        {
            DateTime date1 = DateTime.Today;
            DateTime date2 = DateTime.Today.AddDays(10);
            AdminBusinessLogic logic = new AdminBusinessLogic();
            ChartIntDate result = logic.GetChartModificationsByUser(SetUpChart(ModifyState.Modified), date1, date2);
            ChartIntDate expected = new ChartIntDate();
            expected.AddTuple(3, date1);
            date1 = date1.AddDays(1);
            while (DateTime.Compare(date1, date2) < 0)
            {
                expected.AddTuple(0, date1);
                date1 = date1.AddDays(1);
            }
            Assert.IsTrue(expected.Equals(result));
            TearDown();
        }
        [TestMethod]
        public void GetChartRemovedByUserAdvanced()
        {
            DateTime date1 = DateTime.Today;
            DateTime date2 = DateTime.Today.AddDays(10);
            AdminBusinessLogic logic = new AdminBusinessLogic();
            ChartIntDate result = logic.GetChartModificationsByUser(SetUpChart(ModifyState.Removed), date1, date2);
            ChartIntDate expected = new ChartIntDate();
            expected.AddTuple(3, date1);
            date1 = date1.AddDays(1);
            while (DateTime.Compare(date1, date2) < 0)
            {
                expected.AddTuple(0, date1);
                date1 = date1.AddDays(1);
            }
            Assert.IsTrue(expected.Equals(result));
            TearDown();
        }
        private User SetUpChart(ModifyState state)
        {
            UserBusinessLogic userLogic = new UserBusinessLogic();
            DocumentContextTest documentContext = new DocumentContextTest();
            DocumentContext context = new DocumentContext();
            UserContext userContext = new UserContext();
            User newUser = EntitiesExampleInstances.TestAdminUser();
            userContext.Add(newUser);
            DocumentBusinessLogic documentLogic = new DocumentBusinessLogic();
            Document documentInBD = documentContext.setUp(context);
            Document anotherDocumentInBD = documentContext.setUp(context);
            userLogic.ModifyDocument(newUser, documentInBD, ModifyState.Added);
            userLogic.ModifyDocument(newUser, documentInBD, state);
            userLogic.ModifyDocument(newUser, anotherDocumentInBD, ModifyState.Added);
            return newUser;
        }
    }
}
