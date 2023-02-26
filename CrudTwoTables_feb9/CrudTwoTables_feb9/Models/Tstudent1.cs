using System;
using System.Collections.Generic;

namespace CrudTwoTables_feb9.Models
{
    public partial class Tstudent1
    {
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public string? StudentAddress { get; set; }
        public int CourseId { get; set; }

        public virtual Tcourse1 Course { get; set; } = null!;
    }
}
