using CognifyAPI.Data;
using CognifyAPI.Interfaces;
using CognifyAPI.Models;

namespace CognifyAPI.Repositories
{
    public class StudentRepository: ApplicationRepository<Student>, IStudentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
