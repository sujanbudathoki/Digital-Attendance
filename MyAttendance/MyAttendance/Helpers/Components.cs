using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAttendance.Helpers
{
    public class Components
    {
        public static List<string> getGender()
        {
            List<string> Gender = new List<string>() { "Male","Female"};
            return Gender;
        }
    }
}