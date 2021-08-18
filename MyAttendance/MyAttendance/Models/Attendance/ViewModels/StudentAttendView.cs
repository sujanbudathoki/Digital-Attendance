using System;

namespace MyAttendance.Models.Attendance
{
    public class StudentAttendView
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public int Roll { get; set; }
        public int ClassId { get; set; }
        public int DateId { get; set; }
   
        public string StudentName { get; set; }
        public DateTime Date { get; set; }
        public bool isPresent { get; set; }
    }
}