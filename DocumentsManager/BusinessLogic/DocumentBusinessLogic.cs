using DocumentsManager.Data.DA.Handler;
using DocumentsMangerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.BusinessLogic
{
    public class DocumentBusinessLogic
    {
        private void AddDateValue(List<DateTime> allDates, ChartIntDate chart)
        {
            foreach (var item in allDates)
            {
                chart.AddValueToDate(item);
            }
        }
        public Document GetDocumentById(Guid id)
        {
            DocumentContext context = new DocumentContext();
            Document documentFromBD = context.GetById(id);
            FooterBusinessLogic footerLogic = new FooterBusinessLogic();
            documentFromBD.Footer = footerLogic.GetById(documentFromBD.Footer.Id);
            HeaderBusinessLogic headerLogic = new HeaderBusinessLogic();
            documentFromBD.Header = headerLogic.GetById(documentFromBD.Header.Id);
            FormatBusinessLogic formatLogic = new FormatBusinessLogic();
            documentFromBD.Format = formatLogic.GetById(documentFromBD.Format.Id);
            StyleClassBusinessLogic styleClassLogic = new StyleClassBusinessLogic();
            documentFromBD.StyleClass = styleClassLogic.GetById(documentFromBD.StyleClass.Id);
            ParragraphBusinessLogic parragraphLogic = new ParragraphBusinessLogic();
            List<Parragraph> parragraphs = new List<Parragraph>();
            foreach (var item in documentFromBD.Parragraphs)
            {
                parragraphs.Add(parragraphLogic.GetById(item.Id));
            }
            documentFromBD.Parragraphs = parragraphs;
            return documentFromBD;

        }
        public ChartIntDate GetChartFromDocument(List<DateTime> allDates, DateTime since, DateTime until)
        {
            ChartIntDate chart = new ChartIntDate();
            chart.GenerateDates(since, until);
            AddDateValue(allDates, chart);
            return chart;
        }
        public List<DateTime> GetDatesFromModifyDocument(Document document)
        {
            List<DateTime> allDates = new List<DateTime>();
            allDates.Add(document.CreationDate);
            ModifyDocumentHistoryContext contextModify = new ModifyDocumentHistoryContext();
            foreach (var item in contextModify.GetAllHistories())
            {
                if (item.Document.Equals(document))
                {
                    allDates.Add(item.Date);
                }
            }
            return allDates;
        }
    }
}
