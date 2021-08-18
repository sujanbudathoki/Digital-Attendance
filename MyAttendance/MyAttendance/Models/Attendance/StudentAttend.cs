using MyAttendance.Models.Components;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAttendance.Models.Attendance
{
    public class StudentAttend
    {
        public int Id { get; set; }

        [ForeignKey("student")]
        public int StudentId { get; set; }

        [ForeignKey("date")]
        public int dateId { get; set; }
        public DateTime CurrentDate { get; set; }

        public int presentFlag { get; set; }

        public Student student { get; set; }

        public Date date { get; set; }
    }
}