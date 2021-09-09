using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAttendance.Models.User.ViewModel
{


    public class UserIndexViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string RoleType { get; set; }
    }

    public class UserTypeList
    {
        public List<UserIndexViewModel> HOD { get; set; }
        public List<UserIndexViewModel> Teacher { get; set; }
        public List<UserIndexViewModel> Students { get; set; }
    }
}