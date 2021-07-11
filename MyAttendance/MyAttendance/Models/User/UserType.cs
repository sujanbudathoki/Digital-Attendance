using System.Collections.Generic;

namespace MyAttendance.Models.User
{
    public class UserType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public virtual ICollection<UserModel> UserModels { get; set; }
    }
}