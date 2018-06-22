using DocumentsManager.BusinessLogic.Charts;
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
    public class AdminBusinessLogicTest : UserBusinessLogicTest
    {
        private static string username = "testUsername";
        private static string password = "testPassword";
        public void TearDown()
        {
            ClearDataBase.ClearAll();
        }
        public void SetUp()
        {
            TearDown();
            UserContext context = new UserContext();
            User newuser = EntitiesExampleInstances.TestAdminUser();
            newuser.Username = username;
            newuser.Password = password;
            newuser.Email = "rareemail";
            context.Add(newuser);
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            adminBL.LogIn(newuser.Username, newuser.Password);
        }
        [TestMethod]
        public void LogInWithoutTokenOk()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            User result = adminBL.LogInWithoutToken(username, password);
            Assert.AreEqual(adminBL.GetUserByUsername(username), result);
            TearDown();
        }
        [ExpectedException(typeof(InvalidCredentialException))]
        [TestMethod]
        public void LogInWithoutTokenInvalidCredentials()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            UserContext uContext = new UserContext();
            AdminUser anAdmin = EntitiesExampleInstances.TestAdminUser();
            uContext.Add(anAdmin);
            User result = adminBL.LogInWithoutToken(username, password + "differentPassword");
            TearDown();
        }
        [ExpectedException(typeof(NotAdminOrDoesntExistsException))]
        [TestMethod]
        public void LogInWinAppNotAuthorized()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            UserContext uContext = new UserContext();
            EditorUser anEditor = EntitiesExampleInstances.TestEditorUser();
            uContext.Add(anEditor);
            adminBL.LogInWinApp(anEditor.Username, anEditor.Password);
            TearDown();
        }
        [TestMethod]
        public void LogInWinAppOk()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            adminBL.LogInWinApp(username, password);
            TearDown();
        }
        [TestMethod]
        public void GetAdminsBLTest()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            UserContext uContext = new UserContext();
            AdminUser anAdmin = EntitiesExampleInstances.TestAdminUser();
            uContext.Add(anAdmin);
            bool expectedResult = true;
            bool result = adminBL.GetAllAdmins(Guid.NewGuid()).Contains(anAdmin);
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [TestMethod]
        public void GetAdminsBLTestSeveral()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            UserContext uContext = new UserContext();
            AdminUser anAdmin = EntitiesExampleInstances.TestAdminUser();
            AdminUser anotherAdmin = EntitiesExampleInstances.TestAdminUser();
            uContext.Add(anAdmin);
            uContext.Add(anotherAdmin);
            bool expectedResult = true;
            IEnumerable<AdminUser> allAdmins = adminBL.GetAllAdmins(Guid.NewGuid());
            bool resultOne = allAdmins.Contains(anAdmin);
            bool resultTwo = allAdmins.Contains(anotherAdmin);
            Assert.AreEqual(expectedResult, resultOne && resultTwo);
            TearDown();
        }
        [TestMethod]
        public void GetAdminsBLTestEmpty()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            bool expectedResult = true;
            bool result = adminBL.GetAllAdmins(Guid.NewGuid()).Count() == 1;
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
            SetUp();
            DateTime date1 = new DateTime(2018, 8, 1, 0, 0, 0);
            DateTime date2 = new DateTime(2018, 8, 12, 0, 0, 0);
            AdminBusinessLogic logic = new AdminBusinessLogic();
            ChartIntDate result = logic.GetChartCreationByUser(new AdminUser(), date1, date2, Guid.NewGuid());
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
            SetUp();
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
            ChartIntDate result = logic.GetChartCreationByUser(newUser, date1, date2, Guid.NewGuid());
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
            SetUp();
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
            ChartIntDate result = logic.GetChartModificationsByUser(newUser, date1, date2, Guid.NewGuid());
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
            SetUp();
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
            ChartIntDate result = logic.GetChartCreationByUser(newUser, date1, date2, Guid.NewGuid());
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
            ChartIntDate result = logic.GetChartModificationsByUser(SetUpChart(ModifyState.Modified), date1, date2, Guid.NewGuid());
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
            ChartIntDate result = logic.GetChartModificationsByUser(SetUpChart(ModifyState.Removed), date1, date2, Guid.NewGuid());
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
            SetUp();
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

        public void AddAdminBLTest()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            UserContext uContext = new UserContext();
            AdminUser anAdmin = EntitiesExampleInstances.TestAdminUser();
            Guid expectedResult = adminBL.AddAdmin(anAdmin, Guid.NewGuid());
            Guid result = uContext.GetById(expectedResult).Id;
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [TestMethod]
        public void AddAdminBLTestVerify()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            AdminUser anAdmin = EntitiesExampleInstances.TestAdminUser();
            adminBL.AddAdmin(anAdmin, Guid.NewGuid());
            bool expectedResult = true;
            bool result = adminBL.GetAllAdmins(Guid.NewGuid()).Count() == 2;
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }

        [ExpectedException(typeof(ObjectAlreadyExistsException))]
        [TestMethod]
        public void AddAdminBLTestExistsEmail()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            AdminUser anAdmin = EntitiesExampleInstances.TestAdminUser();
            AdminUser anotherAdmin = EntitiesExampleInstances.TestAdminUser();
            anotherAdmin.Email = "differentEmail";
            adminBL.AddAdmin(anAdmin, Guid.NewGuid());
            adminBL.AddAdmin(anotherAdmin, Guid.NewGuid());
            TearDown();
        }
        [ExpectedException(typeof(ObjectAlreadyExistsException))]
        [TestMethod]
        public void AddAdminBLTestExistsUserName()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            AdminUser anAdmin = EntitiesExampleInstances.TestAdminUser();
            AdminUser anotherAdmin = EntitiesExampleInstances.TestAdminUser();
            anotherAdmin.Username = "differentUserName";
            adminBL.AddAdmin(anAdmin, Guid.NewGuid());
            adminBL.AddAdmin(anotherAdmin, Guid.NewGuid());
            TearDown();
        }
        [TestMethod]
        public void DeleteAdminBLTest()
        {
            SetUp();
            UserContext context = new UserContext();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            AdminUser anAdmin = EntitiesExampleInstances.TestAdminUser();
            anAdmin.Email = "newemail";
            anAdmin.Username = "newusername";
            Guid idUserToDelete = adminBL.AddAdmin(anAdmin, Guid.NewGuid());
            adminBL.DeleteAdmin(idUserToDelete, Guid.NewGuid());
            bool expectedResult = true;
            bool result = adminBL.GetAllAdmins(Guid.NewGuid()).Count() == 1;
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [TestMethod]
        public void DeleteAdminBLTestVerify()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            AdminUser anAdmin = EntitiesExampleInstances.TestAdminUser();
            Guid idUserToDelete = adminBL.AddAdmin(anAdmin, Guid.NewGuid());
            adminBL.DeleteAdmin(idUserToDelete, Guid.NewGuid());
            bool expectedResult = true;
            bool result = !adminBL.GetAllAdmins(Guid.NewGuid()).Contains(anAdmin);
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [TestMethod]
        public void DeleteAdminBLTestMethodResult()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            AdminUser anAdmin = EntitiesExampleInstances.TestAdminUser();
            Guid idUserToDelete = adminBL.AddAdmin(anAdmin, Guid.NewGuid());
            bool expectedResult = true;
            bool result = adminBL.DeleteAdmin(idUserToDelete, Guid.NewGuid());
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [ExpectedException(typeof(ObjectDoesNotExists))]
        [TestMethod]
        public void DoNotDeleteAdminBLTest()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            adminBL.DeleteAdmin(Guid.NewGuid(), Guid.NewGuid());
            TearDown();
        }
        [TestMethod]
        public void GetByIdAdminBLTest()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            AdminUser anAdmin = EntitiesExampleInstances.TestAdminUser();
            Guid IdUserAdded = adminBL.AddAdmin(anAdmin, Guid.NewGuid());
            bool expectedResult = true;
            bool result = adminBL.GetAdminByID(IdUserAdded, Guid.NewGuid()).Equals(anAdmin);
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [ExpectedException(typeof(ObjectDoesNotExists))]
        [TestMethod]
        public void NoGetByIdAdminBLTest()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            adminBL.GetAdminByID(Guid.NewGuid(), Guid.NewGuid());
            TearDown();
        }
        [TestMethod]
        public void GetByIdAdminBLTestWithOthers()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            AdminUser anAdmin = EntitiesExampleInstances.TestAdminUser();
            Guid IdUserAdded = adminBL.AddAdmin(anAdmin, Guid.NewGuid());
            AdminUser anotherAdmin = EntitiesExampleInstances.TestAdminUser();
            anotherAdmin.Username = "UserName2";
            anotherAdmin.Email = "Email2";
            adminBL.AddAdmin(anotherAdmin, Guid.NewGuid());
            bool expectedResult = true;
            bool result = adminBL.GetAdminByID(IdUserAdded, Guid.NewGuid()).Equals(anAdmin);
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [ExpectedException(typeof(WrongUserType))]
        [TestMethod]
        public void EditorInsteadOfGetByIdAdminBLTest()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            EditorBusinessLogic editorBL = new EditorBusinessLogic();
            EditorUser anEditor = EntitiesExampleInstances.TestEditorUser();
            Guid IdUserAdded = editorBL.AddEditor(anEditor, Guid.NewGuid());
            adminBL.GetAdminByID(anEditor.Id, Guid.NewGuid());
            TearDown();
        }
        [TestMethod]
        public void UpdateAdminBLTestOnlyEmail()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            AdminUser anAdmin = EntitiesExampleInstances.TestAdminUser();
            Guid IdUserAdded = adminBL.AddAdmin(anAdmin, Guid.NewGuid());
            anAdmin.Email = "modified@gmail.com";
            bool expectedResult = true;
            bool result = adminBL.UpdateAdmin(IdUserAdded, anAdmin, Guid.NewGuid());
            Assert.AreEqual(expectedResult, result);
            TearDown();
        }
        [TestMethod]
        public void UpdateAdminBLTestCheckEmail()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            AdminUser anAdmin = EntitiesExampleInstances.TestAdminUser();
            Guid IdUserAdded = adminBL.AddAdmin(anAdmin, Guid.NewGuid());
            anAdmin.Email = "modified@gmail.com";
            adminBL.UpdateAdmin(IdUserAdded, anAdmin, Guid.NewGuid());
            Assert.AreEqual(adminBL.GetAdminByID(IdUserAdded, Guid.NewGuid()).Email, "modified@gmail.com");
            TearDown();
        }
        [TestMethod]
        public void UpdateAdminBLTestCheckAttrs()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            AdminUser anAdmin = EntitiesExampleInstances.TestAdminUser();
            Guid IdUserAdded = adminBL.AddAdmin(anAdmin, Guid.NewGuid());
            anAdmin.Name = "George";
            anAdmin.Password = "newPassword";
            anAdmin.Surname = "Gomez";
            anAdmin.Username = "modifiedUsername";
            adminBL.UpdateAdmin(IdUserAdded, anAdmin, Guid.NewGuid());
            AdminUser modifiedUser = adminBL.GetAdminByID(IdUserAdded, Guid.NewGuid());
            Assert.AreEqual(modifiedUser.Name, "George");
            Assert.AreEqual(modifiedUser.Password, "newPassword");
            Assert.AreEqual(modifiedUser.Surname, "Gomez");
            Assert.AreEqual(modifiedUser.Username, "modifiedUsername");
            Assert.AreEqual(modifiedUser.Id, IdUserAdded);
            TearDown();
        }
        [TestMethod]
        public void GetStringTestCheck()
        {
            SetUp();
            AdminBusinessLogic adminBL = new AdminBusinessLogic();
            AdminUser anAdmin = EntitiesExampleInstances.TestAdminUser();
            Guid IdUserAdded = adminBL.AddAdmin(anAdmin, Guid.NewGuid());
            anAdmin.Name = "George";
            anAdmin.Password = "newPassword";
            anAdmin.Surname = "Gomez";
            anAdmin.Username = "modifiedUsername";
            adminBL.UpdateAdmin(IdUserAdded, anAdmin, Guid.NewGuid());
            AdminUser modifiedUser = adminBL.GetAdminByID(IdUserAdded, Guid.NewGuid());
            Assert.AreEqual(modifiedUser.Name, "George");
            Assert.AreEqual(modifiedUser.Password, "newPassword");
            Assert.AreEqual(modifiedUser.Surname, "Gomez");
            Assert.AreEqual(modifiedUser.Username, "modifiedUsername");
            Assert.AreEqual(modifiedUser.Id, IdUserAdded);
            TearDown();
        }
        [TestMethod]
        public void GetChartModificationsByUserAdvancedToString()
        {
            DateTime date1 = DateTime.Today;
            DateTime date2 = DateTime.Today.AddDays(10);
            AdminBusinessLogic logic = new AdminBusinessLogic();
            ChartIntDate chartResult = logic.GetChartModificationsByUser(SetUpChart(ModifyState.Modified), date1, date2, Guid.NewGuid());
            string result = chartResult.ToString();
            string expected = "[Documentos:3- Fecha:10/05/2018][Documentos:0- Fecha:11/05/2018][Documentos:0- Fecha:12/05/2018]"
                + "[Documentos:0- Fecha:13/05/2018][Documentos:0- Fecha:14/05/2018][Documentos:0- Fecha:15/05/2018]" +
                "[Documentos:0- Fecha:16/05/2018][Documentos:0- Fecha:17/05/2018][Documentos:0- Fecha:18/05/2018]" +
                "[Documentos:0- Fecha:19/05/2018]";

            expected = chartResult.ToString();
            Assert.IsTrue(expected.Equals(result));
            TearDown();
        }
        [TestMethod]
        public void CanDeleteTestFalse()
        {
            TearDown();
            Document docAdded = AddADocumentToDB();
            AdminBusinessLogic aBL = new AdminBusinessLogic();
            Assert.IsFalse(aBL.CanDeleteFormat(docAdded.Format.Id));
            TearDown();
        }
        [TestMethod]
        public void CanDeleteTestTrue()
        {
            TearDown();
            FormatBusinessLogic fBL = new FormatBusinessLogic();
            Format newFormat = new Format {
                Id = Guid.NewGuid(),
                Name="TestFormatCanDeleteTrue",
                StyleClasses=new List<StyleClass>()
            };
            Guid formatId = fBL.AddFormat(newFormat, Guid.NewGuid());
            Document docAdded = AddADocumentToDB();
            AdminBusinessLogic aBL = new AdminBusinessLogic();
            Assert.IsTrue(aBL.CanDeleteFormat(newFormat.Id));
            TearDown();
        }
    }
}
