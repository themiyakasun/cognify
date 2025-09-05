using CognifyAPI.Data;
using CognifyAPI.Interfaces;
using CognifyAPI.Models;

namespace CognifyAPI.Repositories
{
    public class LecturerRepository: ApplicationRepository<Lecturer>, ILecturerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LecturerRepository(ApplicationDbContext dbContext): base(dbContext) 
        {
            _dbContext = dbContext;
        }
    }
}
