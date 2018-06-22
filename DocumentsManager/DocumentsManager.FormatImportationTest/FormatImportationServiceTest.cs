using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentsManager.FormatImportation;
using System.Collections.Generic;
using System.Reflection;

namespace DocumentsManager.FormatImportationTest
{
    [TestClass]
    public class FormatImportationServiceTest
    {
        [TestMethod]
        public void LoadFormatsOk()
        {
            string extraPath = "bin\\Debug\\DocumentsManager.FormatImportationTest.dll";
            string extendedPath = Assembly.GetExecutingAssembly().Location + "Importadores";
            string path = extendedPath.Replace(extraPath, "");
            FormatImportationService service = new FormatImportationService();
            List<IFormatImportation> importations = service.GetImportationsMethods(path);
            Assert.IsTrue(importations.Count==1);
        }
    }
}
