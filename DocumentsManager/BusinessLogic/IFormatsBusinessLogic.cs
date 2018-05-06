using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.BusinessLogic
{
    public interface IFormatsBusinessLogic
    {
        IEnumerable<Format> GetAllFormats();
        Format GetByID(Guid id);
        Guid Add(Format format);
        bool Delete(Guid id);
        bool Update(Guid id, Format newFormat);
    }
}