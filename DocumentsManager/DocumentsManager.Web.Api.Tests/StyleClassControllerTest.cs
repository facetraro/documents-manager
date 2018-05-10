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
    public class StyleClassControllerTest
    {
        [TestMethod]
        public void GetAllStyleClassesOkTest()
        {
            //Arrange
            var expectedStyleClasses = GetFakeStyleClasses();

            var mockStyleClassBusinessLogic = new Mock<IStyleClassBusinessLogic>();
            mockStyleClassBusinessLogic
                .Setup(e => e.GetAllStyleClasses())
                .Returns(expectedStyleClasses);

            var controller = new StyleClassController(mockStyleClassBusinessLogic.Object);
            //Act}
            IHttpActionResult obtainedResult = controller.Get();
            var contentResult = obtainedResult as OkNegotiatedContentResult<IEnumerable<StyleClass>>;

            //Assert
            mockStyleClassBusinessLogic.VerifyAll();
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(expectedStyleClasses, contentResult.Content);
        }
        [TestMethod]
        public void GetAllStyleClassesErrorNotFoundTest()
        {
            //Arrange
            List<StyleClass> expectedStyleClasses = null;

            var mockStyleClassBusinessLogic = new Mock<IStyleClassBusinessLogic>();
            mockStyleClassBusinessLogic
                .Setup(e => e.GetAllStyleClasses())
                .Returns(expectedStyleClasses);

            var controller = new StyleClassController(mockStyleClassBusinessLogic.Object);

            //Act
            IHttpActionResult obtainedResult = (IHttpActionResult)controller.Get();

            //Assert
            mockStyleClassBusinessLogic.VerifyAll();
            Assert.IsInstanceOfType(obtainedResult, typeof(NotFoundResult));
        }
        [TestMethod]
        public void GetStyleClassByIdOkTest()
        {
            //Arrange
            var fakeStyleClass = GetAFakeStyleClass().GetEntityModel();
            var fakeGuid = fakeStyleClass.Id;

            var mockStyleClassBusinessLogic = new Mock<IStyleClassBusinessLogic>();
            mockStyleClassBusinessLogic
               .Setup(e => e.GetById(fakeGuid))
               .Returns(fakeStyleClass);

            var controller = new StyleClassController(mockStyleClassBusinessLogic.Object);

            //Act
            IHttpActionResult obtainedResult = (IHttpActionResult)controller.Get(fakeGuid);
            var contentResult = obtainedResult as OkNegotiatedContentResult<StyleClass>;

            //Assert
            mockStyleClassBusinessLogic.VerifyAll();
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(fakeGuid, contentResult.Content.Id);
        }

        [TestMethod]
        public void GetStyleClassByIdNotFoundErrorTest()
        {
            //Arrange
            var fakeGuid = Guid.NewGuid();

            var mockStyleClassBusinessLogic = new Mock<IStyleClassBusinessLogic>();
            mockStyleClassBusinessLogic
                .Setup(bl => bl.GetById(fakeGuid))
                .Returns((StyleClass)null);

            var controller = new StyleClassController(mockStyleClassBusinessLogic.Object);

            //Act
            IHttpActionResult obtainedResult = (IHttpActionResult)controller.Get(fakeGuid);

            //Assert
            mockStyleClassBusinessLogic.VerifyAll();
            Assert.IsInstanceOfType(obtainedResult, typeof(NotFoundResult));
        }
        [TestMethod]
        public void CreateNewStyleClassTest()
        {
            //Arrange
            var fakeStyleClass = GetAFakeStyleClass().GetEntityModel();

            var mockStyleClassBusinessLogic = new Mock<IStyleClassBusinessLogic>();
            mockStyleClassBusinessLogic
                .Setup(e => e.Add(fakeStyleClass))
                .Returns(fakeStyleClass.Id);

            var controller = new StyleClassController(mockStyleClassBusinessLogic.Object);
            StyleClassModel fakeModel = new StyleClassModel(fakeStyleClass);
            //Act
            IHttpActionResult obtainedResult = (IHttpActionResult)controller.Post(fakeModel);
            var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<StyleClass>;

            //Assert
            mockStyleClassBusinessLogic.VerifyAll();
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(fakeStyleClass.Id, createdResult.RouteValues["id"]);
            Assert.AreEqual(fakeStyleClass, createdResult.Content);
        }

        //[TestMethod]
        //public void CreateNullStyleClassErrorTest()
        //{
        //    //Arrange
        //    StyleClass fakeStyle = null;

        //    var mockStyleClassBusinessLogic = new Mock<IStyleClassBusinessLogic>();
        //    mockStyleClassBusinessLogic
        //        .Setup(bl => bl.Add(fakeStyle))
        //        .Throws(new ArgumentNullException());

        //    var controller = new StyleClassController(mockStyleClassBusinessLogic.Object);
        //    StyleClassModel fakeModel = null;
        //    //Act
        //    IHttpActionResult obtainedResult = (IHttpActionResult)controller.Post(fakeModel);

        //    //Assert
        //    Assert.IsInstanceOfType(obtainedResult, typeof(BadRequestErrorMessageResult));
        //}

        [TestMethod]
        public void UpdateExistingStyleClassOkTest()
        {
            //Arrange
            var fakeStyleClass = GetAFakeStyleClass().GetEntityModel();
            var expectedResult = true;

            var mockStyleClassBusinessLogic = new Mock<IStyleClassBusinessLogic>();
            mockStyleClassBusinessLogic
                .Setup(bl => bl.Update(It.IsAny<Guid>(), It.IsAny<StyleClass>()))
                .Returns(true);

            var controller = new StyleClassController(mockStyleClassBusinessLogic.Object);
            StyleClassModel fakeModel = new StyleClassModel(fakeStyleClass);
            //Act
            IHttpActionResult obtainedResult = (IHttpActionResult)controller.Put(new Guid(), fakeModel);
            var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<StyleClass>;

            //Assert
            mockStyleClassBusinessLogic.VerifyAll();
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(expectedResult, createdResult.RouteValues["updated"]);
            Assert.AreEqual(fakeStyleClass, createdResult.Content);
        }

        //[TestMethod]
        //public void UpdateStyleClassWithNullIdErrorTest()
        //{
        //    //Arrange
        //    StyleClass fakeStyle = null;

        //    var mockStyleClassBusinessLogic = new Mock<IStyleClassBusinessLogic>();
        //    mockStyleClassBusinessLogic
        //        .Setup(bl => bl.Update(new Guid(), It.IsAny<StyleClass>()))
        //        .Throws(new ArgumentNullException());

        //    var controller = new StyleClassController(mockStyleClassBusinessLogic.Object);
        //    StyleClassModel fakeModel = null;
        //    //Act
        //    IHttpActionResult obtainedResult = (IHttpActionResult)controller.Put(new Guid(), fakeModel);

        //    //Assert
        //    Assert.IsInstanceOfType(obtainedResult, typeof(BadRequestErrorMessageResult));
        //}
        [TestMethod]
        public void DeleteStyleClassOkTest()
        {
            //Arrange
            Guid fakeGuid = Guid.NewGuid();

            var mockStyleClassBusinessLogic = new Mock<IStyleClassBusinessLogic>();
            mockStyleClassBusinessLogic
                .Setup(bl => bl.Delete(It.IsAny<Guid>()))
                .Returns(It.IsAny<bool>());

            var controller = new StyleClassController(mockStyleClassBusinessLogic.Object);
            ConfigureHttpRequest(controller);

            //Act
            HttpResponseMessage obtainedResult = controller.Delete(fakeGuid);

            //Assert
            mockStyleClassBusinessLogic.VerifyAll();
            Assert.IsNotNull(obtainedResult);
        }

        private void ConfigureHttpRequest(StyleClassController controller)
        {
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            controller.Configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }

        private StyleClassModel GetAFakeStyleClass()
        {
            List<StyleClass> styleClasses = GetFakeStyleClasses().ToList();
            StyleClassModel model = new StyleClassModel(styleClasses.FirstOrDefault());
            return model;
        }
        private Guid GetARandomFakeGuid()
        {
            return GetAFakeStyleClass().Id;
        }
        private IEnumerable<StyleClass> GetFakeStyleClasses()
        {
            List<StyleClass> fakeStyleClasses = new List<StyleClass>();
            fakeStyleClasses.Add(EntitiesExampleInstances.TestStyleClass());
            StyleClass anotherStyleClass = EntitiesExampleInstances.TestStyleClass();
            anotherStyleClass.Name = "anotherStyle";
            anotherStyleClass.Id = Guid.NewGuid();
            anotherStyleClass.Attributes.Remove(anotherStyleClass.Attributes.ElementAt(0));
            fakeStyleClasses.Add(anotherStyleClass);
            return fakeStyleClasses;
        }
    }
}
