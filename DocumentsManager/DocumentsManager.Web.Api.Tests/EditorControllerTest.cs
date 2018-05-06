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

namespace DocumentsManager.Web.Api.Tests
{
    [TestClass]
    public class EditorControllerTest
    {
        [TestMethod]
        public void GetAllEditorsOkTest()
        {
            //Arrange
            var expectedEditors = GetFakeEditors();

            var mockEditorBusinessLogic = new Mock<IEditorsBusinessLogic>();
            mockEditorBusinessLogic
                .Setup(e => e.GetAllEditors())
                .Returns(expectedEditors);

            var controller = new EditorController(mockEditorBusinessLogic.Object);
            //Act}
            IHttpActionResult obtainedResult = controller.Get();
            var contentResult = obtainedResult as OkNegotiatedContentResult<IEnumerable<EditorUser>>;

            //Assert
            mockEditorBusinessLogic.VerifyAll();
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(expectedEditors, contentResult.Content);
        }
        private EditorUser GetAFakeEditor()
        {
            List<EditorUser> editors = GetFakeEditors().ToList();
            return editors.FirstOrDefault();
        }
        private IEnumerable<EditorUser> GetFakeEditors()
        {
            List<EditorUser> fakeEditors = new List<EditorUser>();
            fakeEditors.Add(EntitiesExampleInstances.TestEditorUser());
            EditorUser anotherEditor = EntitiesExampleInstances.TestEditorUser();
            anotherEditor.Email = "another@email";
            anotherEditor.Id = Guid.NewGuid();
            anotherEditor.Name = "anotherName";
            fakeEditors.Add(anotherEditor);
            return fakeEditors;
        }
    }
}
