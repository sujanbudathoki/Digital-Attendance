using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyAttendance.Models.Attendance
{
    public class Date
    {
        public int Id { get; set; }
        [Required]
        [BindProperty]
        public DateTime date { get; set; }
        [Required]
        public int isHolidayFlag { get; set; }

       
    }
}