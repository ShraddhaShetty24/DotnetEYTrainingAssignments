using System;
using System.Collections.Generic;

namespace LibraryTestMVC.Models
{
    public partial class StudentT
    {
        public StudentT()
        {
            BorrowTs = new HashSet<BorrowT>();
        }

        public int StudentId { get; set; }
        public string? StudentFirstName { get; set; }
        public string? StudentLastName { get; set; }
        public int? StudentAge { get; set; }

        public virtual ICollection<BorrowT> BorrowTs { get; set; }
    }
}
