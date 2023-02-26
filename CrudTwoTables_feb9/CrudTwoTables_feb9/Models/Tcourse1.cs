using System;
using System.Collections.Generic;

namespace CrudTwoTables_feb9.Models
{
    public partial class Tcourse1
    {
        public Tcourse1()
        {
            Tstudent1s = new HashSet<Tstudent1>();
        }

        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public int? CourseFee { get; set; }

        public virtual ICollection<Tstudent1> Tstudent1s { get; set; }
    }
}
