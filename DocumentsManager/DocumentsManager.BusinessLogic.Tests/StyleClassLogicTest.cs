using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentsManager.BusinessLogic;
using DocumentsMangerEntities;

namespace DocumentsManager.BusinessLogic.Tests
{
    [TestClass]
    public class StyleClassLogicTest
    {
        [TestMethod]
        public void GetHtmlTextEmpty()
        {
            StyleClassBusinessLogic logic = new StyleClassBusinessLogic();
            Assert.AreEqual("<p>Empty</p>", logic.GetHtmlText(new StyleClass(), "Empty"));
        }
    }
}
