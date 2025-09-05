using CognifyAPI.Models;

namespace CognifyAPI.Dtos.User
{
    
    public class LoginResult
    {
        public ApplicationUser? User { get; set; }
        public string? Token { get; set; }
    }
    public class LoginResponseDto
    {
        public ErrorStatus LoginStatus { get; set; }
        public LoginResult? LoginResult { get; set; }
        public string? Message { get; set; }
    }
}
