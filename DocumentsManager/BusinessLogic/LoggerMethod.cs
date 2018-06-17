using DocumentsManager.Data.DA.Handler;
using DocumentsManager.Data.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.BusinessLogic
{
    public class LoggerMethod : ILoggerMethod
    {
        private LoggerContext context = new LoggerContext();
        public void AddLogger(LoggerType log)
        {
            log.Id = Guid.NewGuid();
            context.Add(log);
        }

        public List<LoggerType> GetLoggers(DateTime dateSince, DateTime dateUntil)
        {
           List<LoggerType> allLogs = context.GetLazy();
           List<LoggerType> filteredLogs = new List<LoggerType>();
            foreach (LoggerType logi in allLogs)
            {
                if (logi.Date <= dateUntil && logi.Date >= dateSince)
                {
                    filteredLogs.Add(logi);
                }
            }
           return filteredLogs;
        }
    }
}
