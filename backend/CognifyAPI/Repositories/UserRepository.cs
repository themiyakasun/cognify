using CognifyAPI.Data;
using CognifyAPI.Dtos;
using CognifyAPI.Dtos.User;
using CognifyAPI.Interfaces;
using CognifyAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CognifyAPI.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailRepository _emailRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ILecturerRepository _lecturerRepository;
        public UserRepository(ApplicationDbContext dbContext, IConfiguration configuration, UserManager<ApplicationUser> userManager, IEmailRepository emailRepository, IStudentRepository studentRepository, ILecturerRepository lecturerRepository) 
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _userManager = userManager;
            _emailRepository = emailRepository;
            _studentRepository = studentRepository;
            _lecturerRepository = lecturerRepository;
        }

        public async Task<UserDeleteResponseDto> DeleteAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null) return new UserDeleteResponseDto { ErrorStatus = ErrorStatus.NotFound, Message = "User cannot be found" };

            if(user.UserType == UserTypes.Student)
            {
                var student = await _studentRepository.GetAsync(s => s.UserId == id);
                await _studentRepository.DeleteAsync(student!);
            }

            if(user.UserType == UserTypes.Lecturer)
            {
                var lecturer = await _lecturerRepository.GetAsync(l => l.UserId == id);
                await _lecturerRepository.DeleteAsync(lecturer!);
            }

            await _userManager.DeleteAsync(user);

            return new UserDeleteResponseDto {  ErrorStatus = ErrorStatus.Success, ApplicationUser = user, Message = "User deleted successfully"};
        }

        public async Task<(ErrorStatus ErrorStatus, string Message)> EmailVerificationAsync(string email, string code)
        {

            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) return new( ErrorStatus.NotFound, "User cannot be found");

            var isVerified = await _userManager.ConfirmEmailAsync(user, code);

            if (isVerified.Succeeded)
            {
                return new
                (
                    ErrorStatus.Success,
                    "Email verified successfully"
                );
            }

            var errorMessage = string.Join(", ", isVerified.Errors.Select(e => e.Description));
            return new (ErrorStatus.Error, errorMessage);
        }

        public string GenerateToken(ApplicationUser user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSettings:Token")!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("AppSettings:Issuer"),
                audience: _configuration.GetValue<string>("AppSettings:Audience"),
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<LoginResponseDto> LoginAsync(LoginDto requestDto)
        {
            var existingUser = await _userManager.FindByEmailAsync(requestDto.Email);

            if (existingUser == null) return new LoginResponseDto{ LoginStatus = ErrorStatus.NotFound, Message = "User with this email cannot be found" };

            if (existingUser.Status != UserStatus.Active) return new LoginResponseDto { LoginStatus = ErrorStatus.Forbidden, Message = "You'r not an active user" };

            var isVerified = await _userManager.IsEmailConfirmedAsync(existingUser);

            if (!isVerified) return new LoginResponseDto { LoginStatus = ErrorStatus.Unauthorized, Message = "Email not verified" };

            if (existingUser != null)
            {
                var token = GenerateToken(existingUser);
                return new LoginResponseDto
                {
                    LoginStatus = ErrorStatus.Success,
                    LoginResult = new LoginResult
                    {
                        User = existingUser,
                        Token = token
                    },
                    Message = "Login Successfull"
                };
            }
            return new LoginResponseDto { LoginStatus = ErrorStatus.Error, Message = "Login Unsuccessfull" };
        }

        public async Task<(bool success, string message)> RegisterAsync(RegisterUserDto requestDto)
        {
            var userExists = await _userManager.FindByEmailAsync(requestDto.UserData.Email);

            if (userExists != null) return (false, "User already exists with this email");
            ;

            var newUser = new ApplicationUser()
            {
                Email = requestDto.UserData.Email,
                UserName = requestDto.UserData.Name,
                Bio = requestDto.UserData.Bio,
                ProfilePictureUrl = requestDto.UserData.ProfilePictureUrl,
                UserType = requestDto.UserData.UserType,
                Status = requestDto.UserData.Status

            };

            var isCreated = await _userManager.CreateAsync(newUser, requestDto.UserData.Password);

            if (isCreated.Succeeded)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);

                await _emailRepository.SendEmail(newUser.Email, "Email Verification", code);

                if (requestDto.UserData.UserType == UserTypes.Student && requestDto.StudentData != null)
                {
                    var newStudent = new Student()
                    {
                        UserId = newUser.Id,
                        Gender = requestDto.StudentData.Gender,
                    };

                    try
                    {
                        await _studentRepository.CreateAsync(newStudent);
                    }
                    catch (Exception ex)
                    {
                        return (false, $"Failed to create student: {ex.Message}");
                    }
                }

                if (requestDto.UserData.UserType == UserTypes.Lecturer && requestDto.LecturerData != null)
                {
                    var newLecturer = new Lecturer()
                    {
                        UserId = newUser.Id,
                        ContactNumber = requestDto.LecturerData.ContactNumber,
                        LinkedinUrl = requestDto.LecturerData.LinkedinUrl,
                        WebsiteUrl = requestDto.LecturerData.WebsiteUrl,

                    };

                    try
                    {
                        await _lecturerRepository.CreateAsync(newLecturer);

                    } catch(Exception ex)
                    {
                        return (false, $"Failed to create lecturer: {ex.Message}");
                    }
                }

                return (true,  "Email sent successfully" );
            }
            var errorMessage = string.Join(", ", isCreated.Errors.Select(e => e.Description));
            return (false, errorMessage);

        }

    }
}
