using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentsManager.BusinessLogic;
using Moq;
using DocumentsMangerEntities;
using System.Collections.Generic;
using DocumentsManager.Web.Api.Controllers;
using DocumentsManagerExampleInstances;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using System.Net.Http;
using DocumentsManager.Web.Api.Models;

namespace DocumentsManager.Web.Api.Tests
{
    [TestClass]
    public class AdminControllerTest
    {
        /*
        [TestMethod]
        public void GetAllAdminsOkTest()
        {
            //Arrange
            var expectedAdmins = GetFakeAdmins();

            var mockAdminBusinessLogic = new Mock<IAdminsBusinessLogic>();
            mockAdminBusinessLogic
                .Setup(e => e.GetAllAdmins())
                .Returns(expectedAdmins);

            var controller = new AdminController(mockAdminBusinessLogic.Object);
            //Act}
            IHttpActionResult obtainedResult = controller.Get();
            var contentResult = obtainedResult as OkNegotiatedContentResult<IEnumerable<AdminUser>>;

            //Assert
            mockAdminBusinessLogic.VerifyAll();
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(expectedAdmins, contentResult.Content);
        }
        [TestMethod]
        public void GetAllAdminsErrorNotFoundTest()
        {
            //Arrange
            List<AdminUser> expectedAdmins = null;

            var mockAdminBusinessLogic = new Mock<IAdminsBusinessLogic>();
            mockAdminBusinessLogic
                .Setup(e => e.GetAllAdmins())
                .Returns(expectedAdmins);

            var controller = new AdminController(mockAdminBusinessLogic.Object);

            //Act
            IHttpActionResult obtainedResult = (IHttpActionResult)controller.Get();

            //Assert
            mockAdminBusinessLogic.VerifyAll();
            Assert.IsInstanceOfType(obtainedResult, typeof(NotFoundResult));
        }
        [TestMethod]
        public void GetAdminByIdOkTest()
        {
            //Arrange
            var fakeAdmin = GetAFakeAdmin().GetEntityModel();
            var fakeGuid = fakeAdmin.Id;

            var mockAdminBusinessLogic = new Mock<IAdminsBusinessLogic>();
            mockAdminBusinessLogic
               .Setup(e => e.GetByID(fakeGuid))
               .Returns(fakeAdmin);

            var controller = new AdminController(mockAdminBusinessLogic.Object);

            //Act
            IHttpActionResult obtainedResult = (IHttpActionResult)controller.Get(fakeGuid);
            var contentResult = obtainedResult as OkNegotiatedContentResult<AdminUser>;

            //Assert
            mockAdminBusinessLogic.VerifyAll();
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(fakeGuid, contentResult.Content.Id);
        }

        [TestMethod]
        public void GetAdminByIdNotFoundErrorTest()
        {
            //Arrange
            var fakeGuid = Guid.NewGuid();

            var mockAdminBusinessLogic = new Mock<IAdminsBusinessLogic>();
            mockAdminBusinessLogic
                .Setup(bl => bl.GetByID(fakeGuid))
                .Returns((AdminUser)null);

            var controller = new AdminController(mockAdminBusinessLogic.Object);

            //Act
            IHttpActionResult obtainedResult = (IHttpActionResult)controller.Get(fakeGuid);

            //Assert
            mockAdminBusinessLogic.VerifyAll();
            Assert.IsInstanceOfType(obtainedResult, typeof(NotFoundResult));
        }
        [TestMethod]
        public void CreateNewAdminTest()
        {
            //Arrange
            var fakeAdmin = GetAFakeAdmin().GetEntityModel();

            var mockAdminBusinessLogic = new Mock<IAdminsBusinessLogic>();
            mockAdminBusinessLogic
                .Setup(e => e.Add(fakeAdmin))
                .Returns(fakeAdmin.Id);

            var controller = new AdminController(mockAdminBusinessLogic.Object);
            AdminModel fakeModel = new AdminModel(fakeAdmin);
            //Act
            IHttpActionResult obtainedResult = (IHttpActionResult)controller.Post(fakeModel);
            var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<AdminUser>;

            //Assert
            mockAdminBusinessLogic.VerifyAll();
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(fakeAdmin.Id, createdResult.RouteValues["id"]);
            Assert.AreEqual(fakeAdmin, createdResult.Content);
        }

        [TestMethod]
        public void CreateNullAdminErrorTest()
        {
            //Arrange
            AdminUser fakeAdmin = null;

            var mockAdminBusinessLogic = new Mock<IAdminsBusinessLogic>();
            mockAdminBusinessLogic
                .Setup(bl => bl.Add(fakeAdmin))
                .Throws(new ArgumentNullException());

            var controller = new AdminController(mockAdminBusinessLogic.Object);
            AdminModel fakeModel = null;
            //Act
            IHttpActionResult obtainedResult = (IHttpActionResult)controller.Post(fakeModel);

            //Assert       
            Assert.IsInstanceOfType(obtainedResult, typeof(BadRequestErrorMessageResult));
        }

        [TestMethod]
        public void UpdateExistingAdminOkTest()
        {
            //Arrange
            var fakeAdmin = GetAFakeAdmin().GetEntityModel();
            var expectedResult = true;

            var mockAdminBusinessLogic = new Mock<IAdminsBusinessLogic>();
            mockAdminBusinessLogic
                .Setup(bl => bl.Update(It.IsAny<Guid>(), It.IsAny<AdminUser>()))
                .Returns(true);

            var controller = new AdminController(mockAdminBusinessLogic.Object);
            AdminModel fakeModel = new AdminModel(fakeAdmin);
            //Act
            IHttpActionResult obtainedResult = (IHttpActionResult)controller.Put(new Guid(), fakeModel);
            var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<AdminUser>;

            //Assert
            mockAdminBusinessLogic.VerifyAll();
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(expectedResult, createdResult.RouteValues["updated"]);
            Assert.AreEqual(fakeAdmin, createdResult.Content);
        }
          */
    }


}

