using DocumentsManager.Data.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.BusinessLogic
{
    public interface ILoggerMethod
    {
        void AddLogger(LoggerType log);
        List<LoggerType> GetLoggers(DateTime dateSince, DateTime dateUntil);
    }
}
