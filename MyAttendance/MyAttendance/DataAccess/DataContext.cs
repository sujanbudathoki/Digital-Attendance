using MyAttendance.Models.Attendance;
using MyAttendance.Models.Components;
using MyAttendance.Models.User;
using System.Data.Entity;

namespace MyAttendance.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("newDb")
        {

        }

        public DbSet<UserModel> UserModels { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Standard> Standards { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<Date> Dates { get; set; }
        public DbSet<StudentAttend> Attends { get; set; }
        public DbSet<AttendanceStatus> AttendanceStatus { get; set; }

    }
}