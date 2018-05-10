using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.BusinessLogic
{
    public interface IDocumentBusinessLogic
    {
        Document GetDocumentById(Guid id);
        string PrintDocument(Document aDocument);
        IEnumerable<Document> GetAllDocuments();
        Document GetById(Guid id);
    }
}
