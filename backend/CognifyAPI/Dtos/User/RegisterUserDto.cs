using CognifyAPI.Dtos.Lecturer;
using CognifyAPI.Dtos.Student;
using CognifyAPI.Models;

namespace CognifyAPI.Dtos.User
{

    public class RegisterUserDto
    {
        public UserDto UserData { get; set; }
        public StudentDto? StudentData { get; set; }
        public LecturerPostDto? LecturerData { get; set; }
    }
}
