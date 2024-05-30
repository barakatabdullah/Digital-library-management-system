namespace LibrerySystem.DTOs
{
    public class RegisterDTO
    {
        /// <summary>
        /// user Email
        /// </summary>
        /// <example>abdulraoof@outlook.com</example>
        public string Email { get; set; } = string.Empty;
        /// <summary>
        /// user Password
        /// </summary>
        /// <example>111</example>
        public string Password { get; set; } = string.Empty;
        /// <summary>
        /// user Full Name
        /// </summary>
        ///<example>Abdulraoof Alkhawga</example> 
        public string FullName { get; set; } = string.Empty;
    }
}
