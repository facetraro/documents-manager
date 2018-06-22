using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.ProxyInterfaces
{
    public interface IDocumentBusinessLogic
    {
        Document GetDocumentById(Guid id, Guid tokenId);
        string PrintDocument(Document aDocument, Guid tokenId);
        IEnumerable<Document> GetAllDocuments(Guid tokenId);
        Document GetFullDocument(Guid id, Guid tokenId);

    }
}
