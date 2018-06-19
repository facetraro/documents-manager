using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.ProxyInterfaces
{
    public interface IUserBusinessLogic
    {
        Guid CreateADocument(Document doc, Guid tokenId);
        bool UpdateADocument(Guid id, Document aDocument, Guid tokenId);
        bool DeleteADocument(Document aDocument, Guid tokenId);
        List<Document> GetDocumentsFromUser(User user, Guid tokenId);
    }
}
