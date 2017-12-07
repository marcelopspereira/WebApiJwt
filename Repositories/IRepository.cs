using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApiJwt.Repositories
{
    public interface IRepository<T, TKey>
    where T : class
    where TKey : IEquatable<TKey>
    {
        Task<DbSet<T>> List();
        Task<T> Get(TKey id);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task Delete(TKey id);
    }
}