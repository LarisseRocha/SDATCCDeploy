using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Sdatcc_v2.Domain;
using Sdatcc_v2.Infrastructure;
using Sdatcc_v2.Infrastructure.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sdatcc_v2.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
       // private BancoDados _bd;
        private MyDbContext _myDbContext;

        public ProfessorController(MyDbContext myDbContext)
        {
          //  _bd = bd;
            _myDbContext = myDbContext;
        }
        // GET: api/<ProfessorController>
        [HttpGet]
        public IActionResult Get()
        {
            var dados = _myDbContext.Professores;
            return Ok(dados);
        }

        // GET api/<ProfessorController>/5
        [HttpGet("{Cpf}")]
        public IActionResult BuscarProfessorId(string Cpf)
        {
            var professor = _myDbContext.Professores.FirstOrDefault(c => c.Cpf == Cpf);

            if (professor == null)
            {
                return NotFound();
            }

            
            return Ok(professor);
        }

        // POST api/<ProfessorController>
        [HttpPost]
        public IActionResult CadastrarProfessor([FromBody] Professor value)
        {
           ProfessorEntity professorEntity = new ProfessorEntity();
           professorEntity.Nome = value.Nome;
           professorEntity.DataNascimento = value.DataNascimento;
           professorEntity.Cpf = Regex.Replace(value.Cpf, "[^0-9]", "");
           professorEntity.Email = value.Email;
           professorEntity.Senha= value.Senha;

           _myDbContext.Professores.Add(professorEntity);
           _myDbContext.SaveChanges();

           return Ok();
        }

        // PUT api/<ProfessorController>/5
        [HttpPut("{Cpf}")]
        public IActionResult AtualizarProfessor(string Cpf, [FromBody] Professorv2 value)
        {
            var professor = _myDbContext.Professores.FirstOrDefault(c => c.Cpf == Cpf);

            if (professor == null)
            {
                return BadRequest();
            }

            professor.Nome = value.Nome;
            professor.Email = value.Email;

            return Ok();
        }

        // DELETE api/<ProfessorController>/5
        [HttpDelete("{id}")]
        public IActionResult ExcluirProfessor(int Id)
        {
            var professor = _myDbContext.Professores.FirstOrDefault(c => c.Id == Id);

            if (professor == null)
            {
                return NotFound();
            }

            _myDbContext.Professores.Remove(professor);

            return NoContent();
        }
    }
}
