using AutoMapper;
using LibrerySystem.DTOs;
using LibrerySystem.Models;

namespace LibrerySystem.Services
{
    public interface IUserService
    {
        bool EmailAlreadyExsist(string email, int? customerId = null);
        string CreateToken(string? newUserEmail = null);
        Task<bool> ValidateUser(LoginDTO loginDTO);
        Task<User> GetUserByEmail(string email);
        Task<User> CreateUser(RegisterDTO registerDTO);
    }
}
