using System;
using System.Collections.Generic;

namespace LibraryTestMVC.Models
{
    public partial class BorrowT
    {
        public int BorrowId { get; set; }
        public DateTime? TakenDate { get; set; }
        public int? StudentId { get; set; }
        public int? BookId { get; set; }
        public int? AuthorId { get; set; }

        public virtual AuthorT? Author { get; set; }
        public virtual BookT? Book { get; set; }
        public virtual StudentT? Student { get; set; }
    }
}
