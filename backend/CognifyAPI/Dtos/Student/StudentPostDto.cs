using CognifyAPI.Dtos.User;
using CognifyAPI.Models;

namespace CognifyAPI.Dtos.Student
{
    public class StudentDto
    {
        public string Gender { get; set; }
    }
    public class StudentPostDto
    {
        public UserDto UserData { get; set; }
        public StudentDto StudentData { get; set; }
    }
}
