using MyAttendance.Models.Components;
using MyAttendance.Models.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyAttendance.Models
{
    public class DataContext:DbContext
    {
        public DataContext() : base("newDb")
        {

        }

        public DbSet<UserModel> UserModels { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Standard> Standards { get; set; }
        public DbSet<Student> Students { get; set; } 
    }
}