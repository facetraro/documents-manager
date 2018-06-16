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
//using DocumentsManager.ProxyAcces;

//namespace DocumentsManager.Web.Api.Tests
//{
//    [TestClass]
//    public class EditorControllerTest
//    {
//        [TestMethod]
//        public void GetAllEditorsOkTest()
//        {
//            //Arrange
//            var expectedEditors = GetFakeEditors();

//            var mockEditorBusinessLogic = new Mock<Proxy>();
//            mockEditorBusinessLogic
//                .Setup(e => e.GetAllEditors(Guid.NewGuid()))
//                .Returns(expectedEditors);

//            var controller = new EditorController(mockEditorBusinessLogic.Object);
//            //Act
//            IHttpActionResult obtainedResult = controller.Get(Guid.NewGuid());
//            var contentResult = obtainedResult as OkNegotiatedContentResult<IEnumerable<EditorUser>>;

//            //Assert
//            mockEditorBusinessLogic.VerifyAll();
//            Assert.IsNotNull(contentResult);
//            Assert.IsNotNull(contentResult.Content);
//            Assert.AreEqual(expectedEditors, contentResult.Content);
//        }
//        [TestMethod]
//        public void GetAllEditorsErrorNotFoundTest()
//        {
//            //Arrange
//            List<EditorUser> expectedEditors = null;

//            var mockEditorBusinessLogic = new Mock<Proxy>();
//            mockEditorBusinessLogic
//                .Setup(e => e.GetAllEditors(Guid.NewGuid()))
//                .Returns(expectedEditors);

//            var controller = new EditorController(mockEditorBusinessLogic.Object);

//            //Act
//            IHttpActionResult obtainedResult = (IHttpActionResult)controller.Get(Guid.NewGuid());

//            //Assert
//            mockEditorBusinessLogic.VerifyAll();
//            Assert.IsInstanceOfType(obtainedResult, typeof(NotFoundResult));
//        }
//        [TestMethod]
//        public void GetEditorByIdOkTest()
//        {
//            //Arrange
//            var fakeEditor = GetAFakeEditor().GetEntityModel();
//            var fakeGuid = fakeEditor.Id;

//            var mockEditorBusinessLogic = new Mock<Proxy>();
//            mockEditorBusinessLogic
//               .Setup(e => e.GetEditorByID(fakeGuid, Guid.NewGuid()))
//               .Returns(fakeEditor);

//            var controller = new EditorController(mockEditorBusinessLogic.Object);

//            //Act
//            IHttpActionResult obtainedResult = (IHttpActionResult)controller.Get(fakeGuid, Guid.NewGuid());
//            var contentResult = obtainedResult as OkNegotiatedContentResult<EditorUser>;

//            //Assert
//            mockEditorBusinessLogic.VerifyAll();
//            Assert.IsNotNull(contentResult);
//            Assert.IsNotNull(contentResult.Content);
//            Assert.AreEqual(fakeGuid, contentResult.Content.Id);
//        }

//        [TestMethod]
//        public void GetEditorByIdNotFoundErrorTest()
//        {
//            //Arrange
//            var fakeGuid = Guid.NewGuid();

//            var mockEditorBusinessLogic = new Mock<Proxy>();
//            mockEditorBusinessLogic
//                .Setup(bl => bl.GetEditorByID(fakeGuid, Guid.NewGuid()))
//                .Returns((EditorUser)null);

//            var controller = new EditorController(mockEditorBusinessLogic.Object);

//            //Act
//            IHttpActionResult obtainedResult = (IHttpActionResult)controller.Get(fakeGuid, Guid.NewGuid());

//            //Assert
//            mockEditorBusinessLogic.VerifyAll();
//            Assert.IsInstanceOfType(obtainedResult, typeof(NotFoundResult));
//        }
//        [TestMethod]
//        public void CreateNewEditorTest()
//        {
//            //Arrange
//            var fakeEditor = GetAFakeEditor().GetEntityModel();

//            var mockEditorBusinessLogic = new Mock<Proxy>();
//            mockEditorBusinessLogic
//                .Setup(e => e.AddEditor(fakeEditor, Guid.NewGuid()))
//                .Returns(fakeEditor.Id);

//            var controller = new EditorController(mockEditorBusinessLogic.Object);
//            EditorModel fakeModel = new EditorModel(fakeEditor);
//            //Act
//            IHttpActionResult obtainedResult = (IHttpActionResult)controller.Post(fakeModel, Guid.NewGuid());
//            var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<EditorUser>;

//            //Assert
//            mockEditorBusinessLogic.VerifyAll();
//            Assert.IsNotNull(createdResult);
//            Assert.AreEqual("DefaultApi", createdResult.RouteName);
//            Assert.AreEqual(fakeEditor.Id, createdResult.RouteValues["id"]);
//            Assert.AreEqual(fakeEditor, createdResult.Content);
//        }

//        [TestMethod]
//        public void CreateNullEditorErrorTest()
//        {
//            //Arrange
//            EditorUser fakeEditor = null;

//            var mockEditorBusinessLogic = new Mock<Proxy>();
//            mockEditorBusinessLogic
//                .Setup(bl => bl.AddEditor(fakeEditor, Guid.NewGuid()))
//                .Throws(new ArgumentNullException());

//            var controller = new EditorController(mockEditorBusinessLogic.Object);
//            EditorModel fakeModel = null;
//            //Act
//            IHttpActionResult obtainedResult = (IHttpActionResult)controller.Post(fakeModel, Guid.NewGuid());

//            //Assert
//            Assert.IsInstanceOfType(obtainedResult, typeof(BadRequestErrorMessageResult));
//        }

//        [TestMethod]
//        public void DeleteEditorOkTest()
//        {
//            //Arrange
//            Guid fakeGuid = Guid.NewGuid();

//            var mockEditorBusinessLogic = new Mock<Proxy>();
//            mockEditorBusinessLogic
//                .Setup(bl => bl.DeleteEditor(It.IsAny<Guid>(), Guid.NewGuid()))
//                .Returns(It.IsAny<bool>());

//            var controller = new EditorController(mockEditorBusinessLogic.Object);
//            ConfigureHttpRequest(controller);

//            //Act
//            HttpResponseMessage obtainedResult = controller.Delete(fakeGuid, Guid.NewGuid());

//            //Assert
//            mockEditorBusinessLogic.VerifyAll();
//            Assert.IsNotNull(obtainedResult);
//        }

//        private void ConfigureHttpRequest(EditorController controller)
//        {
//            controller.Request = new HttpRequestMessage();
//            controller.Configuration = new HttpConfiguration();
//            controller.Configuration.Routes.MapHttpRoute(
//                name: "DefaultApi",
//                routeTemplate: "api/{controller}/{id}",
//                defaults: new { id = RouteParameter.Optional });
//        }

//        private EditorModel GetAFakeEditor()
//        {
//            List<EditorUser> editors = GetFakeEditors().ToList();
//            EditorModel model = new EditorModel(editors.FirstOrDefault());
//            return model;
//        }
//        private Guid GetARandomFakeGuid()
//        {
//            return GetAFakeEditor().Id;
//        }
//        private IEnumerable<EditorUser> GetFakeEditors()
//        {
//            List<EditorUser> fakeEditors = new List<EditorUser>();
//            fakeEditors.Add(EntitiesExampleInstances.TestEditorUser());
//            EditorUser anotherEditor = EntitiesExampleInstances.TestEditorUser();
//            anotherEditor.Email = "another@email";
//            anotherEditor.Id = Guid.NewGuid();
//            anotherEditor.Name = "anotherName";
//            fakeEditors.Add(anotherEditor);
//            return fakeEditors;
//        }
//    }
//}
