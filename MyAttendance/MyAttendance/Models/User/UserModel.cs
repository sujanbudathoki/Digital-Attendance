using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAttendance.Models.User
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "*Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "*Required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "*Required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Password Field is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [NotMapped]

        [Required(ErrorMessage = "Confirm Password Field is required")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [ForeignKey("UserType")]
        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }


    }
}