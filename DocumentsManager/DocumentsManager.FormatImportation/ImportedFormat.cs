using System.Collections.Generic;

namespace DocumentsManager.FormatImportation
{
    public class ImportedFormat
    {
        public string Name { get; set; }
        public List<ImportedStyleClass>  Styles { get; set; }
    }
}