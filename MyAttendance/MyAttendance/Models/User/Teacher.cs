using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyAttendance.Models.User
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        [ForeignKey("UserModel")]
        public int UserId { get; set; }
        public UserModel UserModel { get; set; }


    }
}