using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.FormatImportation
{
    public class FormatImportationService : IFormatImportationService
    {
        List<IFormatImportation> importationMethods { get; }
        public FormatImportationService()
        {
            importationMethods = new List<IFormatImportation>();
        }

        public List<IFormatImportation> GetImportationsMethods(string path)
        {
            if (!string.IsNullOrWhiteSpace(path))
            {
                List<string> files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories)
                  .Where(file => new string[] { ".dll" }
                  .Contains(Path.GetExtension(file)))
                  .ToList();

                foreach (string filePath in files)
                {
                    Assembly myAssembly = Assembly.LoadFile(filePath);
                    foreach (Type typeOfFile in myAssembly.GetExportedTypes())
                    {
                        if (typeof(IFormatImportation).IsAssignableFrom(typeOfFile))
                        {
                            IFormatImportation importation = (IFormatImportation)Activator.CreateInstance(typeOfFile);
                            importationMethods.Add(importation);
                        }
                    }
                }
            }
            return importationMethods;
        }

        public List<ImportedFormat> ImportFormats(IFormatImportation importationSelected, List<Tuple<string, string>> parametersValues)
        {
            return importationSelected.ImportFormats(parametersValues);
        }

        public List<string> GetParameters(IFormatImportation importationSelected)
        {
            return importationSelected.GetParameters();
        }
    }
}
