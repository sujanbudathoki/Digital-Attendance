using System.ComponentModel.DataAnnotations;

namespace MyAttendance.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required(ErrorMessage = "* Please Include Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Only e.g. a@game.com .")]
        public string Email { get; set; }
        [Required(ErrorMessage = "* Please Include Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }





    }
}