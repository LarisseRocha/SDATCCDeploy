using Sdatcc_v2.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sdatcc_v2.Infrastructure
{
	public class BancoDados
    {
        public List<AlunoEntity> tblAlunos;
        public List<ProfessorEntity> tblProfessores;
        public List<TccEntity> tblTccs;



        public BancoDados()
        {

            tblAlunos = new List<AlunoEntity>();
            tblAlunos.Add(new AlunoEntity
            {
                Id = 1,
                Nome = "Luis",
                NumeroMatricula = 9098,
                DataNascimento = DateTime.Now,
                Email = "luis@gmail.com",
                Cpf = "909.123.327-08"

            });

            
            tblAlunos.Add(new AlunoEntity
            {
                Id = 2,
                Nome = "Maria",
                NumeroMatricula = 9094,
                DataNascimento = DateTime.Now,
                Email = "maria@gmail.com",
                Cpf = "971.190.967-02" 

            });


            tblProfessores = new List<ProfessorEntity>();
            tblProfessores.Add(new ProfessorEntity
            {
                Id = 1,
                Nome = "Pedro",
                Cpf = "220.098.878-87",
                DataNascimento = DateTime.Now,
                Email = "pedro@gmail.com"
            });

            
            tblProfessores.Add(new ProfessorEntity
            {
                Id = 2,
                Nome = "Marli",
                DataNascimento = DateTime.Now,
                Email = "marli@outlook.com",
                Cpf = "210.098.876-78"
            });

            tblTccs = new List<TccEntity>();
            tblTccs.Add(new TccEntity
                {
                    Id = 1,
                    Tema = "Jogo digital educacional",
                    AreaEstudo = "Computação",
                    DataPublicacao = DateTime.Now,
                    Arquivo = "teste",
                    Aluno = tblAlunos.FirstOrDefault(c => c.Id == 1),
                    Professor = tblProfessores.FirstOrDefault(c => c.Id == 1)

                });

   
            tblTccs.Add(new TccEntity
            {
                Id = 2,
                Tema = "Repositório Digital Institucional",
                AreaEstudo = "Computação",
                DataPublicacao = DateTime.Now,
                Arquivo = "teste2",
                Aluno = tblAlunos.FirstOrDefault(c => c.Id == 2),
                Professor = tblProfessores.FirstOrDefault(c=> c.Id == 2)
            });
        }
    }
}