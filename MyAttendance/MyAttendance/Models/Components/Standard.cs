using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyAttendance.Models.Components
{
    public class Standard
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "*Please Enter Standard Name")]
        public string StandardName { get; set; }

        public virtual ICollection<Student> Students { get; set; }

    }
}