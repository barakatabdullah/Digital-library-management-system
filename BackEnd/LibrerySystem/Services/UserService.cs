using AutoMapper;
using LibrerySystem.DTOs;
using LibrerySystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace LibrerySystem.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private IConfigurationSection? _jwtSettings;
        private User? _user;

        public UserService(AppDbContext context, IConfiguration configuration,
            IMapper mapper)
        {
            this._context = context;
            this._configuration = configuration;
            this._mapper = mapper;
        }
        const int keySize = 64;
        const int iterations = 350000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;
        private readonly AppDbContext _context;

        public string HashPasword(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(keySize);

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm,
                keySize);

            return Convert.ToHexString(hash);

        }
        public bool VerifyPassword(string password, string hash, byte[] salt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, hashAlgorithm, keySize);
            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
        }

        public bool EmailAlreadyExsist(string email,int? customerId=null)
        {
            if(customerId is null)
             return  _context.Users.Any(x => x.Email == email);
            else
                return  _context.Users.Any(x => x.Email == email && x.Id != customerId);
        }
        /// <summary>
        /// validate the user
        /// </summary>
        /// <param name="loginDTO">the login model to validate</param>
        /// <returns>false if user name or password incorrect otherwise true</returns>
        public async Task<bool> ValidateUser(LoginDTO loginDTO)
        {
            _user = await _context.Users.FirstOrDefaultAsync(a => a.Email.Equals(loginDTO.Email));
            var result = (_user != null && VerifyPassword(loginDTO.Password, _user.PasswordHash,
                _user.PasswordSalt!));
            return result;
        }
        /// <summary>
        /// creates the JWT token based on the claims
        /// </summary>
        /// <returns>the JWT token</returns>
        public string CreateToken(string? newUserEmail = null)
        {
            var signingCredentials = GetSigningCredentials();
            var claims = GetClaims(newUserEmail);
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
        /// <summary>
        /// Getting the Signing Credentials
        /// </summary>
        /// <returns>the customer Signing Credentials</returns>
        public SigningCredentials GetSigningCredentials()
        {
            _jwtSettings = _configuration.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(_jwtSettings["SECRET"] ?? throw new ArgumentNullException("Secret is null"));
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
        /// <summary>
        /// Genrate the customer claims
        /// </summary>
        /// <returns>List of claims</returns>
        public List<Claim> GetClaims(string? newUserEmail = null)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user != null ? _user.Email : newUserEmail!)
            };
            return claims;
        }
        /// <summary>
        /// Genrating the token options
        /// </summary>
        /// <param name="signingCredentials"></param>
        /// <param name="claims"></param>
        /// <returns>the options to configre the appliction</returns>
        public JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials,
                List<Claim> claims)
        {
            _jwtSettings = _configuration.GetSection("JwtSettings");
            var tokenOptions = new JwtSecurityToken
            (
            issuer: _jwtSettings["validIssuer"],
           // audience: _jwtSettings["validAudience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings["expires"])),
            signingCredentials: signingCredentials
            );
            return tokenOptions;
        }   
        /// <summary>
        /// return the customer based on Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>customer + numbers and addresses</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.Where(a => a.Email.Equals(email))
                .FirstOrDefaultAsync() ?? new User();
        }
        public async Task<User> CreateUser(RegisterDTO registerDTO)
        {
            var customer = _mapper.Map<User>(registerDTO);
            //get the hased password and selt from the password
            var hash = HashPasword(registerDTO.Password, out var salt);
            customer.PasswordHash = hash;
            customer.PasswordSalt = salt;
            _context.Users.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
        
        public void SetUser(User user)
        {
            _user = user;
        }
        
        public User? GetUser()
        {
            return _user;
        }
    }
}