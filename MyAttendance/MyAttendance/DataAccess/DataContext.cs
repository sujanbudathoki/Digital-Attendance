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

    }
}