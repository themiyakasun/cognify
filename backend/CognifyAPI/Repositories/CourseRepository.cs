using CognifyAPI.Data;
using CognifyAPI.Interfaces;
using CognifyAPI.Models;

namespace CognifyAPI.Repositories
{
    public class CourseRepository: ApplicationRepository<Course>, ICourseRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CourseRepository(ApplicationDbContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
