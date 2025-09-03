using CognifyAPI.Data;
using CognifyAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CognifyAPI.Repositories
{
    public class ApplicationRepository<T> : IApplicationRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public ApplicationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<T> CreateAsync(T dbRecord)
        {
            await _dbSet.AddAsync(dbRecord);
            await _dbContext.SaveChangesAsync();
            return dbRecord;
        }

        public async Task<T> DeleteAsync(T dbRecord)
        {
            _dbSet.Remove(dbRecord);
            await _dbContext.SaveChangesAsync();
            return dbRecord;
        }

        public async Task<List<T>> GetAllAync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> filter)
        {
            var values = await _dbSet.Where(filter).FirstOrDefaultAsync();

            if (values != null) return values;

            return null;
        }

        public async Task<T> UpdateAsync(T dbRecord)
        {
            _dbContext.Update(dbRecord);
            await _dbContext.SaveChangesAsync();
            return dbRecord;
        }
    }
}
