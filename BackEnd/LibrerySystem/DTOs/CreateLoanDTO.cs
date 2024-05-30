using LibrerySystem.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrerySystem.DTOs
{
    public class CreateLoanDTO
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
    }
}
