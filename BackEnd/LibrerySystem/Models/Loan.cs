using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrerySystem.Models
{
    public class Loan
    {
        public int LoanId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsReturned { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        [ForeignKey(nameof(UserId))]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public User User { get; set; } = null!;
        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; }=  null!;

    }
}
