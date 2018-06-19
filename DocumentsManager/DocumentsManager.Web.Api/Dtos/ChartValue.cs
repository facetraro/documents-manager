using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentsManager.Web.Api.Dtos
{
    public class ChartValue
    {
        public string Value { get; set; }
        public string Date { get; set; }
        public ChartValue(string Date, string Value)
        {
            this.Value = Value;
            this.Date = Date;
        }
    }
}