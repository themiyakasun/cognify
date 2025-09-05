using CognifyAPI.Dtos.User;

namespace CognifyAPI.Dtos.Lecturer
{
    public class LecturerPostDto
    {
        public string Speciality { get; set; }
        public int ContactNumber { get; set; }
        public string? LinkedinUrl { get; set; }
        public string? WebsiteUrl { get; set; }
    }
    public class LecturerRegisterDto
    {
        public UserDto UserData { get; set; }
        public LecturerPostDto LecturerData { get; set; }
    }
}
