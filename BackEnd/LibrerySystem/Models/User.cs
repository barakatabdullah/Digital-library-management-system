using System.Security.Principal;

namespace LibrerySystem.Models
{
    public class User
    {
        public User()
        {
            Books = new List<Book>();
            Loans = new List<Loan>();

        }
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }
        public string PasswordHash { get; set; } = string.Empty;
        public byte[]? PasswordSalt { get; set; }
        public List<Book> Books { get; set; }
        public List<Loan> Loans { get; set; }
    }
}
