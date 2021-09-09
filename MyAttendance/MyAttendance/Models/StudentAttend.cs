namespace MyAttendance.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StudentAttend
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int dateId { get; set; }

        public DateTime CurrentDate { get; set; }

        public int presentFlag { get; set; }

        public virtual Date Date { get; set; }

        public virtual Student Student { get; set; }
    }
}
