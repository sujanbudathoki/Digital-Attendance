using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAttendance.Models.Components
{
    public class AttendanceStatus
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int DateId { get; set; }
        public int IsAttendanceCompleteFlag { get; set; }
    }
}