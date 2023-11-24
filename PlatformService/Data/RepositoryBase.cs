using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace PlatformService.Data
{
    public class RepositoryBase<TDbContext, TEntity> : IRepository<TEntity> where TDbContext : DbContext where TEntity : class, IEntity, new()
    {
        private readonly TDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        protected TDbContext Context => _context;

        public RepositoryBase(TDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
            SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            SaveChanges();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            IQueryable<TEntity> source = _dbSet.Where(where);
            return source.FirstOrDefault() ?? new TEntity();
        }

        public virtual bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}