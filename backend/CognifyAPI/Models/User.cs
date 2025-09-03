namespace CognifyAPI.Models
{
    public enum UserRoles
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

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string ProfilePictureUrl {  get; set; } = string.Empty;
        public string Bio {  get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastLogin {  get; set; } = DateTime.Now;
        public UserRoles? Role { get; set; } = UserRoles.Student;
        public UserStatus? Status { get; set; } = UserStatus.Inactive;
        public Student Student { get; set; }
        public Lecturer Lecturer { get; set; }
        public Admin Admin { get; set; }

    }
}
