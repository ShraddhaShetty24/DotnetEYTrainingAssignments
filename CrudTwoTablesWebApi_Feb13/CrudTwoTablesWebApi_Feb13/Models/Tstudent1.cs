using CrudTwoTablesWebApi_Feb13.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudTwoTablesWebApi_Feb13.Models
{
    public partial class Tstudent1
    {
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public string? StudentAddress { get; set; }
        public int CourseId { get; set; }

       // [ForeignKey("CourseId")]
        public virtual Tcourse1 Course { get; set; } = null!;
    }
}
