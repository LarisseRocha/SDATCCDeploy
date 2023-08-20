using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sdatcc_v2.Infrastructure.Entities
{
	public class TccEntity
	{
		[Key]
		public int Id { get; set; }
		public string Tema { get; set; }
		public DateTime DataPublicacao { get; set; }
		public DateTime DataEntregaTCC { get; set; }
		public string AreaEstudo { get; set; }
		public string Arquivo { get; set; }
		public virtual AlunoEntity Aluno { get; set; }
		public int AlunoId { get; set; }
		public virtual ProfessorEntity Professor { get; set; }
		public int ProfessorId { get; set; }
	}
}
