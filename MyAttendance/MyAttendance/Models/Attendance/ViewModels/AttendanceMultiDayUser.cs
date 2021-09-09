using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAttendance.Models.Attendance.ViewModels
{
    public class AttendanceMultiDayUser
    {
        public string Name { get; set; }
        public int RollNo { get; set; }
        public List<string> Status { get; set; }
    }
}