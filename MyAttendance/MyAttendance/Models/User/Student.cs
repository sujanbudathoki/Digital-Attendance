using MyAttendance.Models.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyAttendance.Models.User
{
    public class Student
    {
        public int Id { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }

        [ForeignKey("Standard")]
        public int StandardId { get; set; }
        [ForeignKey("UserModel")]
        public int UserId { get; set; }
        public UserModel UserModel { get; set; }
        public Standard Standard { get; set; }
    }
}