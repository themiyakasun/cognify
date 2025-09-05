using CognifyAPI.Dtos.User;
using CognifyAPI.Models;

namespace CognifyAPI.Interfaces
{
    public interface IUserRepository
    {
        string GenerateToken(ApplicationUser user);
        Task<LoginResponseDto> LoginAsync(LoginDto requestDto);
        Task<(bool success, string message)> RegisterAsync(RegisterUserDto registerUserDto);
        Task<(ErrorStatus ErrorStatus, string Message)> EmailVerificationAsync(string email, string code);
        Task<UserDeleteResponseDto> DeleteAsync(string id);

    }
}
