using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebApiJwt.Entities;

namespace WebApiJwt.Repositories
{
    public class Repository<T, TKey> : IRepository<T, TKey>
       where T : class
       where TKey : IEquatable<TKey>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = dbContext.Set<T>();
        }

        public async Task<DbSet<T>> List() => await Task.Run(() => _dbSet);

        public async Task<T> Get(TKey id) => await _dbSet.FindAsync(id);

        public async Task Create(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            EntityEntry dbEntityEntry = _dbContext.Entry(entity);

            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                _dbSet.Attach(entity);
                _dbSet.Remove(entity);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(TKey id)
        {
            if (await Get(id) == null) return;
            await Delete(await Get(id));

            // var entity= await Get(id);
            // if (entity == null) return;
            // await Delete(entity);
        }
    }

}