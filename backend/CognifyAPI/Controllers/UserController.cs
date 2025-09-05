using CognifyAPI.Dtos;
using CognifyAPI.Dtos.Lecturer;
using CognifyAPI.Dtos.Student;
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
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }

        [HttpPost]
        [Route("register/student")]
        public async Task<IActionResult> RegisterStudent([FromBody] StudentPostDto requestDto)
        {
            var registerDto = new RegisterUserDto()
            {
                UserData = requestDto.UserData,
                StudentData = requestDto.StudentData,
            };

            var result = await _userRepository.RegisterAsync(registerDto);

            if (result.success) 
            {
                return Ok(new { result.message });
            }

            return BadRequest(new { result.message });
        }
        [HttpPost]
        [Route("register/lecturer")]
        public async Task<IActionResult> RegisterLecturer([FromBody] LecturerRegisterDto requestDto)
        {
            var registerDto = new RegisterUserDto()
            {
                UserData = requestDto.UserData,
                LecturerData = requestDto.LecturerData,
            };

            var result = await _userRepository.RegisterAsync(registerDto);

            if (result.success)
            {
                return Ok(new { result.message });
            }

            return BadRequest(new { result.message });
        }
        [HttpPost]
        [Route("emailVerification")]
        public async Task<IActionResult> EmailVerification(string? email, string? code)
        {
            if (email == null || code == null) return BadRequest("Invalid Payload");

            var result = await _userRepository.EmailVerificationAsync(email, code);

            if (result.ErrorStatus == ErrorStatus.NotFound) return NotFound(result.Message);

            if (result.ErrorStatus == ErrorStatus.Error) return BadRequest(result.Message);

            return Ok(result.Message);
        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<LoginResult>> Login(LoginDto requestDto)
        {
            if (requestDto.Email == null || requestDto.Password == null) return BadRequest("Enter email and password");

            var result = await _userRepository.LoginAsync(requestDto);

            if (result.LoginStatus == ErrorStatus.NotFound) return NotFound(result.Message);

            if (result.LoginStatus == ErrorStatus.Forbidden) return Unauthorized(result.Message);

            if (result.LoginStatus == ErrorStatus.Unauthorized) return Unauthorized(result.Message);

            if (result.LoginStatus == ErrorStatus.Error) return BadRequest(result.Message);

            return Ok(result.LoginResult);

        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult<ApplicationUser>> Delete([FromRoute] string id)
        {
            var result = await _userRepository.DeleteAsync(id);

            if (result.ErrorStatus == ErrorStatus.NotFound) return NotFound(result.Message);

            if(result.ApplicationUser == null) return NotFound(result.Message);

            return result.ApplicationUser;
        }


    }
}
