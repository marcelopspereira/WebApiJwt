using Microsoft.AspNetCore.Mvc;
using WebApiJwt.Entities;

namespace WebApiJwt.Controllers
{
    [Route("Usuario/[action]")]
    public class UsuarioController : BaseAsyncController<Usuario, int>
    {
        public UsuarioController(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}