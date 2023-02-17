using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoursManagement.Model
{
    public class WeekHours
    {
        public int WeekNumber { get; set; }
        public List<DayHours> Days { get; set; }

        public WeekHours()
        {
            WeekNumber = HoursManagermentLogic.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);

            Days = new List<DayHours>();
        }
    }
}
