using LibrerySystem.Models;

namespace LibrerySystem.DTOs
{
    public class AuthenticatedUserDTO : UserDTO
    {
        public string JWToken { get; set; } = string.Empty;
    }
}
