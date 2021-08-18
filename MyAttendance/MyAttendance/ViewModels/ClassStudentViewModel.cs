using MyAttendance.Models.Components;
using System.Collections.Generic;

namespace MyAttendance.ViewModels
{
    public class ClassStudentViewModel
    {
        public int classId { get; set; }
        public IList<Student> students { get; set; }
    }
}