using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoursManagement.Model
{
    public class DayHours
    {
        public string Label { get; set; }
        public int Number { get; set; }
        public List<Schedule> Schedules { get; set; }

        public DayHours()
        {
            Label = HoursManagermentLogic.Calendar.GetDayOfWeek(DateTime.Now).ToString();
            Number = HoursManagermentLogic.Calendar.GetDayOfMonth(DateTime.Now);

            Schedules = new List<Schedule>();
        }

        public TimeSpan GetTotalTime()
        {
            TimeSpan result = TimeSpan.Zero;

            foreach(var s in Schedules)
            {
                result = result.Add(s.Duration);
            }

            return result;
        }
    }
}
