using System;
using System.Collections.Generic;

namespace LibraryTestMVC.Models
{
    public partial class AuthorT
    {
        public AuthorT()
        {
            BookTs = new HashSet<BookT>();
            BorrowTs = new HashSet<BorrowT>();
        }

        public int AuthorId { get; set; }
        public string? AuthorName { get; set; }

        public virtual ICollection<BookT> BookTs { get; set; }
        public virtual ICollection<BorrowT> BorrowTs { get; set; }
    }
}
