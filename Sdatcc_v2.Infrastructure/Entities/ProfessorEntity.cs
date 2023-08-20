using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sdatcc_v2.Infrastructure.Entities
{
	public class ProfessorEntity
	{
		[Key]
		public int Id { get; set; }
		public string Nome { get; set; }
		public DateTime DataNascimento { get; set; }
		public string Cpf { get; set; }
		public string Email { get; set; }
		public string Senha { get; set; }
	}
}
