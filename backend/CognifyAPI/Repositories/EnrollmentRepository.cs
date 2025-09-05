using CognifyAPI.Data;
using CognifyAPI.Interfaces;
using CognifyAPI.Models;

namespace CognifyAPI.Repositories
{
    public class EnrollmentRepository: ApplicationRepository<Enrollment>, IEnrollmentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EnrollmentRepository(ApplicationDbContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
