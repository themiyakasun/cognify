using CognifyAPI.Models;

namespace CognifyAPI.Dtos.User
{
    public class LoginResponseDto
    {
        public ApplicationUser ApplicationUser { get; set; }
        public string Token { get; set; }
    }
}
