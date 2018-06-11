using DocumentsManager.FormatImportation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace XMLFormatImport
{
    public class XmlImportation : IFormatImportation
    {
        public List<Tuple<string, ParameterType>> RequiredParameters { get; set; }
        private static string TipoLetra = "TipoLetra";
        private static string Alineado = "Alineado";
        private static string Negrita = "Negrita";
        private static string Subrayado = "Subrayado";

        public XmlImportation()
        {
            RequiredParameters = new List<Tuple<string, ParameterType>>();
            Tuple<string, ParameterType> path = new Tuple<string, ParameterType>("Path", ParameterType.Path);
            RequiredParameters.Add(path);
        }

        public List<Tuple<string, ParameterType>> GetParameters()
        {
            return RequiredParameters;
        }
        public string GetStyleName(string allTheXMLElement)
        {
            string[] firstCut = allTheXMLElement.Split('<');
            string[] secondCut = firstCut[1].Split('>');
            return secondCut[0];
        }

        private string GetValueByString(string value, XElement element)
        {
            try
            {
                return element.Attribute(value).Value;
            }
            catch
            {
                return String.Empty;
            }
        }

        public List<ImportedFormat> ImportFormats(List<Tuple<string, string>> parameters)
        {
            string path = "";

            foreach (Tuple<string, string> tuple in parameters)
            {
                if (tuple.Item1.Equals("Path"))
                {
                    path = tuple.Item2;
                }
            }
            ValidatePath(path);
            List<ImportedFormat> formats = new List<ImportedFormat>();
            try
            {
                XElement xmlFile = XElement.Load(path);
                IEnumerable<XElement> xmlElements = xmlFile.Elements();

                foreach (XElement formatElement in xmlElements)
                {
                    string name = formatElement.FirstAttribute.Value;
                    List<ImportedStyleClass> newStyles = new List<ImportedStyleClass>();
                    XNode actualStyle = formatElement.FirstNode;
                    while (actualStyle != null)
                    {
                        ImportedStyleClass newStyleClass = new ImportedStyleClass();
                        newStyleClass.Name = GetStyleName(actualStyle.ToString());
                        actualStyle = actualStyle.NextNode;
                        newStyles.Add(newStyleClass);
                    }
                    ImportedFormat newFormat = new ImportedFormat();
                    newFormat.Styles = newStyles;
                    newFormat.Name = name;
                    formats.Add(newFormat);
                }
                return formats;
            }
            catch (XmlException ex1)
            {
                throw new Exception("Error en el formato. El archivo es incorrecto!", ex1);
            }
            catch (FormatException ex2)
            {
                throw new Exception("Error en el formato. El archivo es incorrecto!", ex2);
            }
        }

        private static void ValidatePath(string path)
        {
            if (!path.EndsWith(".xml"))
            {
                throw new Exception("Debe seleccionar un archivo xml");
            }
        }
        private int ConvertToNumber(string value)
        {
            int number = 0;
            bool canConvert = Int32.TryParse(value, out number);
            if (canConvert)
                return number;
            else
                throw new Exception("Error en el formato. Imposible importar productos");
        }
        public override string ToString()
        {
            return "Importador XML";
        }
    }
}

