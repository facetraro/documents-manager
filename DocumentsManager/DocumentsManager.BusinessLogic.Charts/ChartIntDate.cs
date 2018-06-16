using DocumentsManager.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.BusinessLogic.Charts
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
        public void AddValueToDate(DateTime date)
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

            return AreSameLength(anotherChart) && AreSequenceEquals(anotherChart);
        }
        private bool AreSameLength(ChartIntDate anotherChart)
        {
            return AreValidLength(anotherChart) && AreTheSameLength(anotherChart);
        }
        private bool AreTheSameLength(ChartIntDate anotherChart)
        {
            return anotherChart.GetLength() == GetLength();
        }
        private bool AreValidLength(ChartIntDate anotherChart)
        {
            return HasValidLength() && anotherChart.HasValidLength();
        }
        private bool HasValidLength()
        {
            return Date.Count == Value.Count;
        }
        private int GetLength()
        {
            return Date.Count;
        }
        private String GetString()
        {
            String toString = string.Empty;
            for (int i = 0; i < GetLength(); i++)
            {
                toString += "[Documentos:" + Value[i] + "- Fecha:" + Date[i].ToString(formatDate) + "]";
            }
            return toString;
        }

        public override string ToString()
        {
            return GetString();
        }
    }
}
