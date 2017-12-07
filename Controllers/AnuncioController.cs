using Microsoft.AspNetCore.Mvc;
using WebApiJwt.Entities;

namespace WebApiJwt.Controllers
{
    [Route("Anuncio/[action]")]
    public class AnuncioController : BaseAsyncController<Anuncio, int>
    {
        public AnuncioController(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}