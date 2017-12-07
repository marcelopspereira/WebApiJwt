using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiJwt.Entities;
using WebApiJwt.Services;

namespace WebApiJwt.Controllers
{
    public class BaseAsyncController<T, TKey> : Controller
    where T : class
    where TKey : IEquatable<TKey>
    {
        private readonly IService<T, TKey> _service;

        public BaseAsyncController(ApplicationDbContext dbContext) => _service = new Service<T, TKey>(dbContext);

        [HttpGet]
        public async Task<object> List()
        {
            return await _service.List();
        }

        [HttpGet]
        public async Task<object> Get(TKey id)
        {
            try
            {
                return await _service.Get(id);
            }
            catch (ApplicationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<object> Update([FromBody] T model)
        {
            try
            {
                await _service.Update(model);
            }
            catch (ApplicationException e)
            {
                return BadRequest(e.Message);
            }

            return "SUCCESS";
        }

        [HttpPost]
        public async Task<object> Create([FromBody] T model)
        {
            try
            {
                await _service.Create(model);
            }
            catch (ApplicationException e)
            {
                return BadRequest(e.Message);
            }

            return "SUCCESS";
        }

        [HttpDelete]
        public async Task<object> Delete(TKey id)
        {
            try
            {
                await _service.Delete(id);
            }
            catch (ApplicationException e)
            {
                return BadRequest(e.Message);
            }

            return "SUCCESS";
        }
    }
}
