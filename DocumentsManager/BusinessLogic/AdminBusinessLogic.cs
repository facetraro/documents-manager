using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentsMangerEntities;
using DocumentsManager.Data.DA.Handler;

namespace DocumentsManager.BusinessLogic
{
    public class AdminBusinessLogic : IAdminsBusinessLogic
    {
        public ChartIntDate GetChartModificationsByUser(User user, DateTime since, DateTime until)
        {
            DocumentBusinessLogic documentLogic = new DocumentBusinessLogic();
            return GetChartFromDates(GetDatesFromModifyDocument(user, null), since, until);
        }
        public ChartIntDate GetChartCreationByUser(User user, DateTime since, DateTime until)
        {
            DocumentBusinessLogic documentLogic = new DocumentBusinessLogic();
            return GetChartFromDates(GetDatesFromModifyDocument(user, ModifyState.Added), since, until);
        }
        public List<DateTime> GetDatesFromModifyDocument(User user, object state)
        {
            List<DateTime> allDates = new List<DateTime>();
            ModifyDocumentHistoryContext contextModify = new ModifyDocumentHistoryContext();
            foreach (var item in contextModify.GetAllHistories())
            {
                bool validation;
                try
                {
                    ModifyState status = (ModifyState)state;
                    validation = item.User.Equals(user) && item.State == status;
                }
                catch
                {
                    validation = item.User.Equals(user);
                }
                if (validation)
                {
                    allDates.Add(item.Date);
                }
            }
            return allDates;
        }
        private void AddRegisterByDate(List<DateTime> histories, ChartIntDate chart)
        {
            foreach (var item in histories)
            {
                chart.AddValueToDate(item);
            }
        }
        public ChartIntDate GetChartFromDates(List<DateTime> histories, DateTime since, DateTime until)
        {
            ChartIntDate chart = new ChartIntDate();
            chart.GenerateDates(since, until);
            AddRegisterByDate(histories, chart);
            return chart;
        }
        public Guid Add(AdminUser admin)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AdminUser> GetAllAdmins()
        {
            UserContext uContext = new UserContext();
            return uContext.GetAdmins();
        }

        public AdminUser GetByID(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Guid id, AdminUser newAdmin)
        {
            throw new NotImplementedException();
        }
    }
}
