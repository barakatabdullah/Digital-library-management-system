using AutoMapper;
using LibrerySystem.DTOs;
using LibrerySystem.Models;
using LibrerySystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibrerySystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly AppDbContext _context;

        public AccountController(IMapper mapper,IUserService userService,
            AppDbContext context)
        {
            this._mapper = mapper;
            this._userService = userService;
            this._context = context;
        }
        // GET: api/<AccountController>
        /// <summary>
        /// register new User
        /// </summary>
        /// <remarks>register the User with the provided model data</remarks>
        /// <param name="registerDTO"></param>
        /// <returns>new User pls Token and releted info</returns>
        /// <response code="201">Registering the new User has been done successfully</response>
        /// <response code="400">The data provided did not satisfy the model requirements</response>
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
                if ( _userService.EmailAlreadyExsist(registerDto.Email))
                {
                    return BadRequest("Email Alredy Exsist");

                }
                //Create the user
                var user = await _userService.CreateUser(registerDto);

                //mapping the created User to the AuthenticatedUserDTO
                var authenticatedUserDTO = _mapper.Map<AuthenticatedUserDTO>(user);
                //setting the token
                authenticatedUserDTO.JWToken = _userService.CreateToken(authenticatedUserDTO.Email);
                return Created($"/Get/{authenticatedUserDTO.Id}", authenticatedUserDTO);
            }
        }
        /// <summary>
        /// Login the User
        /// </summary>
        /// <remarks>Login the User with the provided credentials</remarks>
        /// <param name="loginDTO"></param>
        /// <returns>the User info and related info + the JWT Token</returns>
        /// <response code="200">The login succeed</response>
        /// <response code="401">The login failed</response>
        /// <response code="400">The data provided did not satisfy the model requirements or 
        /// the Email or password incorract</response>
        [HttpPost, ActionName("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (await _userService.ValidateUser(loginDTO) == false)
            {
                return BadRequest("Email or password incorract");
            }
            //getting the User info
            var user = await _userService.GetUserByEmail(loginDTO.Email);
            var authenticatedUserDTO = _mapper.Map<AuthenticatedUserDTO>(user);
            //setting the token
            authenticatedUserDTO.JWToken = _userService.CreateToken();
            return Ok(authenticatedUserDTO);
        }
        /// <summary>
        /// Get one user
        /// </summary>
        /// <remarks>Get the user based on the userId</remarks>
        /// <param name="userId">the user Id</param>
        /// <returns>The requsted user from the database</returns>
        /// <response code="200">Fetching the user has been done successfully</response>
        /// <response code="404">There is no user matching the id in the database</response>
        [HttpGet, ActionName("get")]
        public async Task<ActionResult<UserDTO>> Get(int userId)
        {
            var user = await _context.Users.Where(a => a.Id.Equals(userId))
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }
            var userDTO = _mapper.Map<UserDTO>(user);
            return Ok(userDTO);
        }

        /// <summary>
        /// update a user account info
        /// </summary>
        /// <remarks>update a user account info with the provided model data</remarks>
        /// <param name="id">the id of the user to update</param>
        /// <param name="updateUserDTO">the new data model</param>
        /// <returns></returns>
        /// <response code="204">Updateing the user account info has been done successfully</response>
        /// <response code="400">The data provided did not satisfy the model requirements or Concurrency error</response>
        /// <response code="404">There is no active user matching the id in the database</response>
        [HttpPut("{id}"), ActionName("update-user-account-info")]
        public async Task<IActionResult> UpdateUserInfo(int id, UpdateUserDTO updateUserDTO)
        {
            var user = await _context.Users.FindAsync(id);
            
            //check if email dose not Already Exsist
            if (_userService.EmailAlreadyExsist(updateUserDTO.Email, id))
            {
                return BadRequest("This Email Already Exsist");
            }
            _mapper.Map(updateUserDTO, user);
            _context.Users.Update(user!);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                return BadRequest(e.Message);
            }
            return NoContent();
        }
    }
}
