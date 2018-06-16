using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.ProxyInterfaces
{
    public interface IFormatsBusinessLogic
    {
        IEnumerable<Format> GetAllFormats(Guid tokenId);
        Format GetFormatByID(Guid id, Guid tokenId);
        Guid AddFormat(Format format, Guid tokenId);
        bool DeleteFormat(Guid id, Guid tokenId);
        bool UpdateFormat(Guid id, Format newFormat, Guid tokenId);
    }
}
