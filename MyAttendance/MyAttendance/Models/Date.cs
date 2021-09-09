namespace MyAttendance.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Date
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Date()
        {
            StudentAttends = new HashSet<StudentAttend>();
        }

        public int Id { get; set; }

        public int isHolidayFlag { get; set; }

        [Column("date")]
        public DateTime date1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentAttend> StudentAttends { get; set; }
    }
}
