using System.Collections.Generic;

namespace MyAttendance.Models.Components
{
    public class StudentMain
    {
        public string Class { get; set; }
        public int ClassId { get; set; }
        public IEnumerable<StudentView> students { get; set; }
    }
}