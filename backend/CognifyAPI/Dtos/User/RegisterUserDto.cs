using CognifyAPI.Models;

namespace CognifyAPI.Dtos.User
{
    public class RegisterUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ProfilePictureUrl { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public UserTypes? UserType { get; set; } = UserTypes.Student;
        public UserStatus? Status { get; set; } = UserStatus.Inactive;
    }
}
