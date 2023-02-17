using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoursManagement.Model
{
    public class Schedule
    {
        public DateTime StartTime { get; set; } = DateTime.MinValue;
        public DateTime EndTime { get; set; } = DateTime.MinValue;
        public TimeSpan Duration => StartTime != DateTime.MinValue && EndTime != DateTime.MinValue ? EndTime - StartTime : TimeSpan.Zero;
    }
}
