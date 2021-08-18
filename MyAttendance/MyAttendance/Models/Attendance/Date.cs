using System;
using System.ComponentModel.DataAnnotations;

namespace MyAttendance.Models.Attendance
{
    public class Date
    {
        public int Id { get; set; }
        [Required]
        public DateTime date { get; set; }
        [Required]
        public int isHolidayFlag { get; set; }

       
    }
}