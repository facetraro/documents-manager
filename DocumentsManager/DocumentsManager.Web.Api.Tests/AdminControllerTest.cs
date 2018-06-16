//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using DocumentsManager.BusinessLogic;
//using Moq;
//using DocumentsMangerEntities;
//using System.Collections.Generic;
//using DocumentsManager.Web.Api.Controllers;
//using DocumentsManagerExampleInstances;
//using System.Linq;
//using System.Web.Http;
//using System.Web.Http.Results;
//using System.Net.Http;
//using DocumentsManager.Web.Api.Models;
//using DocumentsManager.ProxyInterfaces;
//using DocumentsManager.ProxyAcces;

//namespace DocumentsManager.Web.Api.Tests
//{
//    [TestClass]
//    public class AdminControllerTest
//    {
//        [TestMethod]
//        public void GetAllAdminsOkTest()
//        {
//            //Arrange
//            var expectedAdmins = GetFakeAdmins();

//            var mockAdminBusinessLogic = new Mock<Proxy>();
//            mockAdminBusinessLogic
//                .Setup(e => e.GetAllAdmins(Guid.NewGuid()))
//                .Returns(expectedAdmins);

//            var controller = new AdminController(mockAdminBusinessLogic.Object);
//            //Act
//            IHttpActionResult obtainedResult = controller.Get(Guid.NewGuid());
//            var contentResult = obtainedResult as OkNegotiatedContentResult<IEnumerable<AdminUser>>;

//            //Assert
//            mockAdminBusinessLogic.VerifyAll();
//            Assert.IsNotNull(contentResult);
//            Assert.IsNotNull(contentResult.Content);
//            Assert.AreEqual(expectedAdmins, contentResult.Content);
//        }
//        [TestMethod]
//        public void GetAllAdminsErrorNotFoundTest()
//        {
//            //Arrange
//            List<AdminUser> expectedAdmins = null;

//            var mockAdminBusinessLogic = new Mock<Proxy>();
//            mockAdminBusinessLogic
//                .Setup(e => e.GetAllAdmins(Guid.NewGuid()))
//                .Returns(expectedAdmins);

//            var controller = new AdminController(mockAdminBusinessLogic.Object);

//            //Act
//            IHttpActionResult obtainedResult = (IHttpActionResult)controller.Get(Guid.NewGuid());

//            //Assert
//            mockAdminBusinessLogic.VerifyAll();
//            Assert.IsInstanceOfType(obtainedResult, typeof(NotFoundResult));
//        }
//        [TestMethod]
//        public void GetAdminByIdOkTest()
//        {
//            //Arrange
//            var fakeAdmin = GetAFakeAdmin().GetEntityModel();
//            var fakeGuid = fakeAdmin.Id;

//            var mockAdminBusinessLogic = new Mock<Proxy>();
//            mockAdminBusinessLogic
//               .Setup(e => e.GetAdminByID(fakeGuid, Guid.NewGuid()))
//               .Returns(fakeAdmin);

//            var controller = new AdminController(mockAdminBusinessLogic.Object);

//            //Act
//            IHttpActionResult obtainedResult = (IHttpActionResult)controller.Get(fakeGuid, Guid.NewGuid());
//            var contentResult = obtainedResult as OkNegotiatedContentResult<AdminUser>;

//            //Assert
//            mockAdminBusinessLogic.VerifyAll();
//            Assert.IsNotNull(contentResult);
//            Assert.IsNotNull(contentResult.Content);
//            Assert.AreEqual(fakeGuid, contentResult.Content.Id);
//        }

//        [TestMethod]
//        public void GetAdminByIdNotFoundErrorTest()
//        {
//            //Arrange
//            var fakeGuid = Guid.NewGuid();

//            var mockAdminBusinessLogic = new Mock<Proxy>();
//            mockAdminBusinessLogic
//                .Setup(bl => bl.GetAdminByID(fakeGuid, Guid.NewGuid()))
//                .Returns((AdminUser)null);

//            var controller = new AdminController(mockAdminBusinessLogic.Object);

//            //Act
//            IHttpActionResult obtainedResult = (IHttpActionResult)controller.Get(fakeGuid, Guid.NewGuid());

//            //Assert
//            mockAdminBusinessLogic.VerifyAll();
//            Assert.IsInstanceOfType(obtainedResult, typeof(NotFoundResult));
//        }
//        [TestMethod]
//        public void CreateNewAdminTest()
//        {
//            //Arrange
//            var fakeAdmin = GetAFakeAdmin().GetEntityModel();

//            var mockAdminBusinessLogic = new Mock<Proxy>();
//            mockAdminBusinessLogic
//                .Setup(e => e.AddAdmin(fakeAdmin, Guid.NewGuid()))
//                .Returns(fakeAdmin.Id);

//            var controller = new AdminController(mockAdminBusinessLogic.Object);
//            AdminModel fakeModel = new AdminModel(fakeAdmin);
//            //Act
//            IHttpActionResult obtainedResult = (IHttpActionResult)controller.Post(fakeModel, Guid.NewGuid());
//            var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<AdminUser>;

//            //Assert
//            mockAdminBusinessLogic.VerifyAll();
//            Assert.IsNotNull(createdResult);
//            Assert.AreEqual("DefaultApi", createdResult.RouteName);
//            Assert.AreEqual(fakeAdmin.Id, createdResult.RouteValues["id"]);
//            Assert.AreEqual(fakeAdmin, createdResult.Content);
//        }

//        [TestMethod]
//        public void CreateNullAdminErrorTest()
//        {
//            //Arrange
//            AdminUser fakeAdmin = null;

//            var mockAdminBusinessLogic = new Mock<Proxy>();
//            mockAdminBusinessLogic
//                .Setup(bl => bl.AddAdmin(fakeAdmin, Guid.NewGuid()))
//                .Throws(new ArgumentNullException());

//            var controller = new AdminController(mockAdminBusinessLogic.Object);
//            AdminModel fakeModel = null;
//            //Act
//            IHttpActionResult obtainedResult = (IHttpActionResult)controller.Post(fakeModel, Guid.NewGuid());

//            //Assert       
//            Assert.IsInstanceOfType(obtainedResult, typeof(BadRequestErrorMessageResult));
//        }

//        [TestMethod]
//        public void UpdateExistingAdminOkTest()
//        {
//            //Arrange
//            var fakeAdmin = GetAFakeAdmin().GetEntityModel();
//            var expectedResult = true;

//            var mockAdminBusinessLogic = new Mock<Proxy>();
//            mockAdminBusinessLogic
//                .Setup(bl => bl.UpdateAdmin(It.IsAny<Guid>(), It.IsAny<AdminUser>(), Guid.NewGuid()))
//                .Returns(true);

//            var controller = new AdminController(mockAdminBusinessLogic.Object);
//            AdminModel fakeModel = new AdminModel(fakeAdmin);
//            //Act
//            IHttpActionResult obtainedResult = (IHttpActionResult)controller.Put(new Guid(), fakeModel, Guid.NewGuid());
//            var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<AdminUser>;

//            //Assert
//            mockAdminBusinessLogic.VerifyAll();
//            Assert.IsNotNull(createdResult);
//            Assert.AreEqual("DefaultApi", createdResult.RouteName);
//            Assert.AreEqual(expectedResult, createdResult.RouteValues["updated"]);
//            Assert.AreEqual(fakeAdmin, createdResult.Content);
//        }

        
//        [TestMethod]
//        public void DeleteAdminOkTest()
//        {
//            //Arrange
//            Guid fakeGuid = Guid.NewGuid();

//            var mockAdminBusinessLogic = new Mock<Proxy>();
//            mockAdminBusinessLogic
//                .Setup(bl => bl.DeleteAdmin(It.IsAny<Guid>(), Guid.NewGuid()))
//                .Returns(It.IsAny<bool>());

//            var controller = new AdminController(mockAdminBusinessLogic.Object);
//            ConfigureHttpRequest(controller);

//            //Act
//            HttpResponseMessage obtainedResult = controller.Delete(fakeGuid, Guid.NewGuid());

//            //Assert
//            mockAdminBusinessLogic.VerifyAll();
//            Assert.IsNotNull(obtainedResult);
//        }

//        private void ConfigureHttpRequest(AdminController controller)
//        {
//            controller.Request = new HttpRequestMessage();
//            controller.Configuration = new HttpConfiguration();
//            controller.Configuration.Routes.MapHttpRoute(
//                name: "DefaultApi",
//                routeTemplate: "api/{controller}/{id}",
//                defaults: new { id = RouteParameter.Optional });
//        }

//        private AdminModel GetAFakeAdmin()
//        {
//            List<AdminUser> editors = GetFakeAdmins().ToList();
//            AdminModel model = new AdminModel(editors.FirstOrDefault());
//            return model;
//        }
//        private Guid GetARandomFakeGuid()
//        {
//            return GetAFakeAdmin().Id;
//        }
//        private IEnumerable<AdminUser> GetFakeAdmins()
//        {
//            List<AdminUser> fakeAdmins = new List<AdminUser>();
//            fakeAdmins.Add(EntitiesExampleInstances.TestAdminUser());
//            AdminUser anotherAdmin = EntitiesExampleInstances.TestAdminUser();
//            anotherAdmin.Email = "another@email";
//            anotherAdmin.Id = Guid.NewGuid();
//            anotherAdmin.Name = "anotherName";
//            fakeAdmins.Add(anotherAdmin);
//            return fakeAdmins;
//        }
//    }
//}

