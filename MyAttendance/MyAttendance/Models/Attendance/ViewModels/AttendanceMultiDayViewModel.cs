using MyAttendance.Models.Attendance.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAttendance.Models.Attendance
{
    public class AttendanceMultiDayViewModel
    {
        public int ClassId { get; set; }
        public List<DateNumber> DateNumber { get; set; }
        public List<AttendanceMultiDayUser> Studentlist { get; set; }
    }
}