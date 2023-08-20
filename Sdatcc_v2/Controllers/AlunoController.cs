using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Sdatcc_v2.Domain;
using Sdatcc_v2.Infrastructure;
using Sdatcc_v2.Infrastructure.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sdatcc_v2.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        
        private MyDbContext _myDbContext;

        public AlunoController (MyDbContext myDbContext)
        {
           
            _myDbContext = myDbContext;

        }
        // GET: api/<AlunoController>
        [HttpGet]
        public IActionResult Get()
        {
            var dados = _myDbContext.Alunos;

            return Ok(dados);
        }

        // GET api/<AlunoController>/5
        [HttpGet("{Cpf}")]
        public IActionResult BuscarAlunoCpf(string Cpf)
        {
            var aluno = _myDbContext.Alunos.FirstOrDefault(c => c.Cpf == Cpf);

            if (aluno == null)
            {
                return NotFound();
            }

            return Ok(aluno);
        }

        // POST api/<AlunoController>
        [HttpPost]
        public IActionResult CadastrarAluno([FromBody] Aluno value)
        {             

            AlunoEntity alunoEntity = new AlunoEntity();
            alunoEntity.Nome = value.Nome;
            var testNomeVazio = Regex.Replace(alunoEntity.Nome, @"\s+", "");
            if (testNomeVazio == string.Empty)
            {
	            return StatusCode(500);
            }
            bool hasNumber = value.Nome.Any(char.IsDigit);
            if (hasNumber)
            {
	            Console.WriteLine("Nome inválido");
	            return StatusCode(500);
            }
           
            alunoEntity.Email = value.Email;         

            alunoEntity.DataNascimento = value.DataNascimento;
            alunoEntity.NumeroMatricula = value.NumeroMatricula;
            alunoEntity.Cpf = Regex.Replace(value.Cpf, "[^0-9]", "");
            alunoEntity.Senha = value.Senha;

	          bool IsCpf(string Cpf)
              {
	            var alunoCpf = _myDbContext.Alunos.FirstOrDefault(c => c.Cpf == Cpf);

                int[] multiplicador1 = new int[9] {10, 9, 8, 7, 6, 5, 4, 3, 2};
	            int[] multiplicador2 = new int[10] {11, 10, 9, 8, 7, 6, 5, 4, 3, 2};

	            if (alunoCpf.Cpf.Length != 11)
		            return false;

	            for (int j = 0; j < 10; j++)
		            if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == alunoCpf.Cpf)
			            return false;

	            string tempCpf = Cpf.Substring(0, 9);
	            int soma = 0;

	            for (int i = 0; i < 9; i++)
		            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

	            int resto = soma % 11;
	            if (resto < 2)
		            resto = 0;
	            else
		            resto = 11 - resto;

	            string digito = resto.ToString();
	            tempCpf = tempCpf + digito;
	            soma = 0;
	            for (int i = 0; i < 10; i++)
		            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

	            resto = soma % 11;
	            if (resto < 2)
		            resto = 0;
	            else
		            resto = 11 - resto;

	            digito = digito + resto.ToString();

	            return alunoCpf.Cpf.EndsWith(digito);

            }

            _myDbContext.Alunos.Add(alunoEntity);
            _myDbContext.SaveChanges();

            return Ok();

        }


        // PUT api/<AlunoController>/5
        [HttpPut("{Cpf}")]
        public IActionResult AtualizarAluno(string Cpf, [FromBody] Alunov2 value)
        {
            var aluno = _myDbContext.Alunos.FirstOrDefault(c => c.Cpf == Cpf);
            if (aluno == null)
            {
                return BadRequest();
            }
            
            aluno.Nome = value.Nome;
            aluno.Email = value.Email;
            
            return Ok();
        }

        // DELETE api/<AlunoController>/5
        [HttpDelete("{Id}")]
        public IActionResult ExcluirAluno(int Id)
        {
            var aluno = _myDbContext.Alunos.FirstOrDefault(c => c.Id == Id);

            if (aluno == null)
            {
                return NotFound();
            }

            _myDbContext.Alunos.Remove(aluno);

            return NoContent();
        }
    }
}
