using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Hemera.Chat.EFCore;
using Hemera.Chat.Domain.Abstractions;

namespace Hemera.Chat.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        internal HemeraChatDbContext _context;
        private DbSet<T> _table;

        public Repository(HemeraChatDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public virtual async Task<ICollection<T>> GetAllAsyn()
        {

            return await _table.ToListAsync();
        }

        public virtual T Get(int id)
        {
            return _table.Find(id);
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await _table.FindAsync(id);
        }

        public virtual T Add(T t)
        {

            _table.Add(t);
            _context.SaveChanges();
            return t;
        }

        public virtual async Task<T> AddAsyn(T t)
        {
            _table.Add(t);
            await _context.SaveChangesAsync();
            return t;

        }

        public virtual T Find(Expression<Func<T, bool>> match)
        {
            return _table.SingleOrDefault(match);
        }

        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await _table.SingleOrDefaultAsync(match);
        }

        public ICollection<T> FindAll(Expression<Func<T, bool>> match)
        {
            return _table.Where(match).ToList();
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await _table.Where(match).ToListAsync();
        }

        public virtual void Delete(T entity)
        {
            _table.Remove(entity);
            _context.SaveChanges();
        }

        public virtual async Task<int> DeleteAsyn(T entity)
        {
            _table.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public virtual T Update(T t, object key)
        {
            if (t == null)
                return null;
            T exist = _table.Find(key);
            if (exist != null)
            {
                _context.Entry(exist).CurrentValues.SetValues(t);
                _context.SaveChanges();
            }
            return exist;
        }

        public virtual async Task<T> UpdateAsyn(T t, object key)
        {
            if (t == null)
                return null;
            T exist = await _table.FindAsync(key);
            if (exist != null)
            {
                _context.Entry(exist).CurrentValues.SetValues(t);
                await _context.SaveChangesAsync();
            }
            return exist;
        }

        public int Count()
        {
            return _table.Count();
        }

        public async Task<int> CountAsync()
        {
            return await _table.CountAsync();
        }

        public virtual void Save()
        {

            _context.SaveChanges();
        }

        public async virtual Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _table.Where(predicate);
            return query;
        }

        public virtual async Task<ICollection<T>> FindByAsyn(Expression<Func<T, bool>> predicate)
        {
            return await _table.Where(predicate).ToListAsync();
        }

        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {

            IQueryable<T> queryable = GetAll();
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {

                queryable = queryable.Include<T, object>(includeProperty);
            }

            return queryable;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
