namespace MyAttendance.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AttendanceStatu
    {
        public int Id { get; set; }

        public int ClassId { get; set; }

        public int DateId { get; set; }

        public int IsAttendanceCompleteFlag { get; set; }
    }
}
