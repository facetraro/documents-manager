using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.BusinessLogic
{
    public interface IUsersBusinessLogic
    {
        Guid AddDocument(Document doc);
        void ModifyParragraphs(Document aDocument, User responsibleUser);
        void ModifyDocumentProperties(Document aDocument, User responsibleUser);
        void ModifyDocumentHeader(Document aDocument, User responsibleUser);
        void ModifyDocumentFooter(Document aDocument, User responsibleUser);
        bool UpdateDocument(Guid id, Document aDocument);
        bool DeleteDocument(Document aDocument);
    }
}
