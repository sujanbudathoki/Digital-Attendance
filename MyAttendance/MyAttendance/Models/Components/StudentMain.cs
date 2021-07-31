using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAttendance.Models.Components
{
    public class StudentMain
    {
        public string Class { get; set; }
        public int ClassId { get; set; }
        public IEnumerable<StudentView> students { get; set; }
    }
}