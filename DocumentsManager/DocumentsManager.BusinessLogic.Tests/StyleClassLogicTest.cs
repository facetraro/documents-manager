﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentsManager.BusinessLogic;
using DocumentsMangerEntities;
using DocumentsManagerExampleInstances;
using DocumentsManager.Data.DA.Handler;

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
        [TestMethod]
        public void GetHtmlTextBold()
        {
            StyleClassBusinessLogic logic = new StyleClassBusinessLogic();
            StyleClass newStyle = new StyleClass();
            Bold newAttribute = new Bold();
            newAttribute.Applies = ApplyValue.Apply;
            newStyle.Attributes.Add(newAttribute);
            Assert.AreEqual("<p><strong>Strong</strong></p>", logic.GetHtmlText(newStyle, "Strong"));
        }
        [TestMethod]
        public void GetHtmlTextAlignment()
        {
            StyleClassBusinessLogic logic = new StyleClassBusinessLogic();
            StyleClass newStyle = new StyleClass();
            Alignment newAttribute = new Alignment();
            newAttribute.TextAlignment = TextAlignment.Left;
            newStyle.Attributes.Add(newAttribute);
            Assert.AreEqual("<p style=\" text-align: left ; \">textToLeft</p>", logic.GetHtmlText(newStyle, "textToLeft"));
        }
        [TestMethod]
        public void GetHtmlTextAlignmentJustifyBlackCourier()
        {
            StyleClassBusinessLogic logic = new StyleClassBusinessLogic();
            StyleClass newStyle = new StyleClass();
            Alignment newAttribute = new Alignment();
            newAttribute.TextAlignment = TextAlignment.Justify;
            Font anotherAttribute = new Font();
            anotherAttribute.FontType = FontType.CourierNew;
            StyleColor styleColor = new StyleColor();
            styleColor.TextColor = TextColor.Black;
            newStyle.Attributes.Add(newAttribute);
            newStyle.Attributes.Add(styleColor);
            newStyle.Attributes.Add(anotherAttribute);
            string result = logic.GetHtmlText(newStyle, "JustifyBlackCourier");
            Assert.AreEqual("<p style=\" text-align: justify ;  color: black ;  font-family: courier ; \">JustifyBlackCourier</p>", result);
        }
        [TestMethod]
        public void GetHtmlTextRightFontTypeItalics()
        {
            StyleClassBusinessLogic logic = new StyleClassBusinessLogic();
            StyleClass newStyle = new StyleClass();
            Alignment alignment = new Alignment();
            alignment.TextAlignment = TextAlignment.Right;
            Font newAttribute = new Font();
            newAttribute.FontType = FontType.TimesNewRoman;
            Italics anotherAttribute = new Italics();
            anotherAttribute.Applies = ApplyValue.Apply;
            newStyle.Attributes.Add(alignment);
            newStyle.Attributes.Add(anotherAttribute);
            newStyle.Attributes.Add(newAttribute);
            string result = logic.GetHtmlText(newStyle, "italicTimes");
            Assert.AreEqual("<p style=\" text-align: right ;  font-family: times ; \"><em>italicTimes</em></p>", result);
        }
        [TestMethod]
        public void GetHtmlTextStyleExampleInstances()
        {
            StyleClassBusinessLogic logic = new StyleClassBusinessLogic();
            StyleClass newStyle = EntitiesExampleInstances.TestStyleClass();
            string result = logic.GetHtmlText(newStyle, "ExampleInstance");
            string expected = "<p style=\" text-align: center ;  color: red ;  text-decoration: underline ;  font-size: 10pt; font-family: arial ; \"><em><strong>ExampleInstance</strong></em></p>";
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void IsNotTheChainOfStyleClassTest()
        {
            StyleClass styleSon = new StyleClass();
            styleSon.Id = Guid.NewGuid();
            styleSon.Name = "firstOne";
            StyleClass father = new StyleClass();
            father.Name = "secondOne";
            father.Id = Guid.NewGuid();
            StyleClass fatherOfFather = new StyleClass();
            fatherOfFather.Name = "thirdOne";
            fatherOfFather.Id = Guid.NewGuid();
            StyleClassContextHandler context = new StyleClassContextHandler();
            context.Add(styleSon);
            context.Add(fatherOfFather);
            father.Based = fatherOfFather;
            context.Add(father);
            styleSon.Based = father;
            StyleClassBusinessLogic logic = new StyleClassBusinessLogic();
            Assert.IsFalse(logic.IsThisStyleInTheChainOfBased(styleSon.Based, styleSon));
        }
        [TestMethod]
        public void IsInTheChainOfStyleClassTest()
        {
            StyleClass styleSon = new StyleClass();
            styleSon.Id = Guid.NewGuid();
            styleSon.Name = "firstOne";
            StyleClass father = new StyleClass();
            father.Name = "secondOne";
            father.Id = Guid.NewGuid();
            StyleClass fatherOfFather = new StyleClass();
            fatherOfFather.Name = "thirdOne";
            fatherOfFather.Id = Guid.NewGuid();
            StyleClassContextHandler context = new StyleClassContextHandler();
            context.Add(styleSon);
            fatherOfFather.Based = styleSon;
            context.Add(fatherOfFather);
            father.Based = fatherOfFather;
            context.Add(father);
            styleSon.Based = father;
            StyleClassBusinessLogic logic = new StyleClassBusinessLogic();
            Assert.IsTrue(logic.IsThisStyleInTheChainOfBased(styleSon.Based, styleSon));
        }
    }
}
