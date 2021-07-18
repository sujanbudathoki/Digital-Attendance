using MyAttendance.Models.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAttendance.ViewModels
{
    public class ClassStudentViewModel
    {
        public int classId { get; set; }
        public IEnumerable<Student> students { get; set; }
    }
}