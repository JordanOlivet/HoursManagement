using HoursManagement.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoursManagement
{
    public static class HoursManagermentLogic
    {
        public static readonly string CONST_DataFilePath = AppDomain.CurrentDomain.BaseDirectory;
        public const string CONST_DataFileName = "data.json";

        public static string GetDataFileFullPath => CONST_DataFilePath + "\\" + CONST_DataFileName;

        public static List<WeekHours> Data { get; set; }
        public static GregorianCalendar Calendar { get; internal set; }

        static HoursManagermentLogic()
        {
            Calendar = new GregorianCalendar();
        }

        public static void LoadData()
        {
            string json = File.ReadAllText(GetDataFileFullPath);

            Data = JsonConvert.DeserializeObject(json) as List<WeekHours>;
        }

        public static void SaveData()
        {
            string json = JsonConvert.SerializeObject(Data);

            File.WriteAllText(GetDataFileFullPath, json);
        }

        public static void AddScheduleToDay(Schedule schedule, DayHours dayHours)
        {
            if(schedule == null) { return; }
            dayHours.Schedules.Add(schedule);
        }

        public static void AddDayToWeek(DayHours dayHours, WeekHours weekHours)
        {
            if(dayHours == null) { return; }
            weekHours.Days.Add(dayHours);
        }
    }
}
