using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAttendance.Extensions
{
    public static class DateTimeExtensions
    {
        //Extension Method for date time
        public static bool IsInRange(this DateTime checkDate,DateTime fromDate,DateTime toDate)
        {
            return checkDate >= fromDate && checkDate <= toDate;
        }
    }
}