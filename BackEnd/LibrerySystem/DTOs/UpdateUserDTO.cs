using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LibrerySystem.DTOs
{
    public class UpdateUserDTO
    {
        /// <summary>
        /// user Full Name
        /// </summary>
        ///<example>Abdulraoof Alkhawga</example> 
        [StringLength(100, ErrorMessage = "user Name must be less than 100 char long")]
        [JsonPropertyOrder(1)]
        public string FullName { get; set; } = string.Empty;
        /// <summary>
        /// user Email
        /// </summary>
        /// <example>abdulraoof@outlook.com</example>
        [StringLength(100, ErrorMessage = "Email must be less than 100 char long")]
        [Required]
        [EmailAddress]
        [JsonPropertyOrder(2)]
        public string Email { get; set; } = string.Empty;

    }
}
