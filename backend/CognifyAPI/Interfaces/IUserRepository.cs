using CognifyAPI.Models;

namespace CognifyAPI.Interfaces
{
    public interface IUserRepository: IApplicationRepository<ApplicationUser>
    {
        string GenerateToken(ApplicationUser user);
    }
}
