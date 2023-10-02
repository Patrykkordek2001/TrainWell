namespace TrainWell___BACKEND.SqlRepository
{
    public interface ISqlRepository<T>
    {
        Task AddAsync(T entity);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task UpdateAsync(T entity);
    }
}