﻿using DocumentsManager.Data.DA.Handler;
using DocumentsManager.Data.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.BusinessLogic
{
    public class LoggerMethodTxt : ILoggerMethod
    {
        public void AddLogger(LoggerType log)
        {
            LoggerContext context = new LoggerContext();
            context.Add(log);
        }

        public List<LoggerType> GetLoggers()
        {
            LoggerContext context = new LoggerContext();
            return context.GetLazy();
        }
    }
}
