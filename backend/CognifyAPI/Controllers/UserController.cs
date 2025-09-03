using CognifyAPI.Dtos.User;
using CognifyAPI.Interfaces;
using CognifyAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CognifyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly IEmailRepository _emailRepository;
        public UserController(UserManager<ApplicationUser> userManager, IUserRepository userRepository, IEmailRepository emailRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _emailRepository = emailRepository;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto requestDto)
        {
            var userExists = await _userManager.FindByEmailAsync(requestDto.Email);

            if (userExists != null) return Conflict("User already exists with this email");

            var newUser = new ApplicationUser()
            {
                Email = requestDto.Email,
                UserName = requestDto.Name,
                Bio = requestDto.Bio,
                ProfilePictureUrl = requestDto.ProfilePictureUrl,
                UserType = requestDto.UserType,
                Status = requestDto.Status

            };

            var isCreated = await _userManager.CreateAsync(newUser, requestDto.Password);

            if (isCreated.Succeeded)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);

                await _emailRepository.SendEmail(newUser.Email, "Email Verification", code);

                return Ok(new { message = "Email sent successfully" });
            }

            return BadRequest(isCreated.Errors);

        }
        [HttpPost]
        [Route("emailVerification")]
        public async Task<IActionResult> EmailVerification(string? email, string? code)
        {
            if (email == null || code == null) return BadRequest("Invalid Payload");

            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) return BadRequest("User cannot be found");

            var isVerified = await _userManager.ConfirmEmailAsync(user, code);

            if (isVerified.Succeeded)
            {
                return Ok(new
                {
                    message = "Email verified successfully"
                });
            }

            return BadRequest(isVerified.Errors);
        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<LoginResponseDto>> Login(LoginDto requestDto)
        {
            if (requestDto.Email == null || requestDto.Password == null) return BadRequest("Enter email and password");

            var existingUser = await _userManager.FindByEmailAsync(requestDto.Email);

            if (existingUser == null) return NotFound("User with this email cannot be found");

            if (existingUser.Status != UserStatus.Active) return Unauthorized("You'r not an active user");

            var isVerified = await _userManager.IsEmailConfirmedAsync(existingUser);

            if (!isVerified) return Unauthorized("Email not verified");

            var token = await _userRepository.LoginAsync(existingUser);

            if (token == null) return BadRequest("Failed to generate token");

            return Ok(new LoginResponseDto
            {
                ApplicationUser = existingUser,
                Token = token
            });
        }

    }
}
