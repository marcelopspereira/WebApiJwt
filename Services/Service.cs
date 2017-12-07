using System;
using System.Linq;
using System.Threading.Tasks;
using WebApiJwt.Entities;
using WebApiJwt.Repositories;

namespace WebApiJwt.Services
{
    public class Service<T, TKey> : IService<T, TKey>
        where T : class
        where TKey : IEquatable<TKey>
    {
        private readonly IRepository<T, TKey> _repository;

        public Service(ApplicationDbContext dbContext) => _repository = new Repository<T, TKey>(dbContext);

        public async Task<IQueryable<T>> List() => await _repository.List();

        public async Task<T> Get(TKey id) => await _repository.Get(id);

        public async Task Create(T t) => await _repository.Create(t);

        public async Task Update(T t) => await _repository.Update(t);

        public async Task Delete(TKey id) => await _repository.Delete(id);
    }

}