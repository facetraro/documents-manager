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
        public ChartIntDate GetChartFromDocument(List<DateTime> allDates, DateTime since, DateTime until)
        {
            ChartIntDate chart = new ChartIntDate();
            chart.GenerateDates(since, until);
            AddDateValue(allDates, chart);
            return chart;
        }
    }
}
