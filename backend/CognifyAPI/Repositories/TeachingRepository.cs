using CognifyAPI.Data;
using CognifyAPI.Interfaces;
using CognifyAPI.Models;

namespace CognifyAPI.Repositories
{
    public class TeachingRepository: ApplicationRepository<Teaching>, ITeachingRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public TeachingRepository(ApplicationDbContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
