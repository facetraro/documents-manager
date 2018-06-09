using System;

namespace DocumentsManager.Data.Logger
{
    public class LoggerType
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string UserBy { get; set; }
        public ActionType Action { get; set; }

        public LoggerType()
        {
            Date = DateTime.Now;
        }

        public override string ToString()
        {
            return Date.ToString() + " - " + Action.ToString() + " - " + UserBy;
        }
    }
}