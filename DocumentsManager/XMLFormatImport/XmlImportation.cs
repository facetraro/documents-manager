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
        private static string TamanioLetra = "TamanioLetra";
        private static string Cursiva = "Cursiva";
        private static string Alineado = "Alineacion";
        private static string Color = "Color";
        private static string Borde = "Borde";
        private static string Negrita = "Negrita";
        private static string Subrayado = "Subrayado";

        private List<string> GetDoubleHeaderAttributes()
        {
            List<string> doubleHeaderAttributes = new List<string>();
            doubleHeaderAttributes.Add(TipoLetra);
            doubleHeaderAttributes.Add(TamanioLetra);
            doubleHeaderAttributes.Add(Alineado);
            doubleHeaderAttributes.Add(Color);
            return doubleHeaderAttributes;
        }
        private List<string> GetSingleHeaderAttributes()
        {
            List<string> singleHeaderAttributes = new List<string>();
            singleHeaderAttributes.Add(Cursiva);
            singleHeaderAttributes.Add(Borde);
            singleHeaderAttributes.Add(Negrita);
            singleHeaderAttributes.Add(Subrayado);
            return singleHeaderAttributes;
        }
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
                        LoadAllAttributes(newStyleClass, actualStyle);
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
        private string GetValueByNode(string nodeName, string allTheXMLElement)
        {
            string firstHeader = "<" + nodeName + ">";
            string lastHeader = "</" + nodeName + ">";
            string[] firstCut = allTheXMLElement.Split(new[] { firstHeader }, StringSplitOptions.None);
            if (firstCut.Length == 2)
            {
                string[] secondCut = firstCut[1].Split(new[] { lastHeader }, StringSplitOptions.None);
                if (secondCut.Length == 2)
                {
                    return nodeName + "###" + secondCut[0];
                }
                if (secondCut.Length > 2)
                {
                    throw new Exception("XML Mal Formado - Atributo de Estilo repetido [" + nodeName + "]");
                }
            }
            return string.Empty;
        }
        private void LoadValueDoubleHeader(ImportedStyleClass newStyleClass, string value, XNode actualStyle)
        {
            string valueFromNode = GetValueByNode(value, actualStyle.ToString());
            if (valueFromNode.Length != 0)
            {
                newStyleClass.StyleAttributes.Add(valueFromNode);
            }
        }
        private void LoadValueSingleHeader(ImportedStyleClass newStyleClass, string value, XNode actualStyle)
        {
            string allTheXMLElement = actualStyle.ToString();
            string header = "<" + value + " />";
            string[] cut = allTheXMLElement.Split(new[] { header }, StringSplitOptions.None);
            if (cut.Length == 2)
            {
                newStyleClass.StyleAttributes.Add(value);
            }
            if (cut.Length > 2)
            {
                throw new Exception("XML Mal Formado - Atributo de Estilo repetido [" + value + "]");
            }
        }
        private void LoadAllAttributes(ImportedStyleClass newStyleClass, XNode actualStyle)
        {
            foreach (var item in this.GetDoubleHeaderAttributes())
            {
                LoadValueDoubleHeader(newStyleClass, item, actualStyle);
            }
            foreach (var item in this.GetSingleHeaderAttributes())
            {
                LoadValueSingleHeader(newStyleClass, item, actualStyle);
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

