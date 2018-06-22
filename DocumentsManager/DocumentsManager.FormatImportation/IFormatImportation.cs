using System;
using System.Collections.Generic;

namespace DocumentsManager.FormatImportation
{
    public interface IFormatImportation
    {
        List<ImportedFormat> ImportFormats(List<Tuple<string, string>> parameters);
        List<Tuple<string, ParameterType>> GetParameters();
    }
}