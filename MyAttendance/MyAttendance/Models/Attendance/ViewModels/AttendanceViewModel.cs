using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAttendance.Models.Attendance.ViewModels
{
    public class AttendanceViewModel
    {
        public string StudentName { get; set; }
        public string RollNumber { get; set; }
        public int isAbsentFlag { get; set; }
    }
}