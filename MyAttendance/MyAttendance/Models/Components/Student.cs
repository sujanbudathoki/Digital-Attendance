using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyAttendance.Models.Components
{
    public class Student
    {
        public int Id { get; set; }
        public int Roll { get; set; }
        public string StudentName { get; set; }
        public int ClassId { get; set; }
        [ForeignKey("ClassId")]
        public Standard Standard { get; set; }
    }
}