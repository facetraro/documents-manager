using DocumentsManager.Data.Repository;
using DocumentsManagerDataAccess;
using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Data.DA.Handler
{
    public class DocumentContext
    {
        public void Add(Document aDocument)
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                db.Styles.Attach(aDocument.StyleClass);
                db.Formats.Find(aDocument.Format.Id);
               // db.Users
                unitOfWork.DocumentRepository.Insert(aDocument);
            }
        }
    }
}
