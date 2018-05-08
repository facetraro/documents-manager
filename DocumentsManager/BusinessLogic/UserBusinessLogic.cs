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
                chart.AddDocumentByDate(item.CreationDate);
            }
        }
        public ChartIntDate GetChartFromDocuments(List<Document> documents, DateTime since, DateTime until)
        {
            ChartIntDate chart = new ChartIntDate();
            chart.GenerateDates(since, until);
            AddDocumentByDate(documents, chart);
            return chart;
        }
    }
}
