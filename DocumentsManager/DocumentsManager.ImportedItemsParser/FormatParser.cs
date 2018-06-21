using DocumentsManager.FormatImportation;
using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.ImportedItemsParser
{
    public static class FormatParser
    {
        public static Format Parse(ImportedFormat importedFormat)
        {
            Format newFormat = new Format();
            newFormat.Name=importedFormat.Name;
            newFormat.StyleClasses = new List<StyleClass>();
            newFormat.Id = Guid.NewGuid();
            foreach (var item in importedFormat.Styles)
            {
                newFormat.StyleClasses.Add(StyleClassParser.Parse(item));
            }
            return newFormat;
        }
        public static ImportedFormat Parse(Format format)
        {
            ImportedFormat newFormat = new ImportedFormat();
            newFormat.Name = format.Name;
            newFormat.Styles = new List<ImportedStyleClass>();
            foreach (var item in format.StyleClasses)
            {
                newFormat.Styles.Add(StyleClassParser.Parse(item));
            }
            return newFormat;
        }
    }
}
