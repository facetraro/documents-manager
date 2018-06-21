using DocumentsManager.FormatImportation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONFormatImport
{
    public class JsonImportation : IFormatImportation
    {
        public List<Tuple<string, ParameterType>> RequiredParameters { get; set; }
        public List<Tuple<string, ParameterType>> GetParameters()
        {
            return RequiredParameters;
        }
        public JsonImportation()
        {
            RequiredParameters = new List<Tuple<string, ParameterType>>();
            Tuple<string, ParameterType> path = new Tuple<string, ParameterType>("Path", ParameterType.Path);
            RequiredParameters.Add(path);
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
            List<ImportedFormat> formats = new List<ImportedFormat>();
            ValidatePath(path);
            try {
                string json = "";
                StreamReader reader = new StreamReader(path);
                json = reader.ReadToEnd();
                ImportedFormat jsonFormat = new ImportedFormat();
                jsonFormat = JsonConvert.DeserializeObject<ImportedFormat>(json);
                formats.Add(jsonFormat);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el formato. La sintaxis es incorrecta");
            }
            return formats;
        }
        private static void ValidatePath(string path)
        {
            if (!path.EndsWith(".json"))
            {
                throw new Exception("Debe seleccionar un archivo json");
            }
        }
        public override string ToString()
        {
            return "Importador Json";
        }
    }
}
