using System.ComponentModel.DataAnnotations;

namespace MyAttendance.Models.Components
{
    public class StudentView
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Roll { get; set; }
        public string Class { get; set; }
        public int ClassId { get; set; }
    }

}