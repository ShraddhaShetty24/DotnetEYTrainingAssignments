using System;
using System.Collections.Generic;

namespace LibraryTestMVC.Models
{
    public partial class BookT
    {
        public BookT()
        {
            BorrowTs = new HashSet<BorrowT>();
        }

        public int BookId { get; set; }
        public string? BookName { get; set; }
        public int? BookPageCount { get; set; }
        public int? AuthorId { get; set; }

        public virtual AuthorT? Author { get; set; }
        public virtual ICollection<BorrowT> BorrowTs { get; set; }
    }
}
