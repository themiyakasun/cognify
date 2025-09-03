using System.Linq.Expressions;

namespace CognifyAPI.Interfaces
{
    public interface IApplicationRepository<T>
    {
        Task<T> CreateAsync(T dbRecord);
        Task<T> UpdateAsync(T dbRecord);
        Task<List<T>> GetAllAync();
        Task<T?> GetAsync(Expression<Func<T, bool>> filter);
        Task<T> DeleteAsync(T dbRecord);
    }
}
