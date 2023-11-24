using System.Linq.Expressions;

namespace TrainWell___BACKEND.SqlRepository
{
    public interface ISqlRepository<T>
    {
        Task AddAsync(T entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task UpdateAsync(T entity);
        IQueryable<T> Include(params Expression<Func<T, object>>[] includes);

    }
}