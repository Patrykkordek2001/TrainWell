using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TrainWell___BACKEND.Database;

namespace TrainWell___BACKEND.SqlRepository
{
    public class SqlRepository<T> : ISqlRepository<T> where T : class
    {
        private readonly TrainWellDbContext _context;
        private readonly DbSet<T> _dbSet;

        public SqlRepository(TrainWellDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAllAsyncForUser(int id)
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> Include(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            return includes.Aggregate(query, (current, include) => current.Include(include));
        }



    }
}
