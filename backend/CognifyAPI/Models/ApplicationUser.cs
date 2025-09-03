using Microsoft.AspNetCore.Identity;

namespace CognifyAPI.Models
{
    public enum UserTypes
    {
        Student,
        Lecturer,
        Admin
    }

    public enum UserStatus
    {
        Active,
        Inactive,
        Suspended
    }

    public class ApplicationUser: IdentityUser
    {
        public string ProfilePictureUrl {  get; set; } = string.Empty;
        public string Bio {  get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastLogin {  get; set; } = DateTime.Now;
        public UserTypes? UserType { get; set; } = UserTypes.Student;
        public UserStatus? Status { get; set; } = UserStatus.Inactive;
        public Student Student { get; set; }
        public Lecturer Lecturer { get; set; }
        public Admin Admin { get; set; }

    }
}
