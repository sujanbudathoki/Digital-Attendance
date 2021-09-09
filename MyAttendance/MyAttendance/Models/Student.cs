namespace MyAttendance.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            StudentAttends = new HashSet<StudentAttend>();
        }

        public int Id { get; set; }

        public int Roll { get; set; }

        public string StudentName { get; set; }

        public int ClassId { get; set; }

        public virtual Standard Standard { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentAttend> StudentAttends { get; set; }
    }
}
