using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentsManager.FormatImportation;
using System.Collections.Generic;

namespace DocumentsManager.FormatImportationTest
{
    [TestClass]
    public class FormatImportationServiceTest
    {
        [TestMethod]
        public void LoadFormatsOk()
        {
            FormatImportationService service = new FormatImportationService();
            List<IFormatImportation> importations = service.GetImportationsMethods("C:\\Users\\Fede\\Documents\\DA2.193221.194738\\Importadores");
            Assert.IsTrue(importations.Count==1);
        }
    }
}
