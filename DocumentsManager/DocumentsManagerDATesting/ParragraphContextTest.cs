using DocumentsManager.Data.DA.Handler;
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
    public class ParragraphContextTest
    {
        
        [TestMethod]
        public void AddParragraphTest()
        {
            ParragraphContext context = new ParragraphContext();
            Parragraph newParragraph = EntitiesExampleInstances.TestParragraph();
            StyleClass style = EntitiesExampleInstances.TestStyleClass();
            Text newText = EntitiesExampleInstances.TestText();
            StyleClassContextHandler contextsc = new StyleClassContextHandler();
            TextContext contextT = new TextContext();
            contextsc.Add(style);
            newText.StyleClass = style;
            contextT.Add(newText);
            newParragraph.StyleClass = style;
            newParragraph.AddText(newText);
            context.Add(newParragraph);
            List<Parragraph> allnewParragraphs = context.GetLazy();
            Assert.IsTrue(allnewParragraphs.Contains(newParragraph));
           
        }
        [TestMethod]
        public void AddTwoParragraphsTest()
        {
            ParragraphContext context = new ParragraphContext();
            Parragraph newParragraph = EntitiesExampleInstances.TestParragraph();
            Parragraph sndParragraph = EntitiesExampleInstances.TestParragraph();
            StyleClass style = EntitiesExampleInstances.TestStyleClass();
            Text newText = EntitiesExampleInstances.TestText();
            StyleClassContextHandler contextsc = new StyleClassContextHandler();
            TextContext contextT = new TextContext();
            contextsc.Add(style);
            newText.StyleClass = style;
            contextT.Add(newText);
            newParragraph.StyleClass = style;
            newParragraph.AddText(newText);
            sndParragraph.StyleClass = style;
            sndParragraph.AddText(newText);
            context.Add(newParragraph);
            context.Add(sndParragraph);
            List<Parragraph> allParragraphs = context.GetLazy();
            Assert.IsTrue(allParragraphs.Contains(sndParragraph) && allParragraphs.Contains(newParragraph));
           
        }
       
    }
}
