using DocumentsManager.Exceptions;
using System;
using System.Collections.Generic;

namespace DocumentsManager.BusinessLogic
{
    public class ChartIntDate
    {
        private static string formatDate = "d";
        private List<int> Value = new List<int>();
        private List<DateTime> Date = new List<DateTime>();
        public void AddTuple(int value, DateTime date)
        {
            Value.Add(value);
            Date.Add(date);
        }
        private bool IsSinceDateBefore(DateTime since, DateTime until)
        {
            int result = DateTime.Compare(since, until);
            return result < 0;
        }
        public void AreDatesCorrect(DateTime since, DateTime until)
        {
            if (!IsSinceDateBefore(since, until))
            {
                throw new InvalidChartDatesException();
            }
        }
        public void LoadAllDates(DateTime since, DateTime until)
        {
            DateTime actualDate = since;
            while (IsSinceDateBefore(actualDate, until))
            {
                AddTuple(0, actualDate);
                actualDate = actualDate.AddDays(1);
            }
        }
        public void GenerateDates(DateTime since, DateTime until)
        {
            AreDatesCorrect(since, until);
            LoadAllDates(since, until);
        }
        public bool IsTheSameDate(int i, DateTime date)
        {
            return Date[i].ToString(formatDate).Equals(date.ToString(formatDate));
        }
        public void AddDocumentByDate(DateTime date)
        {
            for (int i = 0; i < Date.Count; i++)
            {
                if (IsTheSameDate(i, date))
                {
                    Value[i]++;
                }
            }
        }
        private bool AreEqualsByPosition(ChartIntDate anotherChart, int i)
        {
            bool validationDate = anotherChart.Date[i].ToString(formatDate).Equals(Date[i].ToString(formatDate));
            bool validationValue = anotherChart.Value[i] == Value[i];
            return validationDate && validationValue;
        }
        private bool AreSequenceEquals(ChartIntDate anotherChart)
        {
            bool validation = true;
            int length = anotherChart.Date.Count;
            for (int i = 0; i < length; i++)
            {
                if (!AreEqualsByPosition(anotherChart, i))
                {
                    validation = false;
                }
            }
            return validation;
        }
        public override bool Equals(object obj)
        {
            ChartIntDate anotherChart = obj as ChartIntDate;
            return AreSequenceEquals(anotherChart);
        }
    }
}