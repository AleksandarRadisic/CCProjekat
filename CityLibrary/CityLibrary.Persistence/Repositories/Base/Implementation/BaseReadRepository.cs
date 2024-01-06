using CityLibrary.Domain.PersistenceInterfaces.Base;
using CityLibrary.Persistence.EfStructures;
using Microsoft.EntityFrameworkCore;

namespace CityLibrary.Persistence.Repositories.Base.Implementation
{
    public class BaseReadRepository<TKey, TEntity> : IBaseReadRepository<TKey, TEntity> where TEntity : class, new()
    {
        private readonly AppDbContext _context;

        protected BaseReadRepository(AppDbContext context)
        {
            _context = context;
        }

        public virtual TEntity GetById(TKey id)
        {
            var set = GetSet();
            return set.Find(id);
        }

        protected DbSet<TEntity> GetSet()
        {
            return _context.Set<TEntity>();
        }
    }
}
