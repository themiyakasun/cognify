using CognifyAPI.Data;
using CognifyAPI.Interfaces;
using CognifyAPI.Models;

namespace CognifyAPI.Repositories
{
    public class CategoryRepository: ApplicationRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoryRepository(ApplicationDbContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
