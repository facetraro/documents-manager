using DocumentsManager.Data.Logger;
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
    public class LoggerMethodBusinessLogicTest
    {
        private LoggerMethod loggerBL = new LoggerMethod();
        public void TearDown()
        {
            ClearDataBase.ClearAll();
        }
        [TestMethod]
        public void testGetLogs()
        {
            TearDown();
            AdminBusinessLogic abl = new AdminBusinessLogic();
            AdminUser logged = EntitiesExampleInstances.TestAdminUser();
            abl.AddAdmin(logged, Guid.NewGuid());
            LoggerType log = new LoggerType();
            log.Action = ActionType.LogIn;
            log.UserBy = logged.Username;
            loggerBL.AddLogger(log);
            List<LoggerType> result = loggerBL.GetLoggers(new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day - 1), DateTime.Today.AddDays(1));
            Assert.AreEqual(result.Count, 1);
            TearDown();
        }
        [TestMethod]
        public void testGetLogsAfter()
        {
            TearDown();
            AdminBusinessLogic abl = new AdminBusinessLogic();
            AdminUser logged = EntitiesExampleInstances.TestAdminUser();
            abl.AddAdmin(logged, Guid.NewGuid());
            LoggerType log = new LoggerType();
            log.Action = ActionType.LogIn;
            log.UserBy = logged.Username;
            loggerBL.AddLogger(log);
            List<LoggerType> result = loggerBL.GetLoggers(DateTime.Today.AddDays(1), DateTime.Today.AddDays(2));
            Assert.AreEqual(result.Count, 0);
            TearDown();
        }
        [TestMethod]
        public void testGetLogsBefore()
        {
            TearDown();
            AdminBusinessLogic abl = new AdminBusinessLogic();
            AdminUser logged = EntitiesExampleInstances.TestAdminUser();
            abl.AddAdmin(logged, Guid.NewGuid());
            LoggerType log = new LoggerType();
            log.Action = ActionType.LogIn;
            log.UserBy = logged.Username;
            loggerBL.AddLogger(log);
            List<LoggerType> result = loggerBL.GetLoggers(new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day - 1), new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day - 2));
            Assert.AreEqual(result.Count, 0);
            TearDown();
        }
    }
}
