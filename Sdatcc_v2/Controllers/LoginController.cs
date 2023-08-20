using Microsoft.AspNetCore.Mvc;
using Sdatcc_v2.Domain;
using Sdatcc_v2.Infrastructure;
using Sdatcc_v2.Infrastructure.Entities;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sdatcc_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private MyDbContext _myDbContext;
        public LoginController(MyDbContext myDbContext)
        {

            _myDbContext = myDbContext;

        }
        // GET: api/<LoginController>
        [HttpGet]
        public IActionResult Get()
        {
            var dados = _myDbContext.Logins;

            return Ok(dados);
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public IActionResult BuscarPorUsuario(string Usuario)
        {
            var usuario = _myDbContext.Logins.FirstOrDefault(c => c.Usuario == Usuario);

            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }
    }
}
