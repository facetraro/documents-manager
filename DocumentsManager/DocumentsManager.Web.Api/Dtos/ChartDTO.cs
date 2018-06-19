﻿using DocumentsManager.BusinessLogic.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentsManager.Web.Api.Dtos
{
    public class ChartDto
    {
        public List<ChartValue> Values { get; set; } = new List<ChartValue>();
        public ChartDto(ChartIntDate chart)
        {
            foreach (var item in chart.GetValues())
            {
                ChartValue newValue = new ChartValue(item.Item1,item.Item2);
                Values.Add(newValue);
            }
        }
    }
}