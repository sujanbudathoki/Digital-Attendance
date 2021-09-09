using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAttendance.Models.Components
{
    public class Student
    {
        public int Id { get; set; }
        public int Roll { get; set; }
        public string StudentName { get; set; }

        
        public int ClassId { get; set; }
     
    }
}