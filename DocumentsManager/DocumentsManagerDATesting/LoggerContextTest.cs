using DocumentsManager.BusinessLogic;
using DocumentsManager.Data.DA.Handler;
using DocumentsManager.Data.Logger;
using DocumentsManagerExampleInstances;
using DocumentsMangerEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManagerDATesting
{
    [TestClass]
    public class LoggerContextTest
    {
        public void TearDown()
        {
            ClearDataBase.ClearAll();
        }
        public ILoggerMethod SetUp() {
            UserContext context = new UserContext();
            AdminUser newUser = EntitiesExampleInstances.TestAdminUser();
            context.Add(newUser);
            LoggerType log = new LoggerType();
            log.Action = ActionType.LogIn;
            log.UserBy = newUser.Username;
            ILoggerMethod loggerOperations = new LoggerMethod();
            loggerOperations.AddLogger(log);
            return loggerOperations;
        }
        [TestMethod]
        public void AddLogTest()
        {
            ILoggerMethod loggerOperations = SetUp();
            Assert.IsTrue(loggerOperations.GetLoggers().Count==1);
            TearDown();
        }
        [TestMethod]
        public void AddMoreLogTest()
        {
            ILoggerMethod loggerOperations = SetUp();
            SetUp();
            SetUp();
            Assert.IsTrue(loggerOperations.GetLoggers().Count == 3);
            TearDown();
        }
        [TestMethod]
        public void NoMoreLogTest()
        {
            ILoggerMethod loggerOperations = new LoggerMethod();
            Assert.IsTrue(loggerOperations.GetLoggers().Count == 0);
            TearDown();
        }
        [TestMethod]
        public void RemoveLogTest()
        {
            LoggerContext context = new LoggerContext();
            ILoggerMethod loggerOperations = SetUp();
            List<LoggerType> allLogs = loggerOperations.GetLoggers();
            context.Remove(allLogs.ElementAt(0));
            Assert.IsTrue(loggerOperations.GetLoggers().Count == 0);
            TearDown();
        }
        [TestMethod]
        public void RemoveIdLogTest()
        {
            LoggerContext context = new LoggerContext();
            ILoggerMethod loggerOperations = SetUp();
            List<LoggerType> allLogs = loggerOperations.GetLoggers();
            context.Remove(allLogs.ElementAt(0).Id);
            Assert.IsTrue(loggerOperations.GetLoggers().Count == 0);
            TearDown();
        }
        [TestMethod]
        public void NotRemoveIdAllLogTest()
        {
            LoggerContext context = new LoggerContext();
            ILoggerMethod loggerOperations = SetUp();
            SetUp();
            List<LoggerType> allLogs = loggerOperations.GetLoggers();
            context.Remove(allLogs.ElementAt(0).Id);
            Assert.IsTrue(loggerOperations.GetLoggers().Count == 1);
            TearDown();
        }
        [TestMethod]
        public void EmptyRemoveAllLogTest()
        {
            LoggerContext context = new LoggerContext();
            ILoggerMethod loggerOperations = new LoggerMethod();
            List<LoggerType> allLogs = loggerOperations.GetLoggers();
            context.Remove(Guid.NewGuid());
            Assert.IsTrue(loggerOperations.GetLoggers().Count == 0);
            TearDown();
        }

    }
}
