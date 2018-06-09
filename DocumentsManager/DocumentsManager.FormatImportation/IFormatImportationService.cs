using System;
using System.Collections.Generic;

namespace DocumentsManager.FormatImportation
{
    public interface IFormatImportationService
    {
        List<IFormatImportation> GetImportationsMethods(string path);

        List<ImportedFormat> ImportFormats(IFormatImportation importationSelected, List<Tuple<string, string>> parametersValues);

        List<string> GetParameters(IFormatImportation importationSelected);
    }
}