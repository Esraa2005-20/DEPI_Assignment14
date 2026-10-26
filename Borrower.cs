
using System;
using System.Collections.Generic;

namespace LibrarySystem
{
    public class Borrower
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime MembershipDate { get; set; }

        // Navigation Property
        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}
