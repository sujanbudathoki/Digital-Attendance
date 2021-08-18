using MyAttendance.Models.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAttendance.Models.Components
{
    public class RoleMapping
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        [ForeignKey("UserId")]
        public UserModel UserModel { get; set; }

        [ForeignKey("RoleId")]
        public UserType UserType { get; set; }
    }
}