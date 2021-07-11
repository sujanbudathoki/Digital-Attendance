using System.ComponentModel.DataAnnotations;

namespace MyAttendance.ViewModels
{
    public class Institute
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Institute Name shouldn't be blank.")]
        [StringLength(200, ErrorMessage = "Institute Name should be betn 4 and 200 characters", MinimumLength = 4)]
        public string InstituteName { get; set; }
        [Required(ErrorMessage = "Email Field shouldn't be blank")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Type Input Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Address Field shouldn't be blank")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid ! Phone number")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Password Field is required")]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "Password should be greater than 5 and lower than 20 characters", MinimumLength = 5)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password Field is required")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}