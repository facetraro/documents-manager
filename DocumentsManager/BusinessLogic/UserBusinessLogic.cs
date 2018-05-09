using DocumentsManager.Data.DA.Handler;
using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.BusinessLogic
{
    public class UserBusinessLogic
    {
        private void AddDocumentByDate(List<Document> documents, ChartIntDate chart)
        {
            foreach (var item in documents)
            {
                chart.AddValueToDate(item.CreationDate);
            }
        }
        public ChartIntDate GetChartFromDocuments(List<Document> documents, DateTime since, DateTime until)
        {
            ChartIntDate chart = new ChartIntDate();
            chart.GenerateDates(since, until);
            AddDocumentByDate(documents, chart);
            return chart;
        }
        public ChartIntDate GetChartFromADocument(Document document, DateTime since, DateTime until)
        {
            DocumentBusinessLogic documentLogic = new DocumentBusinessLogic();
            return documentLogic.GetChartFromDocument(documentLogic.GetDatesFromModifyDocument(document), since, until);
        }
        private void AddModifyHistory(User user, Document doc)
        {
            ModifyDocumentHistory history = new ModifyDocumentHistory();
            history.Document = doc;
            history.User = user;
            history.Date = DateTime.Today;
            history.Id = Guid.NewGuid();
            ModifyDocumentHistoryContext modifyContext = new ModifyDocumentHistoryContext();
            modifyContext.Add(history);
        }
        public void ModifyDocument(User user, Document doc)
        {
            AddModifyHistory(user, doc);
        }
    }
}