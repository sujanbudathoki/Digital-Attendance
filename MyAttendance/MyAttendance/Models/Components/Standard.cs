using MyAttendance.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyAttendance.Models.Components
{
    public class Standard
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="*Please Enter Standard Name")]
        public string StandardName { get; set; }
        
    }
}