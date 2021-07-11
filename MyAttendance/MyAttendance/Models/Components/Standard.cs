using MyAttendance.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAttendance.Models.Components
{
    public class Standard
    {
        public int Id { get; set; }
        public string StandardName { get; set; }
        public virtual ICollection<Student> students { get; set; }
    }
}