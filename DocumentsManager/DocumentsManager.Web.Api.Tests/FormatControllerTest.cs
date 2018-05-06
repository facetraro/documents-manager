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

namespace DocumentsManager.Web.Api.Tests
{
    [TestClass]
    public class FormatControllerTest
    {
        [TestMethod]
        public void GetAllFormatsOkTest()
        {
            //Arrange
            var expectedFormats = GetFakeFormats();

            var mockFormatBusinessLogic = new Mock<IFormatsBusinessLogic>();
            mockFormatBusinessLogic
                .Setup(e => e.GetAllFormats())
                .Returns(expectedFormats);

            var controller = new FormatController(mockFormatBusinessLogic.Object);
            //Act}
            IHttpActionResult obtainedResult = controller.Get();
            var contentResult = obtainedResult as OkNegotiatedContentResult<IEnumerable<Format>>;

            //Assert
            mockFormatBusinessLogic.VerifyAll();
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(expectedFormats, contentResult.Content);
        }
        [TestMethod]
        public void GetAllFormatsErrorNotFoundTest()
        {
            //Arrange
            List<Format> expectedFormats = null;

            var mockFormatBusinessLogic = new Mock<IFormatsBusinessLogic>();
            mockFormatBusinessLogic
                .Setup(e => e.GetAllFormats())
                .Returns(expectedFormats);

            var controller = new FormatController(mockFormatBusinessLogic.Object);

            //Act
            IHttpActionResult obtainedResult = (IHttpActionResult)controller.Get();

            //Assert
            mockFormatBusinessLogic.VerifyAll();
            Assert.IsInstanceOfType(obtainedResult, typeof(NotFoundResult));
        }
        [TestMethod]
        public void GetFormatByIdOkTest()
        {
            //Arrange
            var fakeFormat = GetAFakeFormat();
            var fakeGuid = fakeFormat.Id;

            var mockFormatBusinessLogic = new Mock<IFormatsBusinessLogic>();
            mockFormatBusinessLogic
               .Setup(e => e.GetByID(fakeGuid))
               .Returns(fakeFormat);

            var controller = new FormatController(mockFormatBusinessLogic.Object);

            //Act
            IHttpActionResult obtainedResult = (IHttpActionResult)controller.Get(fakeGuid);
            var contentResult = obtainedResult as OkNegotiatedContentResult<Format>;

            //Assert
            mockFormatBusinessLogic.VerifyAll();
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(fakeGuid, contentResult.Content.Id);
        }

        [TestMethod]
        public void GetFormatByIdNotFoundErrorTest()
        {
            //Arrange
            var fakeGuid = Guid.NewGuid();

            var mockFormatBusinessLogic = new Mock<IFormatsBusinessLogic>();
            mockFormatBusinessLogic
                .Setup(bl => bl.GetByID(fakeGuid))
                .Returns((Format)null);

            var controller = new FormatController(mockFormatBusinessLogic.Object);

            //Act
            IHttpActionResult obtainedResult = (IHttpActionResult)controller.Get(fakeGuid);

            //Assert
            mockFormatBusinessLogic.VerifyAll();
            Assert.IsInstanceOfType(obtainedResult, typeof(NotFoundResult));
        }
        [TestMethod]
        public void CreateNewFormatTest()
        {
            //Arrange
            var fakeFormat = GetAFakeFormat();

            var mockFormatBusinessLogic = new Mock<IFormatsBusinessLogic>();
            mockFormatBusinessLogic
                .Setup(e => e.Add(fakeFormat))
                .Returns(fakeFormat.Id);

            var controller = new FormatController(mockFormatBusinessLogic.Object);

            //Act
            IHttpActionResult obtainedResult = (IHttpActionResult)controller.Post(fakeFormat);
            var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Format>;

            //Assert
            mockFormatBusinessLogic.VerifyAll();
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(fakeFormat.Id, createdResult.RouteValues["id"]);
            Assert.AreEqual(fakeFormat, createdResult.Content);
        }

        [TestMethod]
        public void CreateNullFormatErrorTest()
        {
            //Arrange
            Format fakeFormat = null;

            var mockFormatBusinessLogic = new Mock<IFormatsBusinessLogic>();
            mockFormatBusinessLogic
                .Setup(bl => bl.Add(fakeFormat))
                .Throws(new ArgumentNullException());

            var controller = new FormatController(mockFormatBusinessLogic.Object);

            //Act
            IHttpActionResult obtainedResult = (IHttpActionResult)controller.Post(fakeFormat);

            //Assert
            mockFormatBusinessLogic.VerifyAll();
            Assert.IsInstanceOfType(obtainedResult, typeof(BadRequestErrorMessageResult));
        }

        [TestMethod]
        public void UpdateExistingFormatOkTest()
        {
            //Arrange
            var fakeFormat = GetAFakeFormat();
            var expectedResult = true;

            var mockFormatBusinessLogic = new Mock<IFormatsBusinessLogic>();
            mockFormatBusinessLogic
                .Setup(bl => bl.Update(It.IsAny<Guid>(), It.IsAny<Format>()))
                .Returns(true);

            var controller = new FormatController(mockFormatBusinessLogic.Object);

            //Act
            IHttpActionResult obtainedResult = (IHttpActionResult)controller.Put(new Guid(), fakeFormat);
            var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Format>;

            //Assert
            mockFormatBusinessLogic.VerifyAll();
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(expectedResult, createdResult.RouteValues["updated"]);
            Assert.AreEqual(fakeFormat, createdResult.Content);
        }

        [TestMethod]
        public void UpdateFormatWithNullIdErrorTest()
        {
            //Arrange
            Format fakeFormat = null;

            var mockFormatBusinessLogic = new Mock<IFormatsBusinessLogic>();
            mockFormatBusinessLogic
                .Setup(bl => bl.Update(new Guid(), It.IsAny<Format>()))
                .Throws(new ArgumentNullException());

            var controller = new FormatController(mockFormatBusinessLogic.Object);

            //Act
            IHttpActionResult obtainedResult = (IHttpActionResult)controller.Put(new Guid(), fakeFormat);

            //Assert
            mockFormatBusinessLogic.VerifyAll();
            Assert.IsInstanceOfType(obtainedResult, typeof(BadRequestErrorMessageResult));
        }
        [TestMethod]
        public void DeleteFormatOkTest()
        {
            //Arrange
            Guid fakeGuid = Guid.NewGuid();

            var mockFormatBusinessLogic = new Mock<IFormatsBusinessLogic>();
            mockFormatBusinessLogic
                .Setup(bl => bl.Delete(It.IsAny<Guid>()))
                .Returns(It.IsAny<bool>());

            var controller = new FormatController(mockFormatBusinessLogic.Object);
            ConfigureHttpRequest(controller);

            //Act
            HttpResponseMessage obtainedResult = controller.Delete(fakeGuid);

            //Assert
            mockFormatBusinessLogic.VerifyAll();
            Assert.IsNotNull(obtainedResult);
        }

        private void ConfigureHttpRequest(FormatController controller)
        {
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            controller.Configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }

        private Format GetAFakeFormat()
        {
            List<Format> editors = GetFakeFormats().ToList();
            return editors.FirstOrDefault();
        }
        private Guid GetARandomFakeGuid()
        {
            return GetAFakeFormat().Id;
        }
        private IEnumerable<Format> GetFakeFormats()
        {
            List<Format> fakeFormats = new List<Format>();
            fakeFormats.Add(EntitiesExampleInstances.TestFormat());
            Format anotherFormat = EntitiesExampleInstances.TestFormat();
            anotherFormat.Name = "anotherName";
            anotherFormat.Id = Guid.NewGuid();
            anotherFormat.Name = "anotherName";
            fakeFormats.Add(anotherFormat);
            return fakeFormats;
        }
    }
}
