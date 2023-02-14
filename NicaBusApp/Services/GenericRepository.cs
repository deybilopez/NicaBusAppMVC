using Microsoft.EntityFrameworkCore;
using NicaBusApp.Data;

namespace NicaBusApp.Services
{
    public class GenericRepository<T>: IGnericRepository<T> where T : class
    {

        protected NicaBusAppContext _context;
        internal DbSet<T> _dbSet;

        public GenericRepository(NicaBusAppContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();

        }   
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public virtual async void Add(T entity)
        {
            throw new NotImplementedException();

        }


        public virtual async void Delete(int id)
        {
            throw new NotImplementedException();

        }

        public virtual async void Update(T entity)
        {
            
            throw new NotImplementedException();

        }
    }
}
