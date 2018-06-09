﻿using DocumentsManager.Data.DA.Handler;
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

        public List<LoggerType> GetLoggers()
        {
            return context.GetLazy();
        }
    }
}