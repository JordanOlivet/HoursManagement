using HoursManagement;
using HoursManagement.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHoursManagerment
{
    internal class HoursManagementLogicTest
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldLoadData()
        {
            HoursManagermentLogic.LoadData();

            Assert.IsNotNull(HoursManagermentLogic.Data);
        }

        [Test]
        public void ShouldSaveData()
        {
            File.Delete(HoursManagermentLogic.GetDataFileFullPath);

            HoursManagermentLogic.SaveData();

            Assert.IsTrue(File.Exists(HoursManagermentLogic.GetDataFileFullPath));
        }

        [Test]
        public void ShouldAddScheduleToDay()
        {
            DayHours d = new DayHours();

            Schedule s = new Schedule();

            HoursManagermentLogic.AddScheduleToDay(s, d);

            Assert.IsTrue(d.Schedules.Count == 1);
        }

        [Test]
        public void ShouldAddDayToWeek()
        {
            WeekHours w = new WeekHours();

            DayHours d = new DayHours();

            HoursManagermentLogic.AddDayToWeek(d, w);

            Assert.IsTrue(w.Days.Count == 1);
        }

        [Test]
        public void ShouldGetDayTotalTime()
        {
            DayHours d = new DayHours();

            Schedule s1 = new Schedule();
            s1.StartTime = new System.DateTime(1970, 1, 1, 1, 0, 0);
            s1.EndTime = new System.DateTime(1970, 1, 1, 2, 0, 0);

            Schedule s2 = new Schedule();
            s2.StartTime = new System.DateTime(2010, 5, 3, 11, 0, 0);
            s2.EndTime = new System.DateTime(2010, 5, 3, 12, 0, 0);

            HoursManagermentLogic.AddScheduleToDay(s1, d);
            HoursManagermentLogic.AddScheduleToDay(s2, d);


            var totalTime = d.GetTotalTime();

            Assert.IsTrue(totalTime.TotalHours == 2);
        }

    }
}
