using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.FormatImportation
{
    public class ImportedStyleClass
    {
        public string Name { get; set; }
        public List<Tuple<string, string>> StyleAttributes { get; set; }
    }
}
