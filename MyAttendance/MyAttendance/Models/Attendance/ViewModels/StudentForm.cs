using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyAttendance.Models.Attendance
{

    public class StudentForm
    {
        [BindProperty]
        public List<StudentAttendView> students { get; set; }
    }
}