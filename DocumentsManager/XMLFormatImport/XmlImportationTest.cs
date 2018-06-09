using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XMLFormatImport;
using System.Collections.Generic;
using System.Reflection;
using DocumentsManager.FormatImportation;

namespace FormatImportTesting
{
    [TestClass]
    public class XmlImportationTest
    {
        private string GetXMLPath(string xml)
        {
            string extraPath = "bin\\Debug\\XMLFormatImport.dll";
            string extendedPath = Assembly.GetExecutingAssembly().Location + xml;
            string path = extendedPath.Replace(extraPath, "");
            return path;
        }
        [TestMethod]
        public void OkPathXMLTest()
        {
            string path = GetXMLPath("formatos-bien-formados.xml");
            XmlImportation importation = new XmlImportation();
            List<string> requiredParameters = importation.RequiredParameters;
            List<Tuple<string, string>> fakeParameters = new List<Tuple<string, string>>();
            foreach (var item in requiredParameters)
            {
                Tuple<string, string> parameter = new Tuple<string, string>(item, path);
                fakeParameters.Add(parameter);
            }
            List<ImportedFormat> formats = importation.ImportFormats(fakeParameters);
            Assert.IsTrue(formats.Count == 2);
        }
        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void BadFormatsXMLTest()
        {
            string path = GetXMLPath("formatos-mal-formados-falta-cierre-estilos");
            XmlImportation importation = new XmlImportation();
            List<string> requiredParameters = importation.RequiredParameters;
            List<Tuple<string, string>> fakeParameters = new List<Tuple<string, string>>();
            foreach (var item in requiredParameters)
            {
                Tuple<string, string> parameter = new Tuple<string, string>(item, path);
                fakeParameters.Add(parameter);
            }
            importation.ImportFormats(fakeParameters);
        }
    }
}
