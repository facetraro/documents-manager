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
        public List<Document> GetLazy()
        {
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                return unitOfWork.DocumentRepository.Get().ToList();
            }
        }
        public void Add(Document aDocument)
        {
            FooterContext fContext = new FooterContext();
            HeaderContext hContext = new HeaderContext();
            ParragraphContext pContext = new ParragraphContext();
            fContext.Add(aDocument.Footer);
            hContext.Add(aDocument.Header);
            List<Parragraph> theParragraphs = aDocument.Parragraphs;
            aDocument.Parragraphs = new List<Parragraph>();
            using (var db = new ContextDataAccess())
            {
                var unitOfWork = new UnitOfWork(db);
                db.Styles.Attach(aDocument.StyleClass);
                aDocument.Format = db.Formats.Find(aDocument.Format.Id);
                aDocument.CreatorUser = db.Users.Find(aDocument.CreatorUser.Id);
                aDocument.Footer = db.Footers.Find(aDocument.Footer.Id);
                aDocument.Header = db.Headers.Find(aDocument.Header.Id);
                unitOfWork.DocumentRepository.Insert(aDocument);
            }
            for (int i = 0; i < theParragraphs.Count; i++)
            {
                pContext.Add(theParragraphs.ElementAt(i));
            }
        }
    }
}
