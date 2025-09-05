using CognifyAPI.Models;

namespace CognifyAPI.Dtos.User
{
    public class UserDeleteResponseDto
    {
        public ErrorStatus ErrorStatus { get; set; }
        public ApplicationUser? ApplicationUser {get; set; }
        public string? Message { get; set; }
    }
}
