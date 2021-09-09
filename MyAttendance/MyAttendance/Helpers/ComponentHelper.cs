using MyAttendance.Models.Components.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAttendance.Helpers
{
    public static class ComponentHelper
    {
        public static string GetMonth(int month)
        {
            switch (month)
            {
                case 1:
                    return "January";
                case 2:
                    return "Febraury";
                case 3:
                    return "March";
                case 4:
                    return "April";
                case 5:
                    return "May";
                case 6:
                    return "June";
                case 7:
                    return "July";
                case 8:
                    return "August";
                case 9:
                    return "September";
                case 10:
                    return "October";
                case 11:
                    return "November";
                case 12:
                    return "December";
                default:
                    break;
            }
            return "Empty Month";
        }

        public static List<Month> ReturnMonths()
        {
            List<Month> storage = new List<Month>();
            storage.Add(new Month() {MonthNumber= 1,Name= "January" });
            storage.Add(new Month() { MonthNumber = 2, Name = "Feberaury" });
            storage.Add(new Month() { MonthNumber = 3, Name = "March" });
            storage.Add(new Month() { MonthNumber = 4, Name = "April" } );
            storage.Add(new Month() { MonthNumber = 5, Name = "May" });
            storage.Add(new Month() { MonthNumber = 6, Name = "June" });
            storage.Add(new Month() { MonthNumber = 7, Name = "July" });
            storage.Add(new Month() { MonthNumber = 8, Name = "August" });
            storage.Add(new Month() { MonthNumber = 9, Name = "September" });
            storage.Add(new Month() { MonthNumber = 10, Name = "October" });
            storage.Add(new Month() { MonthNumber = 11, Name = "November" });
            storage.Add(new Month() { MonthNumber = 12, Name = "December" });
            return storage;
        }
    }
}