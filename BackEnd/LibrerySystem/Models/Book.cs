using System.ComponentModel.DataAnnotations.Schema;

namespace LibrerySystem.Models
{
    public class Book
    {
        public Book()
        {
            Loans = new List<Loan>();
        }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public DateTime PublichDate { get; set; }
        public int ISBN { get; set; }
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }
        public List<Loan> Loans { get; set; }
    }
}
