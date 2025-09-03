using CognifyAPI.Dtos.User;
using CognifyAPI.Models;

namespace CognifyAPI.Interfaces
{
    public interface IUserRepository: IApplicationRepository<ApplicationUser>
    {
        string GenerateToken(ApplicationUser user);
        Task<string?> LoginAsync(ApplicationUser applicationUser);
    }
}
